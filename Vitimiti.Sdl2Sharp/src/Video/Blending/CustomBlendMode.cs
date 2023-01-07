using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Video.Blending;

public static class CustomBlendMode
{
    public static BlendMode Compose(
        BlendFactor sourceColorFactor,
        BlendFactor destinationColorFactor,
        BlendOperation colorOperation,
        BlendFactor sourceAlphaFactor,
        BlendFactor destinationAlphaFactor,
        BlendOperation alphaOperation)
    {
        return Sdl.ComposeCustomBlendMode(
            sourceColorFactor,
            destinationColorFactor,
            colorOperation,
            sourceAlphaFactor,
            destinationAlphaFactor,
            alphaOperation);
    }
}