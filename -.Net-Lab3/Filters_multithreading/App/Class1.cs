using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace App
{
    public class Image_processing
    {
        public static Bitmap Thresholding(Bitmap image)
        {
            Bitmap img = (Bitmap)image.Clone();

            double avgBright = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    avgBright += img.GetPixel(x, y).GetBrightness();
                }
            }

            avgBright = avgBright / (img.Width * img.Height);
            avgBright = avgBright < 0.3 ? 0.3 : avgBright;
            avgBright = avgBright > 0.7 ? 0.7 : avgBright;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    if (img.GetPixel(x, y).GetBrightness() > avgBright)
                        img.SetPixel(x, y, Color.White);
                    else
                        img.SetPixel(x, y, Color.Black);
                }
            }

            return img;
        }

        public static Bitmap Negate(Bitmap image)
        {
            Bitmap clone = (Bitmap)image.Clone();

            for (int y = 0; y < clone.Height; y++)
            {
                for (int x = 0; x < clone.Width; x++)
                {
                    Color pixelColor = clone.GetPixel(x, y);
                    Color newColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    clone.SetPixel(x, y, newColor);
                }
            }

            return clone;
        }

        public static Bitmap AdjustBrightness(Bitmap image, int value)
        {
            Bitmap clone = (Bitmap)image.Clone();

            float brightness = value / 100f;

            float[][] matrix = {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {brightness, brightness, brightness, 0, 1}
            };

            ImageAttributes attributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(matrix);
            attributes.SetColorMatrix(colorMatrix);

            using (Graphics g = Graphics.FromImage(clone))
            {
                g.DrawImage(clone, new Rectangle(0, 0, clone.Width, clone.Height),
                            0, 0, clone.Width, clone.Height,
                            GraphicsUnit.Pixel, attributes);
            }

            return clone;
        }

        public static Bitmap DetectEdges(Bitmap originalImage)
        {
            Bitmap edgeImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 1; y < originalImage.Height - 1; y++)
            {
                for (int x = 1; x < originalImage.Width - 1; x++)
                {
                    int gx = (
                        originalImage.GetPixel(x + 1, y - 1).R +
                        2 * originalImage.GetPixel(x + 1, y).R +
                        originalImage.GetPixel(x + 1, y + 1).R -
                        originalImage.GetPixel(x - 1, y - 1).R -
                        2 * originalImage.GetPixel(x - 1, y).R -
                        originalImage.GetPixel(x - 1, y + 1).R) / 4;

                    int gy = (
                        originalImage.GetPixel(x - 1, y - 1).R +
                        2 * originalImage.GetPixel(x, y - 1).R +
                        originalImage.GetPixel(x + 1, y - 1).R -
                        originalImage.GetPixel(x - 1, y + 1).R -
                        2 * originalImage.GetPixel(x, y + 1).R -
                        originalImage.GetPixel(x + 1, y + 1).R) / 4;

                    int sum = Math.Abs(gx) + Math.Abs(gy);
                    sum = Math.Min(255, sum);

                    Color edgeColor = Color.FromArgb(sum, sum, sum);
                    edgeImage.SetPixel(x, y, edgeColor);
                }
            }

            return edgeImage;
        }
    }
}
