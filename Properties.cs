﻿using System.Runtime.InteropServices;

namespace WinApi.Net
{
    internal class Properties
    {
#if !ANSI
        public const CharSet BuildCharSet = CharSet.Unicode;
#else
        public const CharSet BuildCharSet = CharSet.Ansi;
#endif
    }
}