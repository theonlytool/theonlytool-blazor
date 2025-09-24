using System.Security.Cryptography;
using System.Text;
using AwesomeAssertions;
using Services.Hashing;

namespace TheOnlyToolTests;

[TestFixture]
public class Md5BrowserHashTests
{
    private static string CalculateExpectedHash(byte[] input)
    {
        var hash = MD5.HashData(input);
        return Convert.ToHexStringLower(hash);
    }

    [Test]
    public void Md5BrowserHashCalculate_EmptyInput_ReturnsCorrectHash()
    {
        // Arrange
        var emptyInput = Array.Empty<byte>();

        // Act
        var emptyHash = Md5BrowserHash.Calculate(emptyInput);

        // Assert
        var expectedHash = CalculateExpectedHash(emptyInput);
        emptyHash.Should().Be(expectedHash);
    }

    [Test]
    public void Md5BrowserHashCalculate_KnownInput_ReturnsCorrectHash()
    {
        // Arrange
        var knownInput = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog");

        // Act
        var knownHash = Md5BrowserHash.Calculate(knownInput);

        // Assert
        var expectedHash = CalculateExpectedHash(knownInput);
        knownHash.Should().Be(expectedHash);
    }

    [Test]
    public void Md5BrowserHashCalculate_DifferentInput_ReturnsCorrectHash()
    {
        // Arrange
        var differentInput = Encoding.UTF8.GetBytes("Hello, world!");

        // Act
        var differentHash = Md5BrowserHash.Calculate(differentInput);

        // Assert
        var expectedHash = CalculateExpectedHash(differentInput);
        differentHash.Should().Be(expectedHash);
    }

    [Test]
    public void Md5BrowserHashCalculate_LargeInput_ReturnsCorrectHash()
    {
        // Arrange
        var largeInput = new byte[1024 * 1024]; // 1MB
        var rand = new Random();
        rand.NextBytes(largeInput);

        // Act
        var largeHash = Md5BrowserHash.Calculate(largeInput);

        // Assert
        var expectedHash = CalculateExpectedHash(largeInput);
        largeHash.Should().Be(expectedHash);
    }

    [Test]
    public void Md5BrowserHashCalculate_SingleByteInput_ReturnsCorrectHash()
    {
        // Arrange
        var singleByteInput = new byte[] { 0x01 };

        // Act
        var singleByteHash = Md5BrowserHash.Calculate(singleByteInput);

        // Assert
        var expectedHash = CalculateExpectedHash(singleByteInput);
        singleByteHash.Should().Be(expectedHash);
    }

    [Test]
    public void Md5BrowserHashCalculate_SpecificInput_ReturnsCorrectHash()
    {
        // Arrange
        var input = Encoding.UTF8.GetBytes("test");

        // Act
        var calculatedHash = Md5BrowserHash.Calculate(input);
        var expectedHash = CalculateExpectedHash(input);

        // Assert
        calculatedHash.Should().Be(expectedHash);
    }
}
