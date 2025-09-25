namespace Services.Url;

public class UrlService
{
    public string Encode(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        
        var uri = new Uri(url);

        return uri.AbsoluteUri;
    }
    
    public string Decode(string encodedUrl)
    {
        ArgumentNullException.ThrowIfNull(encodedUrl);
        
        var uri = new Uri(encodedUrl);

        return uri.ToString();
    }
}
