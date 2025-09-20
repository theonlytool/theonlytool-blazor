using System.Text;

namespace theonlytool.Pages.Tools.Base64;

public partial class Base64Tool
{
    public bool Encode { get; set; } = true;
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    private static string EncodeBase64(string input)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
    }

    private static string DecodeBase64(string input)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(input));
    }

    private void UpdateOutput(string newValue)
    {
        Input = newValue;
        Output = Encode ? EncodeBase64(Input) : DecodeBase64(Input);
    }
}