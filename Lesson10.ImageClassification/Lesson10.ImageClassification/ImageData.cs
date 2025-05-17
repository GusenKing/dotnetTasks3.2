using Microsoft.ML.Data;

namespace Lesson10.ImageClassification;

public class ImageData
{
    [LoadColumn(0)]
    public string? ImagePath;

    [LoadColumn(1)]
    public string? Label;
}