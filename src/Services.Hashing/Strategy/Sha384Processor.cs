using System.Security.Cryptography;

namespace Services.Hashing.Strategy;

public class Sha384Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.SHA384;

    public string Calculate(byte[] data)
    {
        var computeHash = SHA384.HashData(data);
        return Convert.ToHexString(computeHash);
    }
}