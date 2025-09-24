using System.Security.Cryptography;

namespace theonlytool.Pages.Tools.Hash.HashingService.Strategy;

public class Sha1Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.SHA1;

    public string Calculate(byte[] data)
    {
        var computeHash = SHA1.HashData(data);
        return Convert.ToHexString(computeHash);
    }
}