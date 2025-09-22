using System.Text;

namespace theonlytool.Pages.Tools.Base64;

public static class Base64Helper
{
    public static bool TryDecodeBase64(string input, out string decodedText)
    {
        decodedText = string.Empty;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        // Quick check: Base64 length must be multiple of 4
        if (input.Length % 4 != 0)
        {
            return false;
        }

        try
        {
            var bytes = Convert.FromBase64String(input);

            // Ensure it can be decoded as UTF-8 text
            decodedText = Encoding.UTF8.GetString(bytes);

            return true;
        }
        catch (FormatException)
        {
            // Input wasn't valid Base64
            return false;
        }
        catch (DecoderFallbackException)
        {
            // Decoded bytes weren't valid UTF-8 text
            return false;
        }
    }
}