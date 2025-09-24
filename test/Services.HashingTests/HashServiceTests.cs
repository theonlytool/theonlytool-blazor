using System.Security.Cryptography;
using Services.Hashing;
using Services.Hashing.Strategy;

namespace Services.HashingTests;

public partial class HashServiceTests
{
    private static string CalculateExpectedHash(byte[] input, SupportedHash algorithm)
    {
        return algorithm switch
        {
            SupportedHash.MD5 => Convert.ToHexStringLower(MD5.HashData(input)),
            SupportedHash.SHA1 => Convert.ToHexStringLower(SHA1.HashData(input)),
            SupportedHash.SHA256 => Convert.ToHexStringLower(SHA256.HashData(input)),
            SupportedHash.SHA384 => Convert.ToHexStringLower(SHA384.HashData(input)),
            SupportedHash.SHA512 => Convert.ToHexStringLower(SHA512.HashData(input)),
            _ => throw new ArgumentException("Unsupported hash algorithm")
        };
    }

    private static IHashService CreateHashService()
    {
        var hashProcessors = new IHashProcessor<SupportedHash>[]
        {
            new Md5Processor(),
            new Sha1Processor(),
            new Sha256Processor(),
            new Sha384Processor(),
            new Sha512Processor()
        };
        return new HashService(hashProcessors);
    }
}