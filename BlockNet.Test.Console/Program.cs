// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using BlockNet.Core;

GenerateBlockChainWithoutParameters();
GenerateBlockChainWithDifficulty(5);
GenerateBlockChainWithBlockTime(30000);

void GenerateBlockChainWithoutParameters()
{
    Console.WriteLine("GenerateBlockChainWithoutParameters:");
    GenerateBlockChain();
}

void GenerateBlockChainWithDifficulty(int difficulty)
{
    Console.WriteLine("GenerateBlockChainWithDifficulty:");
    GenerateBlockChain(difficulty);
}

void GenerateBlockChainWithBlockTime(int blockTimeMs)
{
    Console.WriteLine("GenerateBlockChainWithBlockTime:");
    GenerateBlockChain(blockTimeMs: blockTimeMs);
}

void GenerateBlockChain(int difficulty = 1, int blockTimeMs = 0)
{
    var blockChain = new BlockChain<TestTransaction>(difficulty, blockTimeMs);

    blockChain.AddBlock(Block<TestTransaction>.Create(new List<TestTransaction>()
    {
        new TestTransaction("Bob", "Joe", 100)
    }));
    
    blockChain.AddBlock(Block<TestTransaction>.Create(new List<TestTransaction>()
    {
        new TestTransaction("Joe", "Jim", 50)
    }));
    
    blockChain.AddBlock(Block<TestTransaction>.Create(new List<TestTransaction>()
    {
        new TestTransaction("Frank", "Joe", 150)
    }));
    
    var json = JsonSerializer.Serialize(blockChain);

    Console.WriteLine($"Is valid? {blockChain.IsValid()}");
    Console.WriteLine(json);
}

record TestTransaction(string? From, string? To, int Amount);