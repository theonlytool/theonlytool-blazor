using Services.Base64;
using AwesomeAssertions;

namespace Services.Base64Tests
{
    public class Base64ServiceTests
    {
        private readonly Base64Service _base64Service;

        public Base64ServiceTests()
        {
            _base64Service = new Base64Service();
        }

        [Test]
        public void Encode_ValidInput_ReturnsBase64String()
        {
            // Arrange
            const string input = "Hello, World!";
            var expected = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));

            // Act
            var result = _base64Service.Encode(input);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Encode_EmptyInput_ReturnsEmptyBase64String()
        {
            // Arrange
            var input = string.Empty;
            var expected = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));

            // Act
            var result = _base64Service.Encode(input);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Encode_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            var execute = () => _base64Service.Encode(null!);
            
            // Act & Assert
            execute.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Decode_ValidBase64String_ReturnsOriginalString()
        {
            // Arrange
            const string original = "Hello, World!";
            var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(original));

            // Act
            var result = _base64Service.Decode(base64);

            // Assert
            result.Should().Be(original);
        }

        [Test]
        public void Decode_InvalidBase64String_ReturnsErrorMessage()
        {
            // Arrange
            var invalidBase64 = "This is not a valid Base64 string";

            // Act
            var result = _base64Service.Decode(invalidBase64);

            // Assert
            result.Should().Be("The Input is not a valid Base64 string.");
        }

        [Test]
        public void Decode_EmptyBase64String_ReturnsErrorMessage()
        {
            // Arrange
            var emptyBase64 = string.Empty;

            // Act
            var result = _base64Service.Decode(emptyBase64);

            // Assert
            result.Should().Be("The Input is not a valid Base64 string.");
        }

        [Test]
        public void Decode_NullBase64String_ReturnsErrorMessage()
        {
            // Act
            var result = _base64Service.Decode(null!);

            // Assert
            result.Should().Be("The Input is not a valid Base64 string.");
        }
    }
}
