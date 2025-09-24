using Services.Base64;
using AwesomeAssertions;

namespace Services.Base64Tests
{
    public class Base64HelperTests
    {
        [Test]
        public void TryDecodeBase64_ValidInput_ReturnsTrueAndDecodedText()
        {
            // Arrange
            const string input = "SGVsbG8sIFdvcmxkIQ=="; // "Hello, World!" in Base64
            const string expected = "Hello, World!";

            // Act
            var result = Base64Helper.TryDecodeBase64(input, out var decodedText);

            // Assert
            result.Should().BeTrue();
            decodedText.Should().Be(expected);
        }

        [Test]
        public void TryDecodeBase64_InvalidBase64_ReturnsFalse()
        {
            // Arrange
            const string invalidBase64 = "This is not a valid Base64 string";

            // Act
            var result = Base64Helper.TryDecodeBase64(invalidBase64, out _);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void TryDecodeBase64_EmptyString_ReturnsFalse()
        {
            // Arrange
            var emptyString = string.Empty;

            // Act
            var result = Base64Helper.TryDecodeBase64(emptyString, out _);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void TryDecodeBase64_NullString_ReturnsFalse()
        {
            // Arrange
            string? nullString = null;

            // Act
            var result = Base64Helper.TryDecodeBase64(nullString!, out _);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void TryDecodeBase64_NotMultipleOf4_ReturnsFalse()
        {
            // Arrange
            const string notMultipleOf4 = "SGVsbG8"; // Not a multiple of 4 in length and not valid Base64

            // Act
            var result = Base64Helper.TryDecodeBase64(notMultipleOf4, out _);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void TryDecodeBase64_NonUtf8Content_ReturnsFalse()
        {
            // Arrange
            // This is a Base64 string that decodes to non-UTF8 bytes
            const string nonUtf8Base64 = "803";

            // Act
            var result = Base64Helper.TryDecodeBase64(nonUtf8Base64, out _);

            // Assert
            result.Should().BeFalse();
        }
    }
}
