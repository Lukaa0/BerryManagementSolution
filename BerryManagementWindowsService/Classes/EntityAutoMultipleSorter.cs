using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BerryManagementWindowsService.Classes
{
    /// <summary>
    /// კლასი ავტომატურად აფორმირებს IOrderedQueryable<T> ობიექტს 
    /// და აბრუნებს როგორც IQueryable<T> ობიექტს 
    /// რომელშიც გაწერილია სორტირების პირობები 
    /// </summary>
    public static class EntityAutoMultipleSorter
    {
        /// <summary>
        /// დახარისხების პირობა Ascending ან Descending
        /// </summary>
        public enum SortDirection
        {
            Ascending,
            Descending
        }

        /// <summary>
        /// მეთოდი ავტომატურად აფორმირებს IOrderedQueryable<T> ობიექტს 
        /// და აბრუნებს როგორც IQueryable<T> ობიექტს 
        /// რომელშიც გაწერილია სორტირების პირობები
        /// </summary>
        /// <typeparam name="T">ობიექტის კლასი</typeparam>
        /// <param name="data">IQueryable<T> ტიპის ობიექტი</param>
        /// <param name="sortExpressions">სორტირების პირობების ლისტი List<Tuple<string, int, SortDirection>> 
        /// სადაც Tuple-ის პირველი პარამეტრი არის ველის სახელი, მეორე პარამეტრი არის დახარისხების დროს ველის პრიორიტეტი (1, 2, 3, ...)
        /// და მესამე პარამეტრი არის დახარისხების პირობა</param>
        /// <returns>IQueryable<T> ტიპის ობიექტი</returns>
        public static IQueryable<T> MultipleSort<T>(this IQueryable<T> data, List<Tuple<string, int, SortDirection>> sortExpressions)
        {
            if ((sortExpressions == null) || (sortExpressions.Count <= 0))
            {
                return data;
            }
            IQueryable<T> result = from item in data select item;
            foreach (Tuple<string, int, SortDirection> sortExpression in sortExpressions.OrderBy(x => x.Item2))
            {
                result = OrderingGeneratior(result, sortExpression);
            }
            return result;
        }

        private static IOrderedQueryable<T> OrderingGeneratior<T>(IQueryable<T> query, Tuple<string, int, SortDirection> sortExpression)
        {
            IOrderedQueryable<T> result = null;
            string method = (sortExpression.Item2 == 1 ? "OrderBy" : "ThenBy") + (sortExpression.Item3 == SortDirection.Descending ? "Descending" : string.Empty);
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "FieldName");
            MemberExpression memberExpression = Expression.PropertyOrField(parameterExpression, sortExpression.Item1);
            LambdaExpression sort = Expression.Lambda(memberExpression, parameterExpression);
            UnaryExpression unaryExpression = Expression.Quote(sort);
            Type[] typeArguments = new Type[] { typeof(T), memberExpression.Type };
            MethodCallExpression methodCallExpression = Expression.Call(typeof(Queryable), method, typeArguments, query.Expression, unaryExpression);
            result = (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(methodCallExpression);
            return result;
        }
    }
}