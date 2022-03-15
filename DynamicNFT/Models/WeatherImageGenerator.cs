using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace DynamicNFT.Models
{
    public static class WeatherImageGenerator
    {
        public static async  Task<byte[]> Generate(string imageSourceFilePath, string temperature, string localtime, string condition, string city)
        {
            using (Image image = await Image.LoadAsync(imageSourceFilePath))
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FontCollection collection = new();
                FontFamily family = collection.Add($"{baseDirectory}Fonts/OpenSans-ExtraBold.ttf");
                Font font = family.CreateFont(30, FontStyle.Regular);
                Font fontTwo = family.CreateFont(20, FontStyle.Regular);
                Font fontThree = family.CreateFont(30, FontStyle.Regular);

                TextOptions options = new(fontThree)
                {
                    Origin = new PointF(320, 605), // Set the rendering origin.
                    TabWidth = 8, // A tab renders as 8 spaces wide
                    WrappingLength = 300, // Greater than zero so we will word wrap at 100 pixels wide
                    HorizontalAlignment = HorizontalAlignment.Center // Right align
                };


                image.Mutate(x => x.DrawText(temperature + "°C", font, Color.White, new PointF(0, 0)));
                image.Mutate(x => x.DrawText(localtime, font, Color.White, new PointF(390, 0)));
                image.Mutate(x => x.DrawText(condition, fontTwo, Color.White, new PointF(0, 30)));
                image.Mutate(x => x.DrawText(options, city.ToUpper(), Color.White));
                using (var stream = new MemoryStream())
                {
                    await image.SaveAsPngAsync(stream);
                    return stream.ToArray();
                }               
            }
        }

        public static async Task<byte[]> Generate(string filePath)
        {
            using (Image image = await Image.LoadAsync(filePath))
            {
                using (var stream = new MemoryStream())
                {
                    await image.SaveAsPngAsync(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
