using Microsoft.AspNetCore.Components;
using Services.Url;

namespace theonlytool.Pages.Tools.Url;

public partial class Url(UrlService urlEncode) : ComponentBase
{
    public bool Encode { get; set; } = true;
    public string Input { get; set; }
    public string Output { get; set; }

    private void UpdateOutput(string newValue)
    {
        Input = newValue;

        Output = Encode ? urlEncode.Encode(Input) : urlEncode.Decode(Input);
    }
}