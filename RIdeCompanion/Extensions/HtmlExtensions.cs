namespace RIdeCompanion.Extensions;

public static class HtmlExtensions
{
    public static string IsActive(this HttpContext httpContext, string url, string className1, string className2)
    {
        return httpContext.Request.Path == url ? className1 : className2;
    }
}