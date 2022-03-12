namespace DynamicNFT.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Slow
    {
        public int gwei { get; set; }
        public double usd { get; set; }
    }

    public class Normal
    {
        public int gwei { get; set; }
        public double usd { get; set; }
    }

    public class Fast
    {
        public int gwei { get; set; }
        public double usd { get; set; }
    }

    public class Instant
    {
        public int gwei { get; set; }
        public double usd { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string source { get; set; }
        public int? fast { get; set; }
        public int? standard { get; set; }
        public int? slow { get; set; }
        public int? lastBlock { get; set; }
        public int? instant { get; set; }
        public long? lastUpdate { get; set; }
    }

    public class Gas
    {
        public Slow slow { get; set; }
        public Normal normal { get; set; }
        public Fast fast { get; set; }
        public Instant instant { get; set; }
        public double ethPrice { get; set; }
        public long lastUpdated { get; set; }
        public List<Source> sources { get; set; }
    }


}
