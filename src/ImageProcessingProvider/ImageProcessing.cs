using ImageProcessingContracts;
using ImageSharp;
using System;
using System.IO;

namespace ImageProcessingProvider
{
    public class ImageProcessing : IProcessImage
    {
        public void ProcessImage(string dest, string path)
        {
            byte[] photoBytes = File.ReadAllBytes(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string target = $@"{dest}\{name}.jpg";
            Console.WriteLine(name);

            using (var outStream = new FileStream(target, FileMode.Create))
            {
                Image image = new Image(photoBytes);
                image.Resize(600, 600)
                     .Grayscale()
                     .Save(outStream);
            }
        }
    }
}
