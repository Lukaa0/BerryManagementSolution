using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BerryManagementApplication.Classes
{
    public static class WordReportMaker
    {
        static int flag = 0;

        /// <summary>
        /// მეთოდი ქმნის ვორდის დოკუმენტს გადაცემული შაბლონის და ამ შაბლონში ჩასასმელი მონაცემების საფუძველზე და აბრუნებს მისამართს 
        /// </summary>
        /// <param name="wordocumentTemplateData">დოკუმენტს შაბლონი. უნდა იყის .docx</param>
        /// <param name="listReportObjects">შაბლონში ჩასასმელი მონაცემები</param>
        /// <returns>საბოლოო დუკუმენტის მისამართი</returns>
        public static string Generate(byte[] wordocumentTemplateData, object listReportObjects)
        {
            string result = null;
            string url = System.IO.Path.GetTempPath();
            string templateName = url + @"\" + Guid.NewGuid().ToString() + ".docx";
            File.WriteAllBytes(templateName, wordocumentTemplateData);
            result = url + @"\" + Guid.NewGuid().ToString() + ".docx";
            Generate(templateName, listReportObjects, result);
            return result;
        }

        /// <summary>
        /// მეთოდი ქმნის ვორდის დოკუმენტს შაბლონში მონაცემების ჩასმით
        /// </summary>
        /// <param name="srcUrl">შაბლონის მისამართი</param>
        /// <param name="ListReportObjects">ჩასასმელი მონაცემები</param>
        /// <param name="destUrl">მიღებული შედეგის მისამართი</param>
        public static void Generate(string srcUrl, object ListReportObjects, string destUrl)
        {
            IList objList = ListReportObjects as IList;
            flag = 0;
            foreach (var obj in objList)
            {
                if (flag == 0)
                {
                    Copy(srcUrl, obj, destUrl);
                    cleanup(destUrl);
                    flag = 1;
                }
                else
                {
                    Copy(srcUrl, obj, "temp.docx");
                    cleanup("temp.docx");
                    Merge("temp.docx", destUrl);
                }
            }

        }

        private static string getFormattedFieldText(FieldCode field, object propValue, string botName)
        {   // takes original author field to parse and decide what is it to be replaced with

            if (field.Text == "done") return "trynext"; // If returns "trynext" continue in caller
            if (propValue.ToString() == "") return "trynext";
            if (!field.Text.StartsWith(" AUTHOR  ")) return "trynext"; // must be author field
            string FieldFormat = getFieldFormat(field);

            string fieldPropFormat = Regex.Match(FieldFormat, "(?<=:fmt:).+(?=<f>)").ToString();
            string patternToSwap = Regex.Match(FieldFormat, @"<f>.+<f>").ToString();

            string fieldPropName = Regex.Match(FieldFormat, @"(?<=<f>).+(?=:fmt:)").ToString();
            if (fieldPropFormat == "")
            {
                fieldPropName = Regex.Match(FieldFormat, @"(?<=<f>).+(?=<f>)").ToString();
            }
            if (fieldPropName != botName) return "trynext";


            string target = ""; // replacement of variable
            try
            {
                if (fieldPropFormat == "")
                {
                    target = propValue.ToString();
                }
                else if (fieldPropFormat == "Num2Geo")
                {
                    double num2pass = Convert.ToDouble(propValue.ToString());
                    target = Num2Geo.Translit(num2pass);
                }
                else if (fieldPropFormat == "Num2Eng")
                {// FIXME
                    string num = propValue.ToString();
                    if (num.Contains('.'))
                    {
                        int number = Int32.Parse(propValue.ToString().Split('.')[0]);

                        target = NumberToWords(number) + "." + propValue.ToString().Split('.')[1];
                    }
                    else
                    {
                        target = propValue.ToString();
                    }
                }
                else
                {
                    target = string.Format(fieldPropFormat, propValue);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message + " in field: " + FieldFormat);
            }

            string newText = Regex.Replace(FieldFormat, patternToSwap, target);

            return newText;


        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private static void cleanup(string dest)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(dest, true))
            {
                foreach (var field in doc.MainDocumentPart.RootElement.Descendants<FieldCode>())
                {
                    if (!(field.Text == "done") && field.Text.StartsWith(" AUTHOR  "))
                        field.Remove();
                }
                foreach (var header in doc.MainDocumentPart.HeaderParts)
                    foreach (var field in header.RootElement.Descendants<FieldCode>())
                    {
                        if (!(field.Text == "done") && field.Text.StartsWith(" AUTHOR  "))
                            field.Remove();
                    }
                //DO CODE
                foreach (var footer in doc.MainDocumentPart.FooterParts)
                    foreach (var field in footer.RootElement.Descendants<FieldCode>())
                    {
                        if (!(field.Text == "done") && field.Text.StartsWith(" AUTHOR  "))
                            field.Remove();

                    }
            }
        }

        private static string getFieldFormat(FieldCode field)
        {
            Int32 endMerge = field.Text.IndexOf(@"\*");
            Int32 fieldNameLength = field.Text.Length - endMerge;
            String fieldName = field.Text.Substring(9, endMerge - 11);
            //   Console.WriteLine(fieldName);
            Match match = Regex.Match(fieldName, "(?<=\").+(?=\")");
            if (match.Success)
                return match.ToString();
            else
                return fieldName;
        }

        private static void updateFieldText(FieldCode field, string newText)
        {

            Run xxxfield = (Run)field.Parent;
            Run rBegin = xxxfield.PreviousSibling<Run>();
            Run rSep = xxxfield.NextSibling<Run>();
            Run rText = rSep.NextSibling<Run>();
            Run rEnd = rText.NextSibling<Run>();
            Text t = rText.GetFirstChild<Text>();
            t.Text = newText;
            field.Text = "done";
        }

        private static string updateText(string dest, object obj/*, string parent*/)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(obj, null);
                string propName = prop.ToString().Split()[prop.ToString().Split().Count() - 1];
                if (propValue == null) continue;

                string propType = propValue.GetType().ToString();
                //   Console.WriteLine(propType);
                var split = propType.Split('.');
                if (propType.Contains("System.Collections.Generic"))
                {
                    propType = "System.Collections";
                }

                string botName = obj.GetType().Name + "." + propName; // parent.currentclass.param

                switch (propType)
                {
                    case "System.String":
                    case "System.DateTime":
                    case "System.Double":
                    case "System.Int32":
                    // new
                    case "System.Boolean":
                    case "System.Byte":
                    case "System.SByte":
                    case "System.Char":
                    case "System.Single":
                    case "System.UInt32":
                    case "System.Int64":
                    case "System.UInt64":
                    case "System.Int16":
                    case "System.UInt16":
                    case "System.Decimal":
                        {
                            using (WordprocessingDocument doc = WordprocessingDocument.Open(dest, true))
                            {
                                foreach (var field in doc.MainDocumentPart.RootElement.Descendants<FieldCode>())
                                {
                                    string newText = getFormattedFieldText(field, propValue, botName);
                                    if (newText == "trynext") continue;
                                    updateFieldText(field, newText);
                                }
                                foreach (var header in doc.MainDocumentPart.HeaderParts)
                                    foreach (var field in header.RootElement.Descendants<FieldCode>())
                                    {
                                        string newText = getFormattedFieldText(field, propValue, botName);
                                        if (newText == "trynext") continue;
                                        updateFieldText(field, newText);

                                    }
                                //DO CODE
                                foreach (var footer in doc.MainDocumentPart.FooterParts)
                                    foreach (var field in footer.RootElement.Descendants<FieldCode>())
                                    {
                                        string newText = getFormattedFieldText(field, propValue, botName);
                                        if (newText == "trynext") continue;
                                        updateFieldText(field, newText);
                                    }
                                //DO CODE

                            }

                            break;
                        }
                    case "System.Drawing.Bitmap":
                        {
                            Image im = propValue as Image;

                            if (flag == 0)
                            {
                                ReplaceImage(botName, im, dest);
                            }
                            else
                            {
                                ReplaceImage(botName, im);
                            }


                            break;
                        }
                    case "System.Collections":
                        {
                            break;
                        }
                    default:
                        {

                            updateText(dest, propValue);
                            break;
                        }
                }
            }
            return "";
        }



        private static TableCell ChangeCellText(TableCell cell, object srcText, string destText)
        {
            string text = cell.InnerText;
            foreach (Paragraph p in cell.Elements<Paragraph>())
            {
                // Console.WriteLine(text);
                foreach (Run r in p.Elements<Run>())
                {
                    foreach (Text t in r.Elements<Text>())
                    {
                        t.Text = "";
                    }
                }
                //FIXME, change text if text is sth
                p.Elements<Run>().First().Elements<Text>().First().Text = destText;
            }
            return cell;
        }

        private static void ReplaceImage(string tagName, Image image, string srcPath = @"temp.docx")
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(srcPath, true))
            {
                var drawings = wordDoc.MainDocumentPart.Document.Descendants<Drawing>().ToList();

                foreach (Drawing drawing in drawings)
                {
                    DocProperties dpr = drawing.Descendants<DocProperties>().FirstOrDefault();
                    if (dpr != null && dpr.Name == tagName)
                    {
                        foreach (DocumentFormat.OpenXml.Drawing.Blip b in drawing.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().ToList())
                        {
                            OpenXmlPart imagePart = wordDoc.MainDocumentPart.GetPartById(b.Embed);
                            using (var writer = new BinaryWriter(imagePart.GetStream()))
                            {
                                MemoryStream ms = new MemoryStream();
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                                writer.Write(ms.ToArray());
                            }
                        }
                    }
                }
            }
        }

        private static void updateTables(string docText, object obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(obj, null);
                string propName = prop.ToString().Split()[prop.ToString().Split().Count() - 1];
                if (propValue == null) continue;
                string propType = propValue.GetType().ToString();
                // Console.WriteLine(propType);
                var split = propType.Split('.');
                if (propType.Contains("System.Collections.Generic"))
                {
                    propType = "System.Collections";
                }

                string botName = obj.GetType().Name + "." + propName; // parent.currentclass.param
                switch (propType)
                {
                    case "System.String":
                    case "System.DateTime":
                    case "System.Double":
                    case "System.Int32":
                    case "System.Drawing.Bitmap":
                    // new case "System.Boolean":
                    case "System.Byte":
                    case "System.SByte":
                    case "System.Char":
                    case "System.Single":
                    case "System.UInt32":
                    case "System.Int64":
                    case "System.UInt64":
                    case "System.Int16":
                    case "System.UInt16":
                    case "System.Decimal":
                        {
                            break;
                        }
                    case "System.Collections":
                        {
                            using (WordprocessingDocument doc = WordprocessingDocument.Open(docText, true))
                            {
                                // Find the first table in the document.
                                foreach (Table table in doc.MainDocumentPart.Document.Body.Elements<Table>())
                                {
                                    IList objList = propValue as IList;
                                    foreach (var o in objList)
                                    {
                                        TableRow temp = table.Elements<TableRow>().Last();
                                        temp = new TableRow(temp.OuterXml);

                                        int flag = 0; // add a row if needed and become 1 to avoid adding again
                                        Type otype = o.GetType();
                                        IList<PropertyInfo> oprops = new List<PropertyInfo>(otype.GetProperties());

                                        foreach (var oprop in oprops)
                                        {
                                            string opropName = oprop.ToString().Split()[oprop.ToString().Split().Count() - 1];
                                            opropName = o.GetType().Name + "." + opropName;
                                            var opropValue = oprop.GetValue(o, null);
                                            if (opropValue == null) continue;
                                            foreach (var field in table.Descendants<FieldCode>())
                                            {

                                                string newText = getFormattedFieldText(field, opropValue, opropName);
                                                if (newText == "trynext") continue;
                                                updateFieldText(field, newText);
                                                if (flag == 0) // Add Row
                                                {
                                                    flag = 1;

                                                }
                                            }
                                        }

                                        // Cleanup
                                        foreach (var field in table.Descendants<FieldCode>())
                                        {
                                            if (!(field.Text == "done") && field.Text.StartsWith(" AUTHOR  "))
                                                field.Remove();
                                        }
                                        if (flag == 1) table.Append(temp);

                                    }
                                    table.Elements<TableRow>().Last().Remove();

                                }
                            }

                            break;
                        }
                    default:
                        {
                            updateTables(docText, propValue);
                            break;
                        }
                }
            }
        }

        private static void Copy(string src, object obj, string dest)
        {
            using (var mainDoc = WordprocessingDocument.Open(src, false)) // sauce
            using (var resultDoc = WordprocessingDocument.Create(dest, WordprocessingDocumentType.Document)) // dest
            {
                // copy parts from source document to new document
                foreach (var part in mainDoc.Parts)
                    resultDoc.AddPart(part.OpenXmlPart, part.RelationshipId);
            }

            // replacements off-table
            updateText(dest, obj);

            // table replacements. perform replacements in resultDoc.MainDocumentPart

            updateTables(dest, obj);





        }

        private static void Merge(string src, string dest)
        {
            using (WordprocessingDocument myDoc = WordprocessingDocument.Open(dest, true))
            {
                Random rnd = new Random();
                int rn1 = rnd.Next(0, 2146999999);
                int rn2 = rnd.Next(0, 2146999999);

                string altChunkId = "alt" + rn1.ToString() + rn2.ToString();
                MainDocumentPart mainPart = myDoc.MainDocumentPart;
                AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);

                using (FileStream fileStream = File.Open(src, FileMode.Open))
                    chunk.FeedData(fileStream);
                AltChunk altChunk = new AltChunk();
                altChunk.Id = altChunkId;
                mainPart.Document
                    .Body
                    .InsertAfter(altChunk, mainPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last());
                mainPart.Document.Save();
            }
        }
    }
}