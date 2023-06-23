using System.Linq.Expressions;

public static class QueryableEx
{
    public static IQueryable<T> Where<T>(
        this IQueryable<T> @this,
        bool condition,
        Expression<Func<T, bool>> @where)
    {
        return condition ? @this.Where(@where) : @this;
    }
}

