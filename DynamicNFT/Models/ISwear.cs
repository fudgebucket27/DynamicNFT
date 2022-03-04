namespace DynamicNFT.Models
{
    public interface ISwear
    {
        public List<string> Words { get; set; }
        public string GetRandomSwear();
    }
}
