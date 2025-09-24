using theonlytool.Pages.Tools.Hash.HashingService.Strategy;
using theonlytool.Pages.Tools.Hash.HashingService.Strategy.Extensions;

namespace theonlytool.Pages.Tools.Hash.HashingService
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
            ArgumentNullException.ThrowIfNull(expectedHexHash);
            
            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            var hash = hashProcessor.Calculate(data);
            return string.Equals(hash, expectedHexHash, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyHash(string text, string expectedHexHash, SupportedHash algorithm)
        {
            ArgumentNullException.ThrowIfNull(expectedHexHash);
            
            var hashProcessor = hashProcessors.First(x => x.HashAlgorithm == algorithm);
            var hash = hashProcessor.Calculate(text);
            return string.Equals(hash, expectedHexHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
