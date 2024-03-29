﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace SavannahManagerStyleLib.Models.Image
{
    public static class ImageLoader
    {
        private static readonly Dictionary<string, BitmapImage> Cache = new Dictionary<string, BitmapImage>();

        public static BitmapImage LoadFromResource(string key)
        {
            if (Cache.ContainsKey(key))
                return Cache[key];

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(key);
            if (stream == null)
                return null;

            var bitmapImage = CreateBitmapImage(stream);

            Cache.Add(key, bitmapImage);

            return bitmapImage;
        }

        private static BitmapImage CreateBitmapImage(Stream stream)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.DecodePixelWidth = 50;
            bitmapImage.DecodePixelHeight = 50;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
