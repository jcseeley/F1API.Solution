using System;
using F1API.Filters;

public interface IUriService
{
    public Uri GetPageUri(PaginationFilter filter, string route);
}