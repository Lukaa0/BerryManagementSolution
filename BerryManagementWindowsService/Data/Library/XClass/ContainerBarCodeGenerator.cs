using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library.XClass
{
    public static class ContainerBarCodeGenerator
    {
        public static List<string> CreateContainers(string containerTypeId, int count, ref string errorMessage)
        {
            List<string> result = null;
            try
            {
                string barCode = GetLastContainerBarCode(containerTypeId, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                result = new List<string>();
                List<Container> containers = new List<Container>();
                using (BerryManagementEntities context = new BerryManagementEntities())
                {

               
                for (int i = 1; i <= count; i++)
                {
                    barCode = GenerateContainerBarCode(containerTypeId, barCode, ref errorMessage);
                    Container container = new Container()
                    {
                        Container_BarCode = barCode,
                        Container_ContainerType_Id = containerTypeId, Container_IsActive = true
                    };
                    result.Add(barCode);
                    context.Containers.Add(container);
                }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CreateContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CreateContainers()\n" + ex.Message;
                }
            }
            return result;
        }

        public static string CreateContainer(string containerTypeId, ref string errorMessage)
        {
            string result = null;
            try
            {
                string containerBarCode = GenerateContainerBarCode(containerTypeId, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                Container container = new Container()
                {
                    Container_BarCode = containerBarCode,
                    Container_ContainerType_Id = containerTypeId,
                    Container_IsActive = true
                };
                result = Insert.InsertContainer(container, ref errorMessage);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
            }
            return result;
        }

        private static string GenerateContainerBarCode(string containerTypeId, ref string errorMessage)
        {
            string result = null;
            try
            {
                string lastContainerBarCode = GetLastContainerBarCode(containerTypeId, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                result = GenerateContainerBarCode(containerTypeId, lastContainerBarCode, ref errorMessage);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
            }
            return result;
        }

        private static string GenerateContainerBarCode(string containerTypeId, string lastContainerBarCode, ref string errorMessage)
        {
            string result = null;
            try
            {
                if (string.IsNullOrEmpty(lastContainerBarCode))
                {
                    result = containerTypeId + "-" + DateTime.Today.Year.ToString() + 1.ToString("0000000");
                }
                else
                {
                    if (int.Parse(lastContainerBarCode.Substring(3, 4)) == DateTime.Today.Year)
                    {
                        int i = int.Parse(lastContainerBarCode.Substring(7, 7));
                        i = i + 1;
                        result = containerTypeId + "-" + DateTime.Today.Year.ToString() + i.ToString("0000000");
                    }
                    else
                    {
                        result = containerTypeId + "-" + DateTime.Today.Year.ToString() + 1.ToString("0000000");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "მეთოდი: GenerateContainerBarCode()\n" + ex.Message;
            }
            return result;
        }

        private static string GetLastContainerBarCode(string containerTypeId, ref string errorMessage)
        {
            string result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectContainers(context, null, containerTypeId, null, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    List<Tuple<string, int, Classes.EntityAutoMultipleSorter.SortDirection>> sortExpressions =
                    new List<Tuple<string, int, Classes.EntityAutoMultipleSorter.SortDirection>>();
                    Tuple<string, int, Classes.EntityAutoMultipleSorter.SortDirection> sortExpression1 =
                        new Tuple<string, int, Classes.EntityAutoMultipleSorter.SortDirection>("Container_BarCode", 1,
                        Classes.EntityAutoMultipleSorter.SortDirection.Descending);
                    sortExpressions.Add(sortExpression1);
                    selectText = Classes.EntityAutoMultipleSorter.MultipleSort(selectText, sortExpressions);
                    Container container = selectText.FirstOrDefault();
                    if (container != null)
                    {
                        result = container.Container_BarCode;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GenerateContainerBarCode()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
