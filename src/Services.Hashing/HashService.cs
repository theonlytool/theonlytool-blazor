using Services.Hashing.Strategy;
using Services.Hashing.Strategy.Extensions;

namespace Services.Hashing
{
    public class HashService(IEnumerable<IHashProcessor<SupportedHash>> hashProcessors) : IHashService
    {
        public string ComputeHash(byte[] data, SupportedHash algorithm)
        {
            ArgumentNullException.ThrowIfNull(data);

            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            return hashProcessor.Calculate(data);
        }

        public string ComputeHash(string text, SupportedHash algorithm)
        {
            ArgumentNullException.ThrowIfNull(text);
            
            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            return hashProcessor.Calculate(text);
        }

        public bool VerifyHash(byte[] data, string expectedHexHash, SupportedHash algorithm)
        {
            ArgumentNullException.ThrowIfNull(data);
            ArgumentNullException.ThrowIfNull(expectedHexHash);
            
            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            var hash = hashProcessor.Calculate(data);
            return string.Equals(hash, expectedHexHash, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyHash(string text, string expectedHexHash, SupportedHash algorithm)
        {
            ArgumentNullException.ThrowIfNull(text);
            ArgumentNullException.ThrowIfNull(expectedHexHash);
            
            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            var hash = hashProcessor.Calculate(text);
            return string.Equals(hash, expectedHexHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
