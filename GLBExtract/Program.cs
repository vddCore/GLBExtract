using System;
using System.IO;

namespace GLBExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("extr");

            var glb = new GlbFile(args[0]);
            foreach (var fileData in glb.FileData)
            {
                try
                {
                    File.WriteAllBytes(Path.Combine("extr", fileData.ActualFilename), fileData.Data);
                }
                catch
                {
                    Console.WriteLine(fileData.ActualFilename);
                }
            }

            Console.WriteLine("OK.");
        }
    }
}
