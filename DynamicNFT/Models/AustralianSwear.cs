namespace DynamicNFT.Models
{
    public class AustralianSwear : ISwear
    {
        public List<string> Words
        { get =>
                 new List<string>
             {
                     "F#CKWIT",
                     "F#CKSTICK",
                     "KNOB",
                     "DICKHEAD",
                     "C#NT",
                     "DERRO",
                     "ROOT",
                     "ARSEHAT",
                     "MUPPET",
                     "ARSEWIPE",
                     "SLAG",
                     "WANKER",
                     "DRONGO",
                     "ARSE",
                     "PUSSY",
                     "TWAT"
           };
        }

        public string GetRandomSwear()
        {
            Random randomNumber = new Random();
            return Words[randomNumber.Next(Words.Count)];
        }
    }
}
