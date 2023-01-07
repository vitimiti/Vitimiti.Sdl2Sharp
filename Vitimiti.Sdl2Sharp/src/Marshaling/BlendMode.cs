using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.Video.Blending;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [DllImport(DllName, EntryPoint = "SDL_ComposeCustomBlendMode")]
    public static extern BlendMode ComposeCustomBlendMode(
        BlendFactor sourceColorFactor,
        BlendFactor destinationColorFactor,
        BlendOperation colorOperation,
        BlendFactor sourceAlphaFactor,
        BlendFactor destinationAlphaFactor,
        BlendOperation alphaOperation
    );
}