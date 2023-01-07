using System.Drawing;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Extensions;

public static class RectangleExtensions
{
    public static Rectangle? EnclosePoints(this Rectangle rectangle, Span<Point> points)
    {
        var nativePoints = new Sdl.Point[points.Length];
        for (var i = 0; i < points.Length; i++)
        {
            nativePoints[i].X = points[i].X;
            nativePoints[i].Y = points[i].Y;
        }

        var clip = new Sdl.Rectangle
        {
            X = rectangle.X,
            Y = rectangle.Y,
            W = rectangle.Width,
            H = rectangle.Height
        };

        var valid = Sdl.EnclosePoints(nativePoints, points.Length, ref clip, out var result);
        return valid ? new(result.X, result.Y, result.W, result.H) : null;
    }
}