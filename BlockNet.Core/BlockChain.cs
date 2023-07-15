namespace BlockNet.Core;

public sealed class BlockChain<T>
{
    public List<Block<T>>? Chain { get; set; }
    public int Difficulty { get; set; }

    public int BlockTimeMs { get; set; }

    public BlockChain(int difficulty = 1, int blockTimeMs = 0)
    {
        Difficulty = difficulty;
        BlockTimeMs = blockTimeMs;
        Chain = new List<Block<T>>()
        {
            Block<T>.Create(new List<T>())
        };
    }

    private Block<T>? GetLastBlock()
    {
        return Chain?.LastOrDefault();
    }

    public void AddBlock(Block<T> block)
    {
        block.PreviousHash = GetLastBlock()?.Hash;
        block.Hash = block.GetHash();
        block.Mine(Difficulty);
        Chain?.Add(block);

        if (BlockTimeMs > 0)
        {
            Difficulty += new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds() - GetLastBlock()?.TimeStamp < BlockTimeMs ? 1 : -1;
        }
    }

    public bool IsValid()
    {
        for (var i = 1; i < Chain?.Count; i++) {
            var currentBlock = Chain?[i];
            var prevBlock = Chain?[i-1];

            if (currentBlock?.Hash != currentBlock?.GetHash() || prevBlock?.Hash != currentBlock?.PreviousHash) {
                return false;
            }
        }

        return true;
    }
}