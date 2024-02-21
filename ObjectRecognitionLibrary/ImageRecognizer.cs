using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;

namespace ImageRecognitionLibrary;

public class ImageRecognizer
{
    private readonly PredictionEngine<ImageData, ImagePrediction> _predictionEngine;

    public ImageRecognizer(string modelPath, string inputTensorName, string outputTensorName)
    {
        var mlContext = new MLContext();
        // var model = mlContext.Model.LoadWithDataLoader(modelPath, )
        // var pipeline = mlContext.Transforms.ResizeImages(outputColumnName: inputTensorName, imageWidth: 224, imageHeight: 224, inputColumnName: nameof(ImageData.Image))
        //     .Append(mlContext.Transforms.ExtractPixels(outputColumnName: inputTensorName))
        //     .Append(model.ScoreTensorFlowModel(outputColumnNames: new[] { outputTensorName }, inputColumnNames: new[] { inputTensorName }, addBatchDimensionInput: true))
        //     .Append(mlContext.Transforms.CopyColumns(outputColumnName: nameof(ImagePrediction.Score), inputColumnName: outputTensorName));

        // var dataView = mlContext.Data.LoadFromEnumerable(new List<ImageData>());
        // var modelPipeline = pipeline.Fit(dataView);
        // _predictionEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(modelPipeline);
    }

    public float[] Predict(string imagePath)
    {
        var imageData = new ImageData { Image = File.ReadAllBytes(imagePath) };
        var prediction = _predictionEngine.Predict(imageData);
        return prediction.Score;
    }
    
    public class ImageData
    {
        [ImageType(224, 224)]
        public byte[] Image { get; set; }
    }

    public class ImagePrediction : ImageData
    {
        public float[] Score { get; set; }
    }
}