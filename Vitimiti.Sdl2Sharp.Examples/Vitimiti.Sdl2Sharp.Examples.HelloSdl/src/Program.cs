namespace Vitimiti.Sdl2Sharp.Examples.HelloSdl;

internal static class Program
{
    public static void Main()
    {
        using var app = new Systems(SubSystemsFlags.Video);
        Console.WriteLine($"Running with subsystems [{Systems.InitializedSystemFlags}]");
    }
}