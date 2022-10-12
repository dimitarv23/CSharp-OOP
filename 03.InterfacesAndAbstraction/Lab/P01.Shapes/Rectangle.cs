﻿
using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be 0 or negative.");
                }

                width = value;
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be 0 or negative.");
                }

                height = value;
            }
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');

            for (int i = 1; i < this.Height - 1; i++)
            {
                DrawLine(this.Width, '*', ' ');
            }

            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);

            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}
