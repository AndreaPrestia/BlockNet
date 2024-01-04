# BlockNet
This is a Blockchain example totally written in .NET. I use it for study purposes :) 


**How to use it?**
You can launch the **BlockNet.Test.Console** project , it contains a console application referenced to the main **BlockNet.Core** part.

There are 3 test methods:

- GenerateBlockChainWithoutParameters
- GenerateBlockChainWithDifficulty
- GenerateBlockChainWithBlockTime

They print the results in the application console.

***GenerateBlockChainWithoutParameters***
It generates a blockchain with a **difficulty** of 1, no blocktime.
It's quite fast, it generates a little nonce, i think it can run good on every machine :) 

***GenerateBlockChainWithDifficulty***
It generates a blockchain with a **difficulty** of N, no blocktime.
Now the value is set to 5.

***GenerateBlockChainWithBlockTime***
It uses the blocktime (in MS) to verify the transaction.
Now it is set at 30 seconds (30000 ms).
It is used as in mining for crypto.

**TODO**
- Better code
- Unit tests containing the valid/invalid demonstration

