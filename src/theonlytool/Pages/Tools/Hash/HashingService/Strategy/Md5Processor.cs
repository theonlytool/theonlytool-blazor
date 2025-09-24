namespace theonlytool.Pages.Tools.Hash.HashingService.Strategy;

public class Md5Processor : IHashProcessor<SupportedHash>
{
    public SupportedHash HashAlgorithm => SupportedHash.MD5;

    public string Calculate(byte[] data)
    {
        return Md5BrowserHash.Calculate(data);
    }
}