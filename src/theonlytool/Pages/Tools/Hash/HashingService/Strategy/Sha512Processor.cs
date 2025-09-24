using System.Security.Cryptography;

namespace theonlytool.Pages.Tools.Hash.HashingService.Strategy;

public class Sha512Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.SHA512;

    public string Calculate(byte[] data)
    {
        var computeHash = SHA512.HashData(data);
        return Convert.ToHexString(computeHash);
    }
}