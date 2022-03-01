﻿using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace DynamicNFT.Models
{
    public static class WeatherImageGenerator
    {
        public static byte[] Generate(string imageSourceFilePath, string temperature, string localtime, string condition, string city)
        {
            using (Image image = Image.Load(imageSourceFilePath))
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FontCollection collection = new();
                FontFamily family = collection.Add($"{baseDirectory}Fonts/ariblk.ttf");
                Font font = family.CreateFont(12, FontStyle.Regular);
                Font fontTwo = family.CreateFont(8, FontStyle.Regular);
                image.Mutate(x => x.DrawText(temperature + "°C", font, Color.White, new PointF(0, 0)));
                image.Mutate(x => x.DrawText(localtime, font, Color.White, new PointF(140, 0)));
                image.Mutate(x => x.DrawText(condition, fontTwo, Color.White, new PointF(0, 220)));
                image.Mutate(x => x.DrawText(city.ToUpper(), fontTwo, Color.White, new PointF(0, 242)));
                using (var stream = new MemoryStream())
                {
                    image.SaveAsPng(stream);
                    return stream.ToArray();
                }               
            }
        }
    }
}
