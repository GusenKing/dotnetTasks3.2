using System.Globalization;
using Lesson10.ImageClassification.Extensions;
using Microsoft.ML;

namespace Lesson10.ImageClassification;

internal class Program
{
    private static readonly string AssetsPath = Path.Combine(Environment.CurrentDirectory, "assets");
    private static readonly string ImagesFolder = Path.Combine(AssetsPath, "images");
    private static readonly string TrainTagsTsv = Path.Combine(ImagesFolder, "tags.tsv");
    private static readonly string TestTagsTsv = Path.Combine(ImagesFolder, "test-tags.tsv");
    private static readonly string PredictSingleImage = Path.Combine(ImagesFolder, "toaster3.jpg");

    private static readonly string InceptionTensorFlowModel =
        Path.Combine(AssetsPath, "inception", "tensorflow_inception_graph.pb");

    public static void Main(string[] args)
    {
        var mlContext = new MLContext();

        var model = GenerateModel(mlContext);

        ClassifySingleImage(mlContext, model);

        Console.ReadKey();
    }

    private static ITransformer GenerateModel(MLContext mlContext)
    {
        IEstimator<ITransformer> pipeline = mlContext.Transforms
            .LoadImages("input", ImagesFolder, nameof(ImageData.ImagePath))
            .Append(mlContext.Transforms.ResizeImages("input", InceptionSettings.ImageWidth,
                InceptionSettings.ImageHeight,
                "input"))
            .Append(mlContext.Transforms.ExtractPixels("input", interleavePixelColors: InceptionSettings.ChannelsLast,
                offsetImage: InceptionSettings.Mean))
            .Append(mlContext.Model.LoadTensorFlowModel(InceptionTensorFlowModel)
                .ScoreTensorFlowModel(["softmax2_pre_activation"], ["input"], true))
            .Append(mlContext.Transforms.Conversion.MapValueToKey("LabelKey", "Label"))
            .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy("LabelKey",
                "softmax2_pre_activation"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"))
            .AppendCacheCheckpoint(mlContext);
        var trainingData = mlContext.Data.LoadFromTextFile<ImageData>(TrainTagsTsv, hasHeader: false);


        Console.WriteLine("=============== Training classification model ===============");
        var model = pipeline.Fit(trainingData);
        var testData = mlContext.Data.LoadFromTextFile<ImageData>(TestTagsTsv, hasHeader: false);
        var predictions = model.Transform(testData);

        var imagePredictionData = mlContext.Data.CreateEnumerable<ImagePrediction>(predictions, true);
        imagePredictionData.OutputResultsToConsole();

        Console.WriteLine("=============== Classification metrics ===============");
        var metrics =
            mlContext.MulticlassClassification.Evaluate(predictions,
                "LabelKey",
                predictedLabelColumnName: "PredictedLabel");

        Console.WriteLine($"LogLoss is: {metrics.LogLoss}");
        Console.WriteLine(
            $"PerClassLogLoss is: {string.Join(" , ", metrics.PerClassLogLoss.Select(c => c.ToString(CultureInfo.InvariantCulture)))}");

        return model;
    }

    private static void ClassifySingleImage(MLContext mlContext, ITransformer model)
    {
        var imageData = new ImageData
        {
            ImagePath = PredictSingleImage
        };

        var predictor = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
        var prediction = predictor.Predict(imageData);

        Console.WriteLine("=============== Making single image classification ===============");
        Console.WriteLine(
            $"Image: {Path.GetFileName(imageData.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score!.Max()} ");
    }
}