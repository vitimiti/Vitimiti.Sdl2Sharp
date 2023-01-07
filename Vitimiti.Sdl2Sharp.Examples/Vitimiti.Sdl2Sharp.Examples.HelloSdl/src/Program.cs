namespace Vitimiti.Sdl2Sharp.Examples.HelloSdl;

internal static class Program
{
    public static void Main()
    {
        using var app = new Systems(SubSystemsFlags.Video);
        Console.WriteLine($"Running SDL v{Systems.Version} with subsystems [{Systems.InitializedSystemFlags}]");
        if (Systems.Version > Systems.SupportedVersion || Systems.Version < Systems.SupportedVersion)
        {
            var comparator = Systems.Version > Systems.SupportedVersion ? "higher" : "lower";
            Console.WriteLine($"SDL v{Systems.Version} is {comparator} than the supported SDL v{Systems.SupportedVersion} and some functionality may not be available");
        }
    }
}