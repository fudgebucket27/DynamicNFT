namespace DynamicNFT.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Gas
    {
        public int fast { get; set; }
        public int fastest { get; set; }
        public int safeLow { get; set; }
        public int average { get; set; }
        public double block_time { get; set; }
        public int blockNum { get; set; }
        public double speed { get; set; }
        public double safeLowWait { get; set; }
        public double avgWait { get; set; }
        public double fastWait { get; set; }
        public double fastestWait { get; set; }
    }


}
