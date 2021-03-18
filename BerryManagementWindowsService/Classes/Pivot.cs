using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace BerryManagementWindowsService.Classes
{
    public static class Pivot
    {
        public static DataTable GetPivotDataTable<T>(List<string> calculatedColumnNames,
            IList<T> source, List<dynamic[]> pivotArraies, bool isNeedSum, List<string> hideColumns)
        {
            if(pivotArraies.Count > 1)
            {
                isNeedSum = false;
            }
            string totalColumnName = "სულ";
            DataTable dataTable = new DataTable();
            List<System.Reflection.PropertyInfo> columns = source[0].GetType().GetProperties().ToList();
            foreach (var column in columns)
            {
                if (!hideColumns.Contains(column.Name))
                {
                    if (!column.Name.Contains("Pivoted_Tables"))
                    {
                        dataTable.Columns.Add(new DataColumn(column.Name.Replace("_", " ")));
                    }
                    else
                    {
                        foreach (dynamic[] pivotArray in pivotArraies)
                        {
                            var obj = pivotArray[0];
                            foreach (var property in (IDictionary<String, Object>)obj)
                            {
                                if (!dataTable.Columns.Contains(property.Key) && !hideColumns.Contains(property.Key))
                                {
                                    dataTable.Columns.Add(new DataColumn(property.Key));
                                }
                            }
                        }
                    }
                }
            }
            if (isNeedSum)
            {
                dataTable.Columns.Add(new DataColumn(totalColumnName));
            }
                
            foreach (var record in source)
            {
                DataRow row = dataTable.NewRow();
                foreach (string columnName in calculatedColumnNames)
                {
                    row.SetField(columnName, 0);
                }
                if (isNeedSum)
                {
                    row.SetField(totalColumnName, 0);
                }
                foreach (var field in record.GetType().GetProperties())
                {
                    var fm = record.GetType().GetProperty(field.Name).GetValue(record);
                    if (fm != null)
                    {
                        if (fm.GetType() == typeof(ExpandoObject))
                        {
                            foreach (var property in (IDictionary<String, Object>)fm)
                            {
                                if (!hideColumns.Contains(property.Key))
                                {
                                    row[property.Key] = property.Value;
                                }
                                if (isNeedSum && calculatedColumnNames.Contains(property.Key))
                                {
                                    decimal totalValue = 0;
                                    decimal.TryParse(row[totalColumnName].ToString(), out totalValue);
                                    decimal fieldValue = 0;
                                    decimal.TryParse(property.Value.ToString(), out fieldValue);
                                    totalValue = totalValue + fieldValue;
                                    row[totalColumnName] = totalValue;
                                }
                            }
                        }
                        else
                        {
                            row[field.Name.Replace("_"," ")] = fm;
                        }
                    }
                }
                dataTable.Rows.Add(row);
            }
            DataRow nawRow = dataTable.NewRow();
            nawRow.SetField(0, "სულ");
            DataRow nawRow2 = dataTable.NewRow();
            nawRow2.SetField(0, "საშუალო");
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 1; i < row.ItemArray.Length; i++)
                {
                    decimal coumnValue = 0;
                    if (decimal.TryParse(row[i].ToString(), out coumnValue))
                    {
                        decimal columnTotal = 0;
                        decimal.TryParse(nawRow.ItemArray[i].ToString(), out columnTotal);
                        nawRow.SetField(i, columnTotal + coumnValue);
                    }
                }
                nawRow.SetField(1, "რაოდენობა - " + dataTable.Rows.Count);
            }
            decimal t = decimal.Parse(nawRow.ItemArray[4].ToString());
            decimal average = t / dataTable.Rows.Count;
            if(dataTable.Columns.Contains("საშუალო ნეტო"))
            {
                nawRow.SetField(5, "");
            }
            nawRow2.SetField(4, average.ToString("0.00"));
            dataTable.Rows.InsertAt(nawRow, 0);
            dataTable.Rows.InsertAt(nawRow2, 1);
            return dataTable;
        }

        public static DataTable ToPivotTable<T, TColumn, TRow, TData>(
              this IEnumerable<T> source,
              Func<T, TColumn> columnSelector,
              Expression<Func<T, TRow>> rowSelector,
              Func<IEnumerable<T>, TData> dataSelector)
        {
            DataTable table = new DataTable();
            var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            table.Columns.Add(new DataColumn(rowName));
            var columns = source.Select(columnSelector).Distinct();

            foreach (var column in columns)
                table.Columns.Add(new DataColumn(column.ToString()));

            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             });

            foreach (var row in rows)
            {
                var dataRow = table.NewRow();
                var items = row.Values.Cast<object>().ToList();
                items.Insert(0, row.Key);
                dataRow.ItemArray = items.ToArray();
                table.Rows.Add(dataRow);
            }

            return table;
        }

        public static dynamic[] ToPivotArray<T, TColumn, TRow, TData>(
            this IEnumerable<T> source,
            Func<T, TColumn> columnSelector,
            Expression<Func<T, TRow>> rowSelector,
            Func<IEnumerable<T>, TData> dataSelector)
        {

            var arr = new List<object>();
            var cols = new List<string>();
            String rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            var columns = source.Select(columnSelector).Distinct();

            cols = (new[] { rowName }).Concat(columns.Select(x => x.ToString())).ToList();


            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             }).ToArray();


            foreach (var row in rows)
            {
                var items = row.Values.Cast<object>().ToList();
                items.Insert(0, row.Key);
                var obj = GetAnonymousObject(cols, items);
                arr.Add(obj);
            }
            return arr.ToArray();
        }

        static dynamic GetAnonymousObject(IEnumerable<string> columns, IEnumerable<object> values)
        {
            IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
            int i;
            for (i = 0; i < columns.Count(); i++)
            {
                eo.Add(columns.ElementAt<string>(i), values.ElementAt<object>(i));
            }
            return eo;
        }
    }
}
