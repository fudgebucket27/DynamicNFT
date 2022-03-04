namespace DynamicNFT.Models
{
    public interface ISwear
    {
        public List<string> Words { get;}
        public string GetRandomSwear();
    }
}
