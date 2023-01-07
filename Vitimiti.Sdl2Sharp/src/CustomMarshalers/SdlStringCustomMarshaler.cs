using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.CustomMarshalers;

internal sealed class SdlStringCustomMarshaler : ICustomMarshaler
{
    private static ICustomMarshaler? s_defaultInstance;
    private static ICustomMarshaler? s_leaveAllocatedInstance;

    private readonly bool _leaveAllocated;

    public const string LeaveAllocatedCookie = "LeaveAllocated";

    private SdlStringCustomMarshaler(bool leaveAllocated)
    {
        _leaveAllocated = leaveAllocated;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        return cookie switch
        {
            LeaveAllocatedCookie => s_leaveAllocatedInstance ??= new SdlStringCustomMarshaler(true),
            _ => s_defaultInstance ??= new SdlStringCustomMarshaler(false)
        };
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public void CleanUpNativeData(IntPtr nativeData)
    {
        if (!_leaveAllocated)
        {
            Marshal.FreeCoTaskMem(nativeData);
        }
    }

    public int GetNativeDataSize()
    {
        return Marshal.SizeOf<string>();
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return managedObj is string str
            ? Marshal.StringToCoTaskMemUTF8(str)
            : throw new ArgumentException($"{nameof(managedObj)} is not of type {typeof(string)} but of type {managedObj.GetType()}, which is not valid.", nameof(managedObj));
    }

    public object MarshalNativeToManaged(IntPtr nativeData)
    {
        return Marshal.PtrToStringUTF8(nativeData) ?? string.Empty;
    }
}