using Services.Base64;

namespace theonlytool.Pages.Tools.Base64;

public partial class Base64Tool(Base64Service base64Service)
{
    public bool Encode { get; set; } = true;
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
    
    private void UpdateOutput(string newValue)
    {
        Input = newValue;
        Output = Encode ? base64Service.Encode(Input) : base64Service.Decode(Input);
    }
}