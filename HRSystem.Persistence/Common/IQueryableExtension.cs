using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace HRSystem.Persistence.Common
{
    public static class IQueryableExtension
    {

        public static IQueryable<TEntity> WhereContains<TEntity>(this IQueryable<TEntity> query,
                                                                string field,
                                                                string value,
                                                                bool throwExceptionIfNoProperty = false,
                                                                bool throwExceptionIfNoType = false)
            where TEntity : class
        {
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty(field);
            if (propertyInfo != null)
            {
                var typeCode = Type.GetTypeCode(propertyInfo.PropertyType);
                switch (typeCode)
                {
                    case TypeCode.String:
                        return query.Where(String.Format("{0}.Contains(@0)", field), value);
                    case TypeCode.Boolean:
                        var boolValue = (value != null
                            && (value == "1" || value.ToLower() == "true"))
                            ? true
                            : false;
                        return query.Where(String.Format("{0} == @0", field), boolValue);
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        return query.Where(String.Format("{0}.ToString().Contains(@0)", field), value);
                    // todo: DateTime, float, double, decimals, and other types.
                    default:
                        if (throwExceptionIfNoType)
                            throw new NotSupportedException(String.Format("Type '{0}' not supported.", typeCode));
                        break;
                }
            }
            else
            {
                if (throwExceptionIfNoProperty)
                    throw new NotSupportedException(String.Format("Property '{0}' not found.", propertyInfo.Name));
            }
            return query;
        }

        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source,
                                                 string orderBy,
                                                 string orderDirection,
                                                 Dictionary<string, string> mappingDictionaty)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionaty is null)
            {
                throw new ArgumentNullException(nameof(mappingDictionaty));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByString = string.Empty;
            var orderByAfterSplit = orderBy.Split(',');

            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();
                //var orderDescending = trimmedOrderByClause.EndsWith(" desc");                
                var orderDescending = orderDirection.EndsWith("desc");
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ? trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);


                if (!mappingDictionaty.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }

                var propertyMappingValue = mappingDictionaty[propertyName];

                if (propertyMappingValue == null)
                {
                    throw new ArgumentNullException("propertyMappingValue");
                }

                //if (propertyMappingValue == "desc")
                //{
                //    orderDescending = !orderDescending;
                //}

                orderByString = orderByString + (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ") + propertyMappingValue
                                + (orderDescending ? " descending" : " ascending");

            }
            return source.OrderBy(orderByString);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string filterBy,
                                                Dictionary<string, string> mappingDictionaty)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionaty is null)
            {
                throw new ArgumentNullException(nameof(mappingDictionaty));
            }

            if (string.IsNullOrWhiteSpace(filterBy) || filterBy.Contains("null"))
            {
                return source;
            }

            var filterByString = string.Empty;

            foreach (var item in mappingDictionaty.Values)
            {
                filterByString = filterByString +
                    (string.IsNullOrWhiteSpace(filterByString) ? string.Empty : " or ")
                    + $"{item}.Contains(\"{filterBy}\")";
            }

            return source.Where(filterByString);
        }
    }
}
