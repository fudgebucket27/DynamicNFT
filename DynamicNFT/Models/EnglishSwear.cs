namespace DynamicNFT.Models
{
    public class EnglishSwear : ISwear
    {
        public List<string> Words
        { get =>
                 new List<string>
             {
                     "FUCKWIT",
                     "KNOB",
                     "DICKHEAD",
                     "CUNT",
                     "ARSEHAT",
                     "MUPPET",
                     "CLOWN",
                     "WANKER",
                     "WOMBAT",
                     "DRONGO",
                     "ARSE",

           }; set => throw new NotImplementedException();
        }

        public string GetRandomSwear()
        {
            Random randomNumber = new Random();
            return Words[randomNumber.Next(Words.Count)];
        }
    }
}
