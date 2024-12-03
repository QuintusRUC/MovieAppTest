using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public BaseController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
    }

    /// <summary>
    /// Generates a full URL for a named route with the provided arguments.
    /// </summary>
    protected string? GetUrl(string linkName, object args)
    {
        return _linkGenerator.GetUriByName(HttpContext, linkName, args);
    }

    /// <summary>
    /// Generates a paginated link for a given route.
    /// </summary>
    protected string? GetLink(string linkName, int page, int pageSize)
    {
        var link = GetUrl(linkName, new { page, pageSize });
        Console.WriteLine($"Generated Link for page {page}: {link}");
        return link;
    }

    /// <summary>
    /// Creates a paginated response for an API.
    /// </summary>
    protected object CreatePaging<T>(string linkName, int page, int pageSize, int total, IEnumerable<T?> items)
    {
        const int MaxPageSize = 25;
        pageSize = Math.Min(pageSize, MaxPageSize); // Enforce a maximum page size.

        var numberOfPages = (int)Math.Ceiling(total / (double)pageSize);

        var curPage = GetLink(linkName, page, pageSize);
        var nextPage = page < numberOfPages - 1 ? GetLink(linkName, page + 1, pageSize) : null;
        var prevPage = page > 0 ? GetLink(linkName, page - 1, pageSize) : null;

        // Debugging pagination
        Console.WriteLine($"Pagination Debug -> Page: {page}, PageSize: {pageSize}, TotalItems: {total}, TotalPages: {numberOfPages}");
        Console.WriteLine($"Current Page: {curPage}, Next Page: {nextPage}, Previous Page: {prevPage}");

        return new
        {
            CurPage = curPage,
            NextPage = nextPage,
            PrevPage = prevPage,
            NumberOfItems = total,
            NumberPages = numberOfPages,
            Items = items
        };
    }
}
