using System.Text;
using AwesomeAssertions;
using Services.Hashing;

namespace Services.HashingTests
{
    [TestFixture]
    public partial class HashServiceTests
    {
        [TestCase(SupportedHash.MD5, "test")]
        [TestCase(SupportedHash.SHA1, "test")]
        [TestCase(SupportedHash.SHA256, "test")]
        [TestCase(SupportedHash.SHA384, "test")]
        [TestCase(SupportedHash.SHA512, "test")]
        [TestCase(SupportedHash.CRC32, "test")]
        public void ComputeHash_StringInput_AllAlgorithms_ReturnsCorrectHash(SupportedHash algorithm, string input)
        {
            // Arrange
            var hashService = CreateHashService();

            // Act
            var hash = hashService.ComputeHash(input, algorithm);

            // Assert
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm);
            hash.Should().BeEquivalentTo(expectedHash);
        }

        [TestCase(SupportedHash.MD5, "test")]
        [TestCase(SupportedHash.SHA1, "test")]
        [TestCase(SupportedHash.SHA256, "test")]
        [TestCase(SupportedHash.SHA384, "test")]
        [TestCase(SupportedHash.SHA512, "test")]
        [TestCase(SupportedHash.CRC32, "test")]
        public void VerifyHash_StringInput_AllAlgorithms_ReturnsTrue(SupportedHash algorithm, string input)
        {
            // Arrange
            var hashService = CreateHashService();
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm);

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase(SupportedHash.MD5, "test", "wrongHash")]
        [TestCase(SupportedHash.SHA1, "test", "wrongHash")]
        [TestCase(SupportedHash.SHA256, "test", "wrongHash")]
        [TestCase(SupportedHash.SHA384, "test", "wrongHash")]
        [TestCase(SupportedHash.SHA512, "test", "wrongHash")]
        [TestCase(SupportedHash.CRC32, "test", "wrongHash")]
        public void VerifyHash_StringInput_AllAlgorithms_WithDifferentHash_ReturnsFalse(SupportedHash algorithm, string input, string wrongHash)
        {
            // Arrange
            var hashService = CreateHashService();

            // Act
            var result = hashService.VerifyHash(input, wrongHash, algorithm);

            // Assert
            result.Should().BeFalse();
        }
    }
}
