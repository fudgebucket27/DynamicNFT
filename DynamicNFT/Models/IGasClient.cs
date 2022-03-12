namespace DynamicNFT.Models
{
    public interface IGasClient
    {
        Task<Gas> GetGas();
    }
}
