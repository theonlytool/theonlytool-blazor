using System.Text;

namespace theonlytool.Pages.Tools.Hash.HashingService;

public interface IHashService
{
    string ComputeHash(byte[] data, SupportedHash algorithm);
    string ComputeHash(string text, Encoding? encoding, SupportedHash algorithm);
    bool VerifyHash(byte[] data, string expectedHexHash, SupportedHash algorithm);
    bool VerifyHash(string text, string expectedHexHash, SupportedHash algorithm);
}