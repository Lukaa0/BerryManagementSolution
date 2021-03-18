using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementApplication.Classes
{
    class Num2Geo
    {
        public static string Translit(double number)
        {
            string numString = number.ToString();

            if (numString.Contains("."))
            {
                string beforeDecimal = number.ToString().Split('.')[0];
                string afterDecimal = number.ToString().Split('.')[1];
                if (afterDecimal.Length >= 2)
                {
                    afterDecimal = afterDecimal.Substring(0, 2);
                }
                else
                {
                    if (afterDecimal.Length == 1)
                    {
                        afterDecimal += "0";
                    }
                }
                numString = miliardamde(beforeDecimal) + "." + afterDecimal;
            }
            else
            {
                numString = miliardamde(numString);
            }

            return numString;
        }

        private static string parseBeforeDecimalPoint(string ricxvi)
        {

            return miliardamde(ricxvi);
        }

        private static string miliardamde(string wdigit)
        {
            string res = "";
            int number = Int32.Parse(wdigit);
            string milioneulamde = (number % 1000000).ToString();
            string milioneuli = (number / 1000000).ToString();

            if (number < 1000000)
            {
                res += milionamde(wdigit);
            }
            //else if (number == 1000000)
            //{
            //    res += "მილიონი";
            //}
            else if (number % 1000000 == 0)
            {
                res += milionamde(milioneuli) + " მილიონ";
            }
            else
            {
                res += milionamde(milioneuli) + " მილიონ " + milionamde(milioneulamde);
            }

            return res;
        }

        private static string milionamde(string wdigit)
        {
            string res = "";
            int number = Int32.Parse(wdigit);
            string ataseulamde = (number % 1000).ToString();
            string ataseuli = (number / 1000).ToString();

            if (number < 1000)
            {
                res += atasamde(wdigit);
            }
            //else if (number == 1000)
            //{
            //    res += "ათასი";
            //}
            else if (number % 1000 == 0)
            {
                res += atasamde(ataseuli) + " ათასი";
            }
            else
            {
                res += atasamde(ataseuli) + " ათას " + atasamde(ataseulamde);
            }

            return res;
        }


        private static string atasamde(string wdigit)
        {
            string res = "";
            int number = Int32.Parse(wdigit);
            string aseulamde = (number % 100).ToString();
            string aseuli = (number / 100).ToString();

            if (number < 100)
            {
                res += asamde(wdigit);
            }
            else if (number == 100)
            {
                res += "ასი";
            }
            else if (number % 100 == 0)
            {
                res += RemoveLastLetters(asamde(aseuli), 1) + "ასი";
            }
            else if (number < 200)
            {
                res += "ას " + asamde(aseulamde);
            }
            else if (number > 800)
            {
                res += asamde(aseuli) + "ას " + asamde(aseulamde);
            }
            else
            {
                res += RemoveLastLetters(asamde(aseuli), 1) + "ას " + asamde(aseulamde);
            }

            return res;
        }

        private static string RemoveLastLetters(string wdigit, int num)
        {
            int length = 0;
            string res = "";
            int counter = 0;
            foreach (var letter in wdigit)
            {
                length += 1;
            }
            foreach (var letter in wdigit)
            {
                res += letter;
                counter += 1;
                if (counter == length - num)
                {
                    break;
                }
            }
            return res;
        }

        private static string asamde(string wdigit)
        {
            int number = Int32.Parse(wdigit);
            string res = "";

            if (number < 20)
            {
                res += otsamde(wdigit);
            }

            switch (number)
            {
                case 20: res += "ოცი"; break;
                case 40: res += "ორმოცი"; break;
                case 60: res += "სამოცი"; break;
                case 80: res += "ოთხმოცი"; break;
            }

            if (20 < number && number < 40)
            {
                res += "ოცდა" + otsamde((number % 20).ToString());
            }

            if (40 < number && number < 60)
            {
                res += "ორმოცდა" + otsamde((number % 20).ToString());
            }
            if (60 < number && number < 80)
            {
                res += "სამოცდა" + otsamde((number % 20).ToString());
            }
            if (80 < number && number < 100)
            {
                res += "ოთხმოცდა" + otsamde((number % 20).ToString());
            }


            return res;
        }

        private static string otsamde(string wdigit)
        {
            int number = Int32.Parse(wdigit);
            string res = "";
            switch (number)
            {
                case 0: res += "ნული"; break;
                case 1: res += "ერთი"; break;
                case 2: res += "ორი"; break;
                case 3: res += "სამი"; break;
                case 4: res += "ოთხი"; break;
                case 5: res += "ხუთი"; break;
                case 6: res += "ექვსი"; break;
                case 7: res += "შვიდი"; break;
                case 8: res += "რვა"; break;
                case 9: res += "ცხრა"; break;
                case 10: res += "ათი"; break;
                case 11: res += "თერთმეტი"; break;
                case 12: res += "თორმეტი"; break;
                case 13: res += "ცამეტი"; break;
                case 14: res += "თოთხმეტი"; break;
                case 15: res += "თხუთმეტი"; break;
                case 16: res += "თექვსმეტი"; break;
                case 17: res += "ჩვიდმეტი"; break;
                case 18: res += "თვრამეტი"; break;
                case 19: res += "ცხრამეტი"; break;
                default: res += "Error"; break;
            }
            return res;
        }

    }
}
