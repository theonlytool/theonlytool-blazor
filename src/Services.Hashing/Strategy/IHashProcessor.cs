
namespace Services.Hashing.Strategy;

public interface IHashProcessor <out T> where T : Enum
{
    T HashAlgorithm { get; }
    
    string Calculate(byte[] data);
}