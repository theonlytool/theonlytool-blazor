using System.Text;

namespace theonlytool.Pages.Tools.Base64;

public class Base64Service
{
    public string Encode(string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

    public string Decode(string input) => Base64Helper.TryDecodeBase64(input, out var decodedText)
        ? decodedText
        : "The Input is not a valid Base64 string.";
}