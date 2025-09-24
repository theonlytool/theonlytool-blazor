using System.Text;
using AwesomeAssertions;
using Services.Hashing;

namespace Services.HashingTests
{
    [TestFixture]
    public partial class HashServiceTests
    {
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
    }
}
