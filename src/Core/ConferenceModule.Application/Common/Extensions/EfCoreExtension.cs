using ConferenceModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Common.Extensions;

public static class EfCoreExtension {
    public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        where T : class {
        var result = new PagedResult<T> {
            CurrentPage = pageIndex,
            PageSize = pageSize,
            RowCount = query.Count()
        };

        var pageCount = (double) result.RowCount / pageSize;
        result.PageCount = (int) Math.Ceiling(pageCount);

        var skip = (pageIndex - 1) * pageSize;
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();
        return result;
    }
}