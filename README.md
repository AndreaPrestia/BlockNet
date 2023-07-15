# BlockNet
This is a Blockchain example written in .NET. I use it for study purposes :) 


**How to use it?**
You can launch the **BlockNet.Test.Console** project , it contains a console application referenced to the main **BlockNet.Core** part.

There are 3 test methods:

- GenerateBlockChainWithoutParameters
- GenerateBlockChainWithDifficulty
- GenerateBlockChainWithBlockTime

The print the results in the application console.

***GenerateBlockChainWithoutParameters***
It generate a blockchains with a **difficulty** of 1, no blocktime.
It's quite fast, it generates a little nonce, i think it can run good on every machine :) 

***GenerateBlockChainWithDifficulty***
It generate a blockchains with a **difficulty** of N, no blocktime.
Now the value set is 5.

***GenerateBlockChainWithBlockTime***
It uses the blocktime (in MS) to verify the transaction.
Now it is set at 30 seconds (30000 ms).
It is used as in mining for crypto.

**TODO**
- Write a better code
- Unit tests containing the valid/invalid demonstration

