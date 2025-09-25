namespace Services.Url;

public class UrlService
{
    public string Encode(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        
        try
        {
            var uri = new Uri(url);

            return uri.AbsoluteUri;
        }
        catch (UriFormatException)
        {
            return "The Input is not a valid URL string.";
        }
    }
    
    public string Decode(string encodedUrl)
    {
        ArgumentNullException.ThrowIfNull(encodedUrl);
        
        try
        {
            var uri = new Uri(encodedUrl);

            return uri.ToString();
        }
        catch (UriFormatException)
        {
            return "The Input is not a valid URL string.";
        }
    }
}
