using AwesomeAssertions;
using Services.Url;

namespace Services.UrlTests;

public class UrlServiceTests
{
    private UrlService _urlService;

    [SetUp]
    public void Setup()
    {
        _urlService = new UrlService();
    }

    [Test]
    public void Encode_WithNullUrl_ShouldThrowArgumentNullException()
    {
        // Arrange & Act
        var action = () => _urlService.Encode(null);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }


    [Test]
    public void Encode_WithSpaceAsUrlPathTrue_ShouldUrlPathEncode()
    {
        // Arrange
        const string input = "https://example.com/path with spaces";

        // Act
        var result = _urlService.Encode(input);

        // Assert
        result.Should().Be("https://example.com/path%20with%20spaces");
    }

    [Test]
    public void Encode_WithInvalidUrl_ShouldReturnErrorMessage()
    {
        // Arrange
        const string input = "invalid]";

        // Act
        var result = _urlService.Encode(input);

        // Assert
        result.Should().Be("The Input is not a valid URL string.");
    }


    [Test]
    public void Decode_WithNullUrl_ShouldThrowArgumentNullException()
    {
        // Arrange & Act
        var action = () => _urlService.Decode(null);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Decode_WithSpaceAsUrlPathTrue_ShouldUrlPathEncode()
    {
        // Arrange
        const string input = "https://example.com/path%20with%20spaces";

        // Act
        var result = _urlService.Decode(input);

        // Assert
        result.Should().Be("https://example.com/path with spaces");
    }

    [Test]
    public void Decode_WithInvalidUrl_ShouldReturnErrorMessage()
    {
        // Arrange
        const string input = "invalid]";

        // Act
        var result = _urlService.Decode(input);

        // Assert
        result.Should().Be("The Input is not a valid URL string.");
    }
}