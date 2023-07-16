using System.Security.Cryptography;
using System.Text;

namespace BlockNet.Core.Helpers;

internal static class CryptoHelper
{
    internal static string GetSha256(string text)
    {
        var b = Encoding.Default.GetBytes(text);

        using SHA256 calculator = SHA256.Create();
        var c = calculator.ComputeHash(b);

        var stringBuilder = new StringBuilder();

        foreach (var t in c)
        {
            stringBuilder.Append($"{t:X2}");
        }

        return stringBuilder.ToString();
    }
}