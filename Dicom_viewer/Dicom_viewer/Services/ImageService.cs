using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Dicom.Imaging.Render;
using System.Runtime.InteropServices;

namespace Dicom_viewer.Services
{
    public static class ImageService
    {
        public static Bitmap MakeImage(IPixelData pixelData)
        {
            ushort[] pixels = GetPixelsArray(pixelData);
            byte[] pixelData8Bit = Convert16To8Bit(pixels);
            byte[] pixel32Data = Convert8BitToBgra32(pixelData8Bit);
            
            var format = PixelFormat.Bgra8888; // Monochrome format (32 bits per pixel)
            var alphaFormat = AlphaFormat.Unpremul; // Adjust the alpha format according to your needs
            var dataPtr = Marshal.AllocHGlobal(pixel32Data.Length);
            Marshal.Copy(pixel32Data, 0, dataPtr, pixel32Data.Length);
            var size = new PixelSize(pixelData.Width, pixelData.Height);
            var dpi = new Vector(96, 96);
            var bitmap = new Bitmap(format, alphaFormat, dataPtr, size, dpi, size.Width * 4); // stride is equal to the width now

            Marshal.FreeHGlobal(dataPtr);
            return bitmap;
        }

        private static ushort[] GetPixelsArray(IPixelData data)
        {
            ushort[] result = new ushort[data.Height*data.Width];
            long counter = 0;
            for (int i = 0; i < data.Width; i++)
            {
                for(int j = 0; j < data.Height; j++)
                {
                    result[counter] = (ushort)data.GetPixel(i, j);
                    counter++;
                }
            }
            return result;
        }

        private static byte[] Convert8BitToBgra32(byte[] pixelData)
        {
            int pixelCount = pixelData.Length;
            byte[] result = new byte[pixelCount * 4]; // Каждый пиксель будет кодироваться 4 байтами (BGRA)

            for (int i = 0; i < pixelCount; i++)
            {
                byte intensity = pixelData[i]; // Значение интенсивности серого
                result[4 * i] = intensity;     // Blue
                result[4 * i + 1] = intensity; // Green
                result[4 * i + 2] = intensity; // Red
                result[4 * i + 3] = 255;       // Alpha
            }
            return result;
        }

        private static byte[] Convert16To8Bit(ushort[] sourceData)
        {
            int length = sourceData.Length;
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(sourceData[i] >> 6); // Игнорирование младших 8 битов
            }
            return result;
        }
    }
}
