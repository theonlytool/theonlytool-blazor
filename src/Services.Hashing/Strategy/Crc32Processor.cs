using System.IO.Hashing;

namespace Services.Hashing.Strategy;

public class Crc32Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.CRC32;

    public string Calculate(byte[] data)
    {
        var computeHash = Crc32.HashToUInt32(data);
        return computeHash.ToString();
    }
}
