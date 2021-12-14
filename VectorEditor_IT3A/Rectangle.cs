using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorEditor_IT3A
{
    public class Rectangle : Object
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }

        public Rectangle(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
            LineWidth = 1;
            Color = Color.Black;
        }

        public Rectangle(Point point1, Point point2, Color color, int lineWidth)
        {
            Point1 = point1;
            Point2 = point2;
            Color = color;
            LineWidth = lineWidth;
        }

        public override void Draw(Graphics graphics)
        {
            float x;
            float y;
            if (Point1.X < Point2.X)
            {
                x = Point1.X;
            }
            else
            {
                x = Point2.X;
            }
            if (Point1.Y < Point2.Y)
            {
                y = Point1.Y;
            }
            else
            {
                y = Point2.Y;
            }
            Pen pen = new Pen(Color, LineWidth);
            graphics.DrawRectangle(pen, x, y, Math.Abs(Point1.X - Point2.X), Math.Abs(Point1.Y - Point2.Y));
        }
    }
}
