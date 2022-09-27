using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace yaSketchbook.Models.Models;

public class DrawingLine : IDrawingLine
{
    public int Granularity { get; set; }
    public Color LineColor { get; set; }
    public float LineWidth { get; set; }
    public ObservableCollection<PointF> Points { get; set; }
    public bool ShouldSmoothPathWhenDrawn { get; set; }

    public ValueTask<Stream> GetImageStream(double imageSizeWidth, double imageSizeHeight, Paint background)
    {
        throw new NotImplementedException();
    }
}
