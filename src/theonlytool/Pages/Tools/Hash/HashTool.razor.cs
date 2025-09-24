using Microsoft.AspNetCore.Components;
using theonlytool.Pages.Tools.Hash.HashingService;

namespace theonlytool.Pages.Tools.Hash;

public partial class HashTool(IHashService hashService) : ComponentBase
{
    private static SupportedHash[] SupportedHashes { get; } =
        Enum.GetValues<SupportedHash>();

    public string Input { get; set; } = string.Empty;

    public List<Tuple<string, string>> Hashes { get; set; } = [];
    
    public void CalculateHashes(string input)
    {
        if (string.IsNullOrEmpty(input) && Hashes.Count > 0)
        {
            Hashes = [];
            return;
        }
        
        var hashes = new List<Tuple<string, string>>(SupportedHashes.Length);
        
        foreach (var hashType in SupportedHashes)
        {
            hashes.Add(new Tuple<string, string>(hashType.ToString(), hashService.ComputeHash(Input, hashType)));
        }

        Hashes = hashes;
    }
}
