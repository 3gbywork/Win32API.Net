using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WinApi.Net.Geometry
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Rectangle(int width = 0, int height = 0)
        {
            this = new Rectangle(0, 0, width, height);
        }

        public Rectangle(int all = 0)
        {
            this = new Rectangle(all, all, all, all);
        }

        public bool Equals(Rectangle other)
        {
            return this.Left == other.Left && this.Right == other.Right && this.Top == other.Top && this.Bottom == other.Bottom;
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle && this.Equals((Rectangle)obj);
        }

        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return ((this.Left * 397 ^ this.Top) * 397 ^ this.Right) * 397 ^ this.Bottom;
        }

        public Size Size
        {
            get => new Size(this.Width, this.Height);
            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }

        public bool IsEmpty => this.Left == 0 && this.Top == 0 && this.Right == 0 && this.Bottom == 0;

        public int Width
        {
            get => this.Right - this.Left;
            set => this.Right = this.Left + value;
        }

        public int Height
        {
            get => this.Bottom - this.Top;
            set => this.Bottom = this.Top + value;
        }

        public static Rectangle Create(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width + x, height + y);
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format("{{ Left = {0}, Top = {1} , Right = {2}, Bottom = {3} }}, {{ Width: {4}, Height: {5} }}", new object[]
            {
                this.Left.ToString(currentCulture),
                this.Top.ToString(currentCulture),
                this.Right.ToString(currentCulture),
                this.Bottom.ToString(currentCulture),
                this.Width.ToString(currentCulture),
                this.Height.ToString(currentCulture)
            });
        }

        public static Rectangle From(ref Rectangle lvalue, ref Rectangle rvalue, Func<int, int, int> leftTopOperation, Func<int, int, int> rightBottomOperation = null)
        {
            if (rightBottomOperation == null)
            {
                rightBottomOperation = leftTopOperation;
            }
            return new Rectangle(leftTopOperation(lvalue.Left, rvalue.Left), leftTopOperation(lvalue.Top, rvalue.Top), rightBottomOperation(lvalue.Right, rvalue.Right), rightBottomOperation(lvalue.Bottom, rvalue.Bottom));
        }

        public void Add(Rectangle value)
        {
            Rectangle.Add(ref this, ref value);
        }

        public void Subtract(Rectangle value)
        {
            Rectangle.Subtract(ref this, ref value);
        }

        public void Multiply(Rectangle value)
        {
            Rectangle.Multiply(ref this, ref value);
        }

        public void Divide(Rectangle value)
        {
            Rectangle.Divide(ref this, ref value);
        }

        public void Deflate(Rectangle value)
        {
            Rectangle.Deflate(ref this, ref value);
        }

        public void Inflate(Rectangle value)
        {
            Rectangle.Inflate(ref this, ref value);
        }

        public void Offset(int x, int y)
        {
            Rectangle.Offset(ref this, x, y);
        }

        public void OffsetTo(int x, int y)
        {
            Rectangle.OffsetTo(ref this, x, y);
        }

        public void Scale(int x, int y)
        {
            Rectangle.Scale(ref this, x, y);
        }

        public void ScaleTo(int x, int y)
        {
            Rectangle.ScaleTo(ref this, x, y);
        }

        public static void Add(ref Rectangle lvalue, ref Rectangle rvalue)
        {
            lvalue.Left += rvalue.Left;
            lvalue.Top += rvalue.Top;
            lvalue.Right += rvalue.Right;
            lvalue.Bottom += rvalue.Bottom;
        }

        public static void Subtract(ref Rectangle lvalue, ref Rectangle rvalue)
        {
            lvalue.Left -= rvalue.Left;
            lvalue.Top -= rvalue.Top;
            lvalue.Right -= rvalue.Right;
            lvalue.Bottom -= rvalue.Bottom;
        }

        public static void Multiply(ref Rectangle lvalue, ref Rectangle rvalue)
        {
            lvalue.Left *= rvalue.Left;
            lvalue.Top *= rvalue.Top;
            lvalue.Right *= rvalue.Right;
            lvalue.Bottom *= rvalue.Bottom;
        }

        public static void Divide(ref Rectangle lvalue, ref Rectangle rvalue)
        {
            lvalue.Left /= rvalue.Left;
            lvalue.Top /= rvalue.Top;
            lvalue.Right /= rvalue.Right;
            lvalue.Bottom /= rvalue.Bottom;
        }

        public static void Deflate(ref Rectangle target, ref Rectangle deflation)
        {
            target.Top += deflation.Top;
            target.Left += deflation.Left;
            target.Bottom -= deflation.Bottom;
            target.Right -= deflation.Right;
        }

        public static void Inflate(ref Rectangle target, ref Rectangle inflation)
        {
            target.Top -= inflation.Top;
            target.Left -= inflation.Left;
            target.Bottom += inflation.Bottom;
            target.Right += inflation.Right;
        }

        public static void Offset(ref Rectangle target, int x, int y)
        {
            target.Top += y;
            target.Left += x;
            target.Bottom += y;
            target.Right += x;
        }

        public static void OffsetTo(ref Rectangle target, int x, int y)
        {
            int width = target.Width;
            int height = target.Height;
            target.Left = x;
            target.Top = y;
            target.Right = width;
            target.Bottom = height;
        }

        public static void Scale(ref Rectangle target, int x, int y)
        {
            target.Top *= y;
            target.Left *= x;
            target.Bottom *= y;
            target.Right *= x;
        }

        public static void ScaleTo(ref Rectangle target, int x, int y)
        {
            x = target.Left / x;
            y = target.Top / y;
            Rectangle.Scale(ref target, x, y);
        }

        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }
}
