using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WinApi.Net.Geometry
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size : IEquatable<Size>
    {
        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public bool Equals(Size other)
        {
            return this.Width == other.Width && this.Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            return obj is Size && this.Equals((Size)obj);
        }

        public override int GetHashCode()
        {
            return this.Width * 397 ^ this.Height;
        }

        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !(left == right);
        }

        public void Offset(int width, int height)
        {
            this.Width += width;
            this.Height += height;
        }

        public void Set(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return
                $"{{ Width = {this.Width.ToString(currentCulture)}, Height = {this.Height.ToString(currentCulture)} }}";
        }

        public bool IsEmpty => this.Width == 0 && this.Height == 0;

        public int Width;

        public int Height;
    }
}
