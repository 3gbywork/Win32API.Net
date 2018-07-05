using System;
using System.Runtime.InteropServices;

namespace WinApi.Net
{
    public static class MarshalEx
    {
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        public static TDelegate GetDelegateForFunctionPointer<TDelegate>(IntPtr ptr)
        {
            return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(TDelegate));
        }
    }
}
