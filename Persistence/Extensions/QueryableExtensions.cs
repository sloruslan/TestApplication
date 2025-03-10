using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Persistence.Extensions;

public static class QueryableExtensions
{
    public static async Task<List<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int limit, 
        int offset)
    {
        if (limit < 1)
            throw new ArgumentException("Limit cannot be less than 1");

        var data = await source.Skip(offset)
            .Take(limit)
            .ToListAsync();

        return data;
    }

    public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
        string orderDirection)
    {
        return source.OrderBy(orderByProperty, orderDirection.ToLower() == "desc");
    }

    private static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
        bool desc)
    {
        var command = desc ? "OrderByDescending" : "OrderBy";

        var type = typeof(TEntity);
        var properties = type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public |
        BindingFlags.Instance);

        var property = type.GetProperty(orderByProperty);
        if (property == null)
        {
            throw new InvalidOperationException($"Sort.FieldName '{orderByProperty}' property does not exist");
        }

        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);

        var resultExpression = Expression.Call(typeof(Queryable), command, [type, property.PropertyType],
            source.Expression, Expression.Quote(orderByExpression));

        return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
    }

}