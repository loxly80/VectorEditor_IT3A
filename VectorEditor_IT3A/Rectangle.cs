using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorEditor_IT3A
{
    public class Rectangle : Object
    {
        public Point Point { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }

        public Rectangle(Point point, float width, float height)
        {
            Point = point;
            Width = width;
            Height = height;
        }

        public Rectangle(Point point, float width, float height, Color color, int lineWidth)
        {
            Point = point;
            Width = width;
            Height = height;
            Color = color;
            LineWidth = lineWidth;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color, LineWidth);
            graphics.DrawRectangle(pen, Point.X, Point.Y, Width, Height);
        }
    }
}
