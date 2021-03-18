using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BerryManagementWindowsService.Classes
{
    public static class Serializers
    {
        public static XElement ObjectToXElement<T>(this object obj, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                    {
                        XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                        xmlSerializerNamespaces.Add("", "");
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        xmlSerializer.Serialize(streamWriter, obj, xmlSerializerNamespaces);
                        result = XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
                        result.Descendants().Where(x => string.IsNullOrEmpty(x.Value) && x.Attributes().
                            Where(y => y.Name.LocalName == "nil" && y.Value == "true").Count() > 0).Remove();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "სერიალიზაცია ვერ მოხერხდა: ObjectToXElement()" +
                        "()\n" + ex.Message;
            }
            return result;
        }

        public static T XElementToObject<T>(this XElement xElement, ref string errorMessage)
        {
            T result = default(T);
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                result = (T)xmlSerializer.Deserialize(xElement.CreateReader());
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "დესერიალიზაცია ვერ მოხერხდა: XElementToObject()" +
                        "()\n" + ex.Message;
            }
            return result;
        }
    }
}
