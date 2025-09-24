using System.Security.Cryptography;

namespace Services.Hashing.Strategy;

public class Sha256Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.SHA256;

    public string Calculate(byte[] data)
    {
        var computeHash = SHA256.HashData(data);
        return Convert.ToHexString(computeHash);
    }
}