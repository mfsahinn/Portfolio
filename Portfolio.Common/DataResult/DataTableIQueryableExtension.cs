using System.Linq.Expressions;
using System.Reflection;

namespace Portfolio.Common.DataResult;

public static class DataTableIQueryableExtension
{
      public static PagingResult<T> Prepare2DataTablePagingResult<T>(this IQueryable<T> query, DataTableRequest dataTableRequest, string message)
        {
            IQueryable<T> filteredQuery = query.Where(dataTableRequest).Sort(dataTableRequest); ;
            List<T?> dataList = filteredQuery.ToList<T?>();
            PagingResult<T> pageResult = new PagingResult<T>();
            pageResult.Status = true;
            pageResult.Messages = new string[] { message };
            pageResult.TotalRecordCount = query.Count();
            pageResult.FilteredRecordCount = filteredQuery.Count();
            pageResult.Data = filteredQuery.Sort(dataTableRequest).Skip(dataTableRequest.Start < 0 ? 0 : dataTableRequest.Start).Take(dataTableRequest.Length <= 0 ? int.MaxValue : dataTableRequest.Length).ToList<T?>();
            pageResult.RequestId = dataTableRequest.Draw;
            return pageResult;
        }


         private static IQueryable<T> Where<T>(this IQueryable<T> query, DataTableRequest dataTableRequest)
        {
            if (!string.IsNullOrEmpty(dataTableRequest.Search?.Value))
            {
                Expression<Func<T, bool>> expression = x => 1 == 0;
                Expression<Func<T, bool>> expressionTrue = x => 1 == 1;

                if (dataTableRequest.Columns != null)
                {
                    var type = typeof(T);

                    foreach (Column column in dataTableRequest.Columns)
                    {
                        if (column.Data == null)
                            continue;
                        var parameterExp = Expression.Parameter(typeof(T), "type");
                        var propertyExp = Expression.Property(parameterExp, column.Data);

                        if (propertyExp.Type != typeof(string))
                            continue;

                        MethodInfo? lowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                        var lowerMethodExp = Expression.Call(propertyExp, lowerMethod);

                        MethodInfo? method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var someValue = Expression.Constant(dataTableRequest.Search.Value.ToLower(), typeof(string));
                        var containsMethodExp = Expression.Call(lowerMethodExp, method, someValue);

                        Expression<Func<T, bool>> subExpression = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);

                        var param = Expression.Parameter(typeof(T), "x");
                        var body = Expression.Or(
                                Expression.Invoke(subExpression, param),
                                Expression.Invoke(expression, param)
                            );
                        expression = Expression.Lambda<Func<T, bool>>(body, param);
                    }

                    var param1 = Expression.Parameter(typeof(T), "x");
                    var body1 = Expression.And(
                            Expression.Invoke(expression, param1),
                            Expression.Invoke(expressionTrue, param1)
                        );
                    expression = Expression.Lambda<Func<T, bool>>(body1, param1);
                }

                query = query.Where(expression);
            }
            return query;
        }

         private static IQueryable<T> Sort<T>(this IQueryable<T> query, DataTableRequest dataTableRequest)
        {
            if (dataTableRequest.Order != null)
            {
                foreach (Order order in dataTableRequest.Order)
                {
                    if (dataTableRequest.Columns?[order.Column].Data == null)
                        continue;
                    switch (order.Dir)
                    {
                        case "asc":
                            query = query.OrderBy(dataTableRequest.Columns[order.Column].Data!, false);
                            break;
                        case "desc":
                            query = query.OrderBy(dataTableRequest.Columns[order.Column].Data!, true);
                            break;
                        default:
                            query = query.OrderBy(dataTableRequest.Columns[order.Column].Data!, false);
                            break;
                    }
                }
            }
            return query;
        }

        private static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
        }
}
