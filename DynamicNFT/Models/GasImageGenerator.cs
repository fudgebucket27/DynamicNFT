using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace DynamicNFT.Models
{
    public class GasImageGenerator
    {
        public static async Task<byte[]> Generate(string imageSourceFilePath, Gas gas)
        {
            using (Image image = await Image.LoadAsync(imageSourceFilePath))
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FontCollection collection = new();
                FontFamily family = collection.Add($"{baseDirectory}Fonts/ariblk.ttf");
                Font font = family.CreateFont(25, FontStyle.Regular);
                image.Mutate(x => x.DrawText("Slow: 10 minutes", font, Color.Red, new PointF(0, 0)));
                image.Mutate(x => x.DrawText($"{gas.slow.gwei.ToString()} gwei / ${gas.slow.usd.ToString()}", font, Color.Yellow, new PointF(0, 85)));
                image.Mutate(x => x.DrawText("Average: 3 minutes", font, Color.Red, new PointF(0, 170)));
                image.Mutate(x => x.DrawText($"{gas.normal.gwei.ToString()} gwei / ${gas.normal.usd.ToString()}", font, Color.Yellow, new PointF(0, 255)));
                image.Mutate(x => x.DrawText("Fast: 15 seconds", font, Color.Red, new PointF(0, 340)));
                image.Mutate(x => x.DrawText($"{gas.fast.gwei.ToString()} gwei / ${gas.fast.usd.ToString()}", font, Color.Yellow, new PointF(0, 425)));
                using (var stream = new MemoryStream())
                {
                    await image.SaveAsPngAsync(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
