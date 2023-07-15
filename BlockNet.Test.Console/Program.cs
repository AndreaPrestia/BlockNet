// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using BlockNet.Core;

GenerateBlockChainWithoutParameters();
GenerateBlockChainWithDifficulty(5);
GenerateBlockChainWithBlockTime(30000);

void GenerateBlockChainWithoutParameters()
{
    var blockChain = new BlockChain<TestTransaction>();

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

    Console.WriteLine("GenerateBlockChainWithoutParameters:");
    Console.Write($"Is valid? {blockChain.IsValid()}");
    Console.WriteLine(json);
}

void GenerateBlockChainWithDifficulty(int difficulty)
{
    var blockChain = new BlockChain<TestTransaction>(difficulty: difficulty);

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

    Console.WriteLine("GenerateBlockChainWithDifficulty:");
    Console.Write($"Is valid? {blockChain.IsValid()}");
    Console.WriteLine(json);
}

void GenerateBlockChainWithBlockTime(int blockTimeMs)
{
    var blockChain = new BlockChain<TestTransaction>(blockTimeMs: blockTimeMs);

    blockChain.AddBlock(Block<TestTransaction>.Create(new List<TestTransaction>()
    {
        new TestTransaction("Bob", "Joe", 100)
    }));

    var json = JsonSerializer.Serialize(blockChain);

    Console.WriteLine("GenerateBlockChainWithBlockTime:");
    Console.Write($"Is valid? {blockChain.IsValid()}");
    Console.WriteLine(json);
}

record TestTransaction(string? From, string? To, int Amount);