using System.Text;
using AwesomeAssertions;
using Services.Hashing;

namespace Services.HashingTests
{
    [TestFixture]
    public partial class HashServiceTests
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
            hash.Should().BeEquivalentTo(expectedHash);
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
            hash.Should().BeEquivalentTo(expectedHash);
        }
    }
}
