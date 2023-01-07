using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.Utilities;

public class SdlSharpException : ExternalException
{
    public SdlSharpException()
    {
    }

    public SdlSharpException(string? message) : base(message)
    {
    }

    public SdlSharpException(string? message, Exception? inner) : base(message, inner)
    {
    }

    public SdlSharpException(string? message, int errorCode) : base(message, errorCode)
    {
    }
}