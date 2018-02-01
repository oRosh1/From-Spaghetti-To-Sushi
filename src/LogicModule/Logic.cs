using CommandLineParserNuGet;
using ImageProcessingContracts;
using LogicContracts;
using System;
using System.Diagnostics;
using System.IO;
using ImageProcessModule;

namespace LogicModule
{
    public class Logic : ILogic
    {
        private readonly ImageProcessor _IprocessImage;
        public Logic(ImageProcessor processImage)
        {
            _IprocessImage = processImage;
        }

        public void Arguments(string[] args)
        {
            var argsParser = new CommandLineParser(args);
            string src = argsParser["src"];
            string dest = argsParser["dest"];
            dest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                dest,
                                DateTime.Now.ToString("HH-mm-ss"));
            if (!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            var paths = Directory.GetFiles(src);
            var sw = Stopwatch.StartNew();
            foreach (var path in paths)
            {
                _IprocessImage.ProcessImage(dest, path);
            }

            sw.Stop();
            Console.WriteLine($"Done: {sw.Elapsed}");
            Console.ReadKey();
        }
    }
}
