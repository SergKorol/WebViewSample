namespace WebViewSample.Models;

public record WebSiteModel
{
    public Uri Url { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
}