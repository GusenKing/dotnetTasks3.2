namespace Lesson10.ImageClassification.Extensions;

public static class PredictionsExtensions
{
    public static void OutputResultsToConsole(this IEnumerable<ImagePrediction> imagePredictionData)
    {
        foreach (var prediction in imagePredictionData)
            Console.WriteLine(
                $"Image: {Path.GetFileName(prediction.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score?.Max()} ");
    }
}