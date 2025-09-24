namespace Services.Hashing;

public interface IHashService
{
    string ComputeHash(byte[] data, SupportedHash algorithm);
    string ComputeHash(string text, SupportedHash algorithm);
    bool VerifyHash(byte[] data, string expectedHexHash, SupportedHash algorithm);
    bool VerifyHash(string text, string expectedHexHash, SupportedHash algorithm);
}