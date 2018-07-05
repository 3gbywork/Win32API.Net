using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WinApi.Net.Geometry
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point && this.Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            return this.X * 397 ^ this.Y;
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public void Offset(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        public void Set(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return $"{{ X = {this.X.ToString(currentCulture)}, Y = {this.Y.ToString(currentCulture)} }}";
        }

        public bool IsEmpty => this.X == 0 && this.Y == 0;

        public int X;

        public int Y;
    }
}
