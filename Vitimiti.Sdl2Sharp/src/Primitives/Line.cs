namespace Vitimiti.Sdl2Sharp.Primitives;

using System.Drawing;

using Vitimiti.Sdl2Sharp.Marshaling;

public class Line : IEquatable<Line>
{
    public static Line Empty => new(Point.Empty, Point.Empty);

    public Point Point1 { get; set; }
    public Point Point2 { get; set; }

    public Line(int x1, int y1, int x2, int y2)
    {
        Point1 = new(x1, y1);
        Point2 = new(x2, y2);
    }

    public Line(Point point1, int x2, int y2)
    {
        Point1 = point1;
        Point2 = new(x2, y2);
    }

    public Line(int x1, int y1, Point point2)
    {
        Point1 = new(x1, y1);
        Point2 = point2;
    }

    public Line(Point point1, Point point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    public Line? Intersect(Rectangle clip)
    {
        var rectangle = new Sdl.Rectangle
        {
            X = clip.X,
            Y = clip.Y,
            W = clip.Width,
            H = clip.Height
        };

        var x1 = Point1.X;
        var y1 = Point1.Y;
        var x2 = Point2.X;
        var y2 = Point2.Y;
        var valid = Sdl.IntersectRectangleAndLine(ref rectangle, ref x1, ref y1, ref x2, ref y2);
        return valid ? new(x1, y1, x2, y2) : null;
    }

    public bool Equals(Line? other)
    {
        return other is not null && Point1.Equals(other.Point1) && Point2.Equals(other.Point2);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Line);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Point1, Point2);
    }
}