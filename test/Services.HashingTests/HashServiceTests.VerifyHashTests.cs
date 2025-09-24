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

        [Test]
        public void VerifyHash_NullStringInputInStringOverload_ThrowsArgumentNullException()
        {
            // Arrange
            var hashService = CreateHashService();
            string text = null!;
            const string expectedHexHash = "test";
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act & Assert
            var execute = () => hashService.VerifyHash(text, expectedHexHash, algorithm);
            execute.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void VerifyHash_NullExpectedHexHashInStringOverload_ThrowsArgumentNullException()
        {
            // Arrange
            var hashService = CreateHashService();
            const string text = "test";
            string expectedHexHash = null!;
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act & Assert
            var execute = () => hashService.VerifyHash(text, expectedHexHash, algorithm);
            execute.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void VerifyHash_NullStringInputInByteOverload_ThrowsArgumentNullException()
        {
            // Arrange
            var hashService = CreateHashService();
            byte[] data = null!;
            const string expectedHexHash = "test";
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act & Assert
            var execute = () => hashService.VerifyHash(data, expectedHexHash, algorithm);
            execute.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void VerifyHash_NullExpectedHexHashInByteOverload_ThrowsArgumentNullException()
        {
            // Arrange
            var hashService = CreateHashService();
            var data = Encoding.UTF8.GetBytes("test");
            string expectedHexHash = null!;
            const SupportedHash algorithm = SupportedHash.MD5;

            // Act & Assert
            var execute = () => hashService.VerifyHash(data, expectedHexHash, algorithm);
            execute.Should().Throw<ArgumentNullException>();
        }
    }
}
