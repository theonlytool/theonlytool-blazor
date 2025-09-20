using System.Text;

namespace theonlytool.Pages.Tools.Base64;

public class Base64Service
{
    public string Encode(string input)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
    }

    public string Decode(string input)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(input));
    }
}