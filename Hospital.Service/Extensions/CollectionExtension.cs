using Hospital.Service.Configurations;

namespace Hospital.Service.Extensions;

public static class CollectionExtension
{
    public static IQueryable<T> ToPaginate<T>(this IQueryable<T> source, PaginationParams @params)
    {
        if (@params.PageIndex > 0 && @params.PageSize > 0)
        {
            source = source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
        }
        return source;
    }
}