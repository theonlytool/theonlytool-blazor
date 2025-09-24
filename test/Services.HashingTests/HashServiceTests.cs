using System.Security.Cryptography;
using System.Text;
using AwesomeAssertions;
using Services.Hashing;
using Services.Hashing.Strategy;

namespace Services.HashingTests
{
    [TestFixture]
    public class HashServiceTests
    {
        [Test]
        public void ComputeHash_ByteArrayInput_ReturnsCorrectHash()
        {
            // Arrange
            var hashService = CreateHashService();
            var input = Encoding.UTF8.GetBytes("test");
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act
            var hash = hashService.ComputeHash(input, algorithm);

            // Assert
            var expectedHash = CalculateExpectedHash(input, algorithm);
            hash.Should().Be(expectedHash);
        }

        [Test]
        public void ComputeHash_StringInput_ReturnsCorrectHash()
        {
            // Arrange
            var hashService = CreateHashService();
            const string input = "test";
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act
            var hash = hashService.ComputeHash(input, algorithm);

            // Assert
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm);
            hash.Should().Be(expectedHash);
        }

        [Test]
        public void VerifyHash_ByteArrayInput_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            var input = Encoding.UTF8.GetBytes("test");
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(input, algorithm);

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void VerifyHash_StringInput_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            const string input = "test";
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm);

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void VerifyHash_ByteArrayInputWithDifferentHash_ReturnsFalse()
        {
            // Arrange
            var hashService = CreateHashService();
            var input = Encoding.UTF8.GetBytes("test");
            const SupportedHash algorithm = SupportedHash.MD5;
            const string wrongHash = "wrongHash";

            // Act
            var result = hashService.VerifyHash(input, wrongHash, algorithm);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void VerifyHash_StringInputWithDifferentHash_ReturnsFalse()
        {
            // Arrange
            var hashService = CreateHashService();
            const string input = "test";
            const SupportedHash algorithm = SupportedHash.MD5;
            const string wrongHash = "wrongHash";

            // Act
            var result = hashService.VerifyHash(input, wrongHash, algorithm);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void VerifyHash_ByteArrayInputWithUpperCaseHash_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            var input = Encoding.UTF8.GetBytes("test");
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(input, algorithm).ToUpper();

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void VerifyHash_StringInputWithUpperCaseHash_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            const string input = "test";
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm).ToUpper();

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void VerifyHash_ByteArrayInputWithLowerCaseHash_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            var input = Encoding.UTF8.GetBytes("test");
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(input, algorithm).ToLower();

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void VerifyHash_StringInputWithLowerCaseHash_ReturnsTrue()
        {
            // Arrange
            var hashService = CreateHashService();
            const string input = "test";
            const SupportedHash algorithm = SupportedHash.MD5;
            var expectedHash = CalculateExpectedHash(Encoding.UTF8.GetBytes(input), algorithm).ToLower();

            // Act
            var result = hashService.VerifyHash(input, expectedHash, algorithm);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase(SupportedHash.MD5, "test")]
        [TestCase(SupportedHash.SHA1, "test")]
        [TestCase(SupportedHash.SHA256, "test")]
        [TestCase(SupportedHash.SHA384, "test")]
        [TestCase(SupportedHash.SHA512, "test")]
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
        public void VerifyHash_StringInput_AllAlgorithms_WithDifferentHash_ReturnsFalse(SupportedHash algorithm, string input, string wrongHash)
        {
            // Arrange
            var hashService = CreateHashService();

            // Act
            var result = hashService.VerifyHash(input, wrongHash, algorithm);

            // Assert
            result.Should().BeFalse();
        }

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
}
