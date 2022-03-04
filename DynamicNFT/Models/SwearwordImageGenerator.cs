using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
namespace DynamicNFT.Models
{
    public static class SwearwordImageGenerator
    {
        public static async Task<byte[]> Generate(string imageSourceFilePath, string swear)
        {
            using (Image image = await Image.LoadAsync(imageSourceFilePath))
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FontCollection collection = new();
                FontFamily family = collection.Add($"{baseDirectory}Fonts/ariblk.ttf");
                Font font = family.CreateFont(12, FontStyle.Regular);
                image.Mutate(x => x.DrawText(swear, font, Color.White, new PointF(0, 0)));
                using (var stream = new MemoryStream())
                {
                    await image.SaveAsPngAsync(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
