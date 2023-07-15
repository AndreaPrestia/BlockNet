using System.Text.Json;
using BlockNet.Core.Helpers;

namespace BlockNet.Core;

public sealed class Block<T>
{
    private Block(List<T> transactions)
    {
        TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        Transactions = transactions;
        Hash = GetHash();
    }
    
    public long TimeStamp { get; init; }
    public List<T>? Transactions { get; }
    public string? Hash { get; set; }
    public string? PreviousHash { get; set; } = string.Empty;
    public long Nonce { get; set; }

    public static Block<T> Create(List<T> transactions)
    {
        return new Block<T>(transactions);
    }

    public string? GetHash()
    {
        var jsonData = JsonSerializer.Serialize(Transactions);

        return CryptoHelper.GetSha256($"{PreviousHash}{TimeStamp}{jsonData}{Nonce}");
    }

    public void Mine(int difficulty)
    {
        while (!Hash!.StartsWith(string.Concat(Enumerable.Repeat("0", difficulty + 1)))) {
            Nonce++;
            Hash = GetHash();
        }
    }
}