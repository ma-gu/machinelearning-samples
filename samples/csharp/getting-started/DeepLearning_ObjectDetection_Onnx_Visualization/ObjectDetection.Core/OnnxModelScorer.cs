using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.ML;
using ObjectDetection.Core;

namespace ObjectDetection
{
    public class OnnxModelScorer
    {
        private readonly string imagesLocation;
        private readonly string imagesFolder;
        private readonly string modelLocation;
        private readonly MLContext mlContext;

        private IList<YoloBoundingBox> _boxes = new List<YoloBoundingBox>();
        private readonly YoloWinMlParser _parser = new YoloWinMlParser();

        public OnnxModelScorer(string modelLocation)
        {
            this.modelLocation = modelLocation;

            mlContext = new MLContext();
        }

        public struct ImageNetSettings
        {
            public const int imageHeight = 416;
            public const int imageWidth = 416;
        }

        public struct TinyYoloModelSettings
        {
            // for checking TIny yolo2 Model input and  output  parameter names,
            //you can use tools like Netron, 
            // which is installed by Visual Studio AI Tools

            // input tensor name
            public const string ModelInput = "image";

            // output tensor name
            public const string ModelOutput = "grid";
        }

        public void Score(Bitmap image)
        {
            var imageData = new BitmapDataView(image);
            var model = LoadModel(imageData);

            PredictDataUsingModel(imageData, model);
        }

        private PredictionEngine<BitmapDataView, ImageNetPrediction> LoadModel(BitmapDataView imageData)
        {
            Console.WriteLine("Read model");
            Console.WriteLine($"Model location: {modelLocation}");
            Console.WriteLine($"Images folder: {imagesFolder}");
            Console.WriteLine($"Default parameters: image size=({ImageNetSettings.imageWidth},{ImageNetSettings.imageHeight})");

            //var data = mlContext.Data.LoadFromTextFile<ImageNetData>(imagesLocation, hasHeader: true);

            var pipeline = mlContext.Transforms.ResizeImages(outputColumnName: "image", imageWidth: ImageNetSettings.imageWidth, imageHeight: ImageNetSettings.imageHeight, inputColumnName: "image")
                            .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "image"))
                            .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { TinyYoloModelSettings.ModelOutput }, inputColumnNames: new[] { TinyYoloModelSettings.ModelInput }));

            var model = pipeline.Fit(imageData);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<BitmapDataView, ImageNetPrediction>(model);

            return predictionEngine;
        }

        protected void PredictDataUsingModel(BitmapDataView data, PredictionEngine<BitmapDataView, ImageNetPrediction> model)
        {
            Console.WriteLine($"Tags file location: {imagesLocation}");
            Console.WriteLine("");
            Console.WriteLine("=====Identify the objects in the images=====");
            Console.WriteLine("");



            var probs = model.Predict(data).PredictedLabels;
            IList<YoloBoundingBox> boundingBoxes = _parser.ParseOutputs(probs);
            var filteredBoxes = _parser.NonMaxSuppress(boundingBoxes, 5, .5F);

            //Console.WriteLine(".....The objects in the image {0} are detected as below....", sample.Label);
            foreach (var box in filteredBoxes)
            {
                Console.WriteLine(box.Label + " and its Confidence score: " + box.Confidence);
            }
            Console.WriteLine("");



            //var testData = ImageNetData.ReadFromCsv(imagesLocation, imagesFolder);

            //foreach (var sample in testData)
            //{
            //    var probs = model.Predict(sample).PredictedLabels;
            //    IList<YoloBoundingBox> boundingBoxes = _parser.ParseOutputs(probs);
            //    var filteredBoxes = _parser.NonMaxSuppress(boundingBoxes, 5, .5F);

            //    Console.WriteLine(".....The objects in the image {0} are detected as below....", sample.Label);
            //    foreach (var box in filteredBoxes)
            //    {
            //        Console.WriteLine(box.Label + " and its Confidence score: " + box.Confidence);
            //    }
            //    Console.WriteLine("");
            //}
        }
    }
}

