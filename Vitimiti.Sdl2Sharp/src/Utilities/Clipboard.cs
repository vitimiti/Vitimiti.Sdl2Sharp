using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Utilities;

public static class Clipboard
{
    public static string Text
    {
        get => Sdl.GetClipboardText();
        set
        {
            var code = Sdl.SetClipboardText(value);
            if (code < 0)
            {
                throw new SdlSharpException(Sdl.GetError(), code);
            }
        }
    }

    public static bool HasText => Sdl.HasClipboardText();
}