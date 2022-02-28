# DynamicNFT
This is a ASP.NET Core Web API that I will be using to host my dynamic NFTs. So far it has one endpoint which returns weather data for my city Townsville. This is actually a pseudo dynamic NFT as the API sits on a centralized server. But in the end even smart contract oracles point to centralized APIs to get their data. See https://medium.com/bandprotocol/smart-contract-oracles-and-price-feed-centralization-e74dfa8695af . This API was much easier to develop then learning Solidity to interact with an oracle... It would be ideal if I could host this API on IPFS, maybe one day.

So all you need is the CID of this metadata.json file to be minted correctly on Loopring, similar to below. Remember to point the image of the url to where you are hosting this API yourself. My API is hosted on a linux app service on Azure. You just need a host that can deploy ASP.NET Core Web APIs. The api key is stored as an environmentable variable that you set yourself. Also if you are adding images within the solution to use in the code you need to make sure the 'Copy on always' is set.

```json
{
	"name" : "Fudgey's Dynamic NFT #3",
	"description": "Dynamic NFTs are fun!",
	"image" : "https://dynamicnft.azurewebsites.net/api/NFT/Weather"
}
```

Fork and do what you will with it!
