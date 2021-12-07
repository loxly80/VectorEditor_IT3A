using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorEditor_IT3A
{
    public class Point : Object
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public Shape Shape { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
            Color = Color.Black;
            Size = 10;
            Shape = Shape.Square;
        }

        public Point(float x, float y, Color color, int size, Shape shape)
        {
            X = x;
            Y = y;
            Color = color;
            Size = size;
            Shape = shape;
        }

        public override void Draw(Graphics graphics)
        {
            if (Shape == Shape.Circle)
            {
                graphics.FillEllipse(new SolidBrush(Color), X - Size / 2, Y - Size / 2, Size, Size);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(Color), X - Size / 2, Y - Size / 2, Size, Size);
            }
        }
    }

    public enum Shape
    {
        Circle,
        Square
    }
}
