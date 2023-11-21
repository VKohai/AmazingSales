namespace AmazingSales.Application.Extensions;

public static class PaginatedCollectionExtension
{
    public static IEnumerable<T> ToPaginatedCollection<T>(
        this IQueryable<T> source,
        int count,
        int offset
        )
    {
        count = count <= 0 ? 1 : count;
        offset = offset < 0 ? 0 : offset;
        return source.Skip(offset).Take(count);
    }
}