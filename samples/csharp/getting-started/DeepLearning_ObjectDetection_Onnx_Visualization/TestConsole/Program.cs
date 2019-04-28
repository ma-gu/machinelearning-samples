using ObjectDetection;
using System;
using System.Drawing;
using System.IO;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelFilePath = Path.Combine(Root, @"assets\Model", "TinyYolo2_model.onnx");

            var imagesPath = Path.Combine(Root, "images");
            var tagsTsv = Path.Combine(imagesPath, "tags.tsv");
            var dog2 = Path.Combine(imagesPath, "dog2.jpg");

            try
            {
                var modelScorer = new OnnxModelScorer(modelFilePath);
                modelScorer.Score(new Bitmap(Image.FromFile(dog2)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("========= End of Process..Hit any Key ========");
            Console.ReadLine();
        }

        public static string Root => AppDomain.CurrentDomain.BaseDirectory;
    }
}
