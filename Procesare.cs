using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComponentLearning_2
{
    unsafe public struct Pixel
    {
        public byte Blue, Green, Red;
    }
    unsafe public class Procesare
    {
        private static byte[] vectorMakeGray = new byte[256 * 3];
        private static int[] vectorSqrt = new int[256 * 256 * 3];

        //Definim matricile de convolutie pentru determinarea contururilor 
        public int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };     //  Matrice de convolutie - Sobel (muchii orizontale)
        public int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };     //  Matrice de convolutie - Sobel (muchii verticale)
        public int[,] rx = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };     //  Matrice de convolutie - Prewit (muchii orizontale)
        public int[,] ry = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };     //  Matrice de convolutie - Prewit (muchii verticale)
        public int[,] kx = new int[,] { { -5, 3, 3 }, { -5, 0, 3 }, { -5, 3, 3 } };     //  Matrice de convolutie - Kirsch (muchii orizontale) 
        public int[,] ky = new int[,] { { 3, 3, 3 }, { 3, 0, 3 }, { -5, -5, -5 } };     //  Matrice de convolutie - Kirsch (muchii verticale)
        static Procesare()
        {
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            StreamWriter fisierDeScriere = new StreamWriter(rootDirectory + "/xls/myTest.txt");

            for (int i = 0; i < vectorMakeGray.Length; i++)
            {
                vectorMakeGray[i] = (byte)(i / 3);
                fisierDeScriere.WriteLine(vectorMakeGray[i]);
            }    
            for (int i = 0; i < vectorSqrt.Length; i++)
                vectorSqrt[i] = (int)Math.Sqrt(i);
        }

        private BitmapData bitmapData;
        private Bitmap image;
        private byte* start;
        private byte* end;
        private int emptySpace;

        public Procesare(Bitmap image)
        {
            bitmapData = LockBitsRGB(image);
            start = (byte*)bitmapData.Scan0;
            this.image = image;

            // o linie din imagine e memorata fortat pe un numar de octeti divizibil cu 4 (32 biti),
            // pentru o prelucrare mai rapida, astfel ultimii octeti dintr-o linie sunt nefolositi
            // si nu trebuie confundati cu octetii din imagine (se poate ajunge la sfarsitul imaginii
            // mai devreme decat ar trebui !)
            emptySpace = image.Width % 4;
            end = start + bitmapData.Height * (bitmapData.Width * 3 + emptySpace) - 1; // inclusiv
        }

        public void FinishProcessing()
        {
            image.UnlockBits(bitmapData);
        }

        private BitmapData LockBitsRGB(Bitmap img)
        {
            return img.LockBits(new Rectangle(Point.Empty, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        }

        private Pixel* GetPixel(byte* start, int linie, int coloana)
        {
            return (Pixel*)(start + (3 * image.Width + emptySpace) * linie + 3 * coloana);
        }

        public void MakeGray()
        {
            Pixel* pixel = (Pixel*)start;
            while (pixel < end)
            {
                Pixel* width = pixel + image.Width;
                while (pixel < width)
                {
                    pixel->Red = pixel->Green = pixel->Blue = vectorMakeGray[pixel->Red + pixel->Green + pixel->Blue];
                    pixel++;
                }
                pixel = (Pixel*)((byte*)pixel + emptySpace);
            }
        }

        /*
                fis 		--- myNadia2Contur.csv		    --- edge detection (scrie coordonate)
                fisMare 	--- myNadia2Contur.csv 		    --- incarca vectori coordonate 
                fisMic 		--- myNadia2ConturShort.csv 	--- scaleaza 
        */

        public void EdgeDetection(int val)
        {
            Pixel* pixelUp = (Pixel*)start;
            Pixel* pixelDown = (Pixel*)(start + 3 * image.Width + emptySpace);

            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            StreamWriter fis = new StreamWriter(rootDirectory + "/xls/EdgeDetection.csv");
            //MessageBox.Show($"Ajuns aici cu rezolutie W:{image.Width} x H: {image.Height}");

            // Parcurg fiecare pixel al imaginii
            // Up = curent; Down = de sub el; Up + 1 = din dreapta
            int i = 0; 
            while (pixelDown < end)  // nu e sfarsitul sfarsitului
            {
                Pixel* width = pixelUp + image.Width - 1; 
                int j = 0;
                while (pixelUp < width)
                {
                    //retin valorile culorilor
                    
                    // distanta pe orizontala
                    int a = pixelUp[1].Red - pixelUp->Red;
                    int b = pixelUp[1].Green - pixelUp->Green;
                    int c = pixelUp[1].Blue - pixelUp->Blue;

                    int distDr = vectorSqrt[a * a + b * b + c * c];

                    // distanta pe verticala
                    a = pixelDown->Red - pixelUp->Red; 
                    b = pixelDown->Green - pixelUp->Green;
                    c = pixelDown->Blue - pixelUp->Blue;
                    int distJos = vectorSqrt[a * a + b * b + c * c];

                    //acele valori obtinute sunt comparate cu un anumit prag stabilit de utilizator
                    if (distJos < val && distDr < val) // se incadreaza in variatia acceptata
                        pixelUp->Red = pixelUp->Green = pixelUp->Blue = 255; // pune alb
                    else 
                    {
                        string aux = $"{i + 1},{j + 1},{pixelUp->Red}";                                           
                        pixelUp->Red = pixelUp->Green = pixelUp->Blue = 0; // pune negru
                        fis.WriteLine(aux);
                    }
                    
                    pixelUp++;      
                    pixelDown++;
                    
                    j++;
                }

                pixelUp = (Pixel*)((byte*)pixelUp + emptySpace + 3);
                pixelDown = (Pixel*)((byte*)pixelDown + emptySpace + 3);

                i++;
            }
            fis.Close();
        }

        public void Negative()
        {
            Pixel* pixel = (Pixel*)start;
            while (pixel < end)
            {
                Pixel* width = pixel + image.Width;
                while (pixel < width)
                {
                    pixel->Red = (byte)~pixel->Red;
                    pixel->Green = (byte)~pixel->Green; 
                    pixel->Blue = (byte)~pixel->Blue; 
                    pixel++;
                }
                pixel = (Pixel*)((byte*)pixel + emptySpace);
            }
        }
        public void MakeGrayKeepRed()
        {
            int culoare;
            Pixel* pixel = (Pixel*)start;
            //parcurgem pixelii din imagine
            while (pixel < end)
            {
                Pixel* width = pixel + image.Width;
                while (pixel < width)
                {
                    //stabilim valorile culorilor pt fiecare pixel si trecem mai departe
                    culoare = (pixel->Green + pixel->Blue) / 2;
                    pixel->Green = pixel->Blue = (byte)culoare;
                    pixel++;
                }
                pixel = (Pixel*)((byte*)pixel + emptySpace);
            }
        }

        public void MakeGrayKeepGreen()
        {
            int culoare;
            Pixel* pixel = (Pixel*)start;
            //parcurgem pixelii din imagine
            while (pixel < end)
            {
                Pixel* width = pixel + image.Width;
                while (pixel < width)
                {
                    //stabilim valorile culorilor pt fiecare pixel si trecem mai departe
                    culoare = (pixel->Red + pixel->Blue) / 2;
                    pixel->Red = pixel->Blue = (byte)culoare;
                    pixel++;
                }
                pixel = (Pixel*)((byte*)pixel + emptySpace);
            }
        }

        public void MakeGrayKeepBlue()
        {
            int culoare;
            Pixel* pixel = (Pixel*)start;
            //parcurgem pixelii din imagine
            while (pixel < end)
            {
                Pixel* width = pixel + image.Width;
                while (pixel < width)
                {
                    culoare = (pixel->Red + pixel->Green) / 2;
                    pixel->Red = pixel->Green = (byte)culoare;
                    pixel++;
                }
                //trecem la urmatorul pixel
                pixel = (Pixel*)((byte*)pixel + emptySpace);
            }
        }
        public Bitmap PrewitEdgeDetection(int val)
        {
            //Se creaza o noua imagine pentru rezultat
            Bitmap destImage = new Bitmap(image.Width, image.Height);
            BitmapData destImageData = destImage.LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //Aplicam filtrele pentru fiecare pixel din imagine 
            byte* destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride + 3;
            for (int i = 1; i < bitmapData.Height - 1; i++) 
                {
                    destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride * i + 3;
                    for (int j = 1; j < bitmapData.Width - 1; j++)
                    {
                        int Gx = 0;
                        int Gy = 0;
                        //Pointerul catre pixelul curent
                        start = (byte*)(bitmapData.Scan0) + (i - 1) * bitmapData.Stride + (j - 1) * 3;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                Gx += start[0] * rx[k, l];
                                Gy += start[0] * ry[k, l];
                                start += 3;
                            }
                            start += (bitmapData.Stride - 9);
                        }

                        int magnitude = (Gx * Gx + Gy * Gy);
                        
                        if(magnitude>val*val)
                            magnitude=0;
                        else
                            magnitude=255;
                        
                        //Pastram valuarea calculata in imaginea-rezultat
                        destImagePtr[0] = (byte)magnitude;
                        destImagePtr[1] = (byte)magnitude;
                        destImagePtr[2] = (byte)magnitude;
                        destImagePtr += 3;
                    }
                }
            
            //Unlock bitmap data in memorie
            destImage.UnlockBits(destImageData);

            //returnam imaginea-rezultat
            return destImage;
        }

        public Bitmap SobelEdgeDetection(int val)
        {
            //Se creaza o noua imagine pentru rezultat
            Bitmap destImage = new Bitmap(image.Width, image.Height);
            BitmapData destImageData = destImage.LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //Aplicam filtrele pentru fiecare pixel din imagine 
            byte* destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride + 3;
            for (int i = 1; i < bitmapData.Height - 1; i++)
            {
                destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride * i + 3;
                for (int j = 1; j < bitmapData.Width - 1; j++)
                {
                    int Gx = 0;
                    int Gy = 0;
                    //Pointerul catre pixelul curent
                    start = (byte*)(bitmapData.Scan0) + (i - 1) * bitmapData.Stride + (j - 1) * 3;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            Gx += start[0] * gx[k, l];
                            Gy += start[0] * gy[k, l];
                            start += 3;
                        }
                        start += (bitmapData.Stride - 9);
                    }

                    int magnitude = (int)(Gx * Gx + Gy * Gy);

                    if (magnitude > val * val)
                        magnitude = 0;
                    else
                        magnitude = 255;

                    //Pastram valoarea calculata in imaginea-rezultat
                    destImagePtr[0] = (byte)magnitude;
                    destImagePtr[1] = (byte)magnitude;
                    destImagePtr[2] = (byte)magnitude;
                    destImagePtr += 3;
                }
            }

            //Unlock bitmap data in memorie
            destImage.UnlockBits(destImageData);

            //returnam imaginea-rezultat
            return destImage;
        }

        public void Blurr()
        {
            int stride = bitmapData.Stride;
            System.IntPtr Scan0 = bitmapData.Scan0;
            byte* p = (byte*)(void*)Scan0;
            //int nOffset = stride - image.Width * 3;
            int nWidth = image.Width;
            int nHeight = image.Height;
            //se parcurg pixelii si se stabilesc noile valori pentru fircare culoare
            for (int i = 0; i < nHeight; ++i)
            {
                for (int j = 0; j < nWidth; ++j)
                {
                    float r = 0, g = 0, b = 0;
                    int adj = 0;
                    if (i > 0)
                    {
                        Pixel* px = GetPixel(p, i - 1, j);
                        r += px->Red;
                        g += px->Green;
                        b += px->Blue;
                        adj++;
                    }
                    if (i < nHeight - 1)
                    {
                        Pixel* px = GetPixel(p, i + 1, j);
                        r += px->Red;
                        g += px->Green;
                        b += px->Blue;
                        adj++;
                    }
                    if (j > 0)
                    {
                        Pixel* px = GetPixel(p, i, j - 1);
                        r += px->Red;
                        g += px->Green;
                        b += px->Blue;
                        adj++;
                    }
                    if (j < nWidth - 1)
                    {
                        Pixel* px = GetPixel(p, i, j + 1);
                        r += px->Red;
                        g += px->Green;
                        b += px->Blue;
                        adj++;
                    }
                    Pixel* pxl = GetPixel(p, i, j);
                    r = (pxl->Red + r / adj * 3) / 4;
                    g = (pxl->Green + g / adj * 3) / 4;
                    b = (pxl->Blue + b / adj * 3) / 4;

                    r = r > 255 ? 255 : r;
                    g = g > 255 ? 255 : g;
                    b = b > 255 ? 255 : b;
                    //modificam valorile culorilor cu noile valori
                    pxl = GetPixel(p, i, j);
                    pxl->Red = (byte)r;
                    pxl->Green = (byte)g;
                    pxl->Blue = (byte)b;
                }
            }
        }

        public Bitmap Blur(Bitmap image, Int32 blurSize)
        {
            return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }

        private unsafe Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            FinishProcessing();

            Bitmap blurred = new Bitmap(image.Width, image.Height);

            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);

            int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);

            byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

            // look at every pixel in the blur rectangle
            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            avgB += data[0]; // Blue
                            avgG += data[1]; // Green
                            avgR += data[2]; // Red

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                    {
                        for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            // Change values
                            data[0] = (byte)avgB;
                            data[1] = (byte)avgG;
                            data[2] = (byte)avgR;
                        }
                    }
                }
            }

            // Unlock the bits
            blurred.UnlockBits(blurredData);

            return blurred;
        }

        public Bitmap Kirsch(int val)
        {
            //Se creaza o noua imagine pentru rezultat
            Bitmap destImage = new Bitmap(image.Width, image.Height);
            BitmapData destImageData = destImage.LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //Aplicam filtrele pentru fiecare pixel din imagine 
            byte* destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride + 3;
            for (int i = 1; i < bitmapData.Height - 1; i++)
            {
                destImagePtr = (byte*)destImageData.Scan0 + bitmapData.Stride * i + 3;
                for (int j = 1; j < bitmapData.Width - 1; j++)
                {
                    int Gx = 0;
                    int Gy = 0;
                    //Pointerul catre pixelul curent
                    start = (byte*)(bitmapData.Scan0) + (i - 1) * bitmapData.Stride + (j - 1) * 3;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            Gx += start[0] * kx[k, l];
                            Gy += start[0] * ky[k, l];
                            start += 3;
                        }
                        start += (bitmapData.Stride - 9);
                    }

                    int magnitude = (int)(Gx * Gx + Gy * Gy);

                    if (magnitude > val * val)
                        magnitude = 0;
                    else
                        magnitude = 255;

                    //Pastram valuarea calculata in imaginea-rezultat
                    destImagePtr[0] = (byte)magnitude;
                    destImagePtr[1] = (byte)magnitude;
                    destImagePtr[2] = (byte)magnitude;
                    destImagePtr += 3;
                }
            }

            //Unlock bitmap data in memorie
            destImage.UnlockBits(destImageData);

            //returnam imaginea-rezultat
            return destImage;
        }
    }
}
