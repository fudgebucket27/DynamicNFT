# DynamicNFT
This is a ASP.NET Core Web API that I will be using to host my dynamic NFTs. So far it has one endpoint which returns weather data. This is actually generates pseudo dynamic NFTs as the API sits on a centralized server. But in the end even smart contract oracles point to centralized APIs to get their data. See https://medium.com/bandprotocol/smart-contract-oracles-and-price-feed-centralization-e74dfa8695af . This API was much easier to develop then learning Solidity to interact with an oracle... It would be ideal if I could host this API on IPFS, maybe one day.

The weather endpoint needs an api key that is stored as an environment variable that you set yourself, which you can get for free from https://www.weatherapi.com/. The weather endpoint can be hit as follows https://yourHostUrlHere/api/NFT/Weather?city=Townsville where city can be any city you choose.

If you are adding images within the solution to use in the code you need to make sure the 'Copy on always' is set.

After you have setup the API and is hosted somewhere. All you need is the IPFS CID of the metadata.json file to be generated correctly on Loopring specifications so that you can mint it. The metadata.json file should look similar to below with whatever extra api endpoints you make yourself in the image property. My API is hosted on a linux app service on Azure. You just need a host that can deploy ASP.NET Core Web APIs.

```json
{
	"name" : "Fudgey's Dynamic NFT #3",
	"description": "Dynamic NFTs are fun!",
	"image" : "https://yourHostUrlHere/api/NFT/Weather"
}
```

Fork and do what you will with it!
