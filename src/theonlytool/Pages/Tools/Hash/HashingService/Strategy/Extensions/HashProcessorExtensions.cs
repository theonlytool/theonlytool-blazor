using System.Text;

namespace theonlytool.Pages.Tools.Hash.HashingService.Strategy.Extensions;

public static class HashProcessorExtensions
{
    public static string Calculate(this IHashProcessor<SupportedHash> processor, string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        return processor.Calculate(bytes);
    }
}