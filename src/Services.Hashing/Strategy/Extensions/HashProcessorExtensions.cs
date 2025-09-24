using System.Text;

namespace Services.Hashing.Strategy.Extensions;

public static class HashProcessorExtensions
{
    public static string Calculate(this IHashProcessor<SupportedHash> processor, string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        return processor.Calculate(bytes);
    }
}