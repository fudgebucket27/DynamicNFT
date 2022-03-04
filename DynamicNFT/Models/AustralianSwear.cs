namespace DynamicNFT.Models
{
    public class AustralianSwear : ISwear
    {
        public List<string> Words
        { get =>
                 new List<string>
             {
                     "FUCKWIT",
                     "FUCKSTICK",
                     "KNOB",
                     "DICKHEAD",
                     "CUNT",
                     "DERRO",
                     "ROOT",
                     "ARSEHAT",
                     "MUPPET",
                     "SLAG",
                     "WANKER",
                     "DRONGO",
                     "ARSE",
                     "PUSSY"
           };
        }

        public string GetRandomSwear()
        {
            Random randomNumber = new Random();
            return Words[randomNumber.Next(Words.Count)];
        }
    }
}
