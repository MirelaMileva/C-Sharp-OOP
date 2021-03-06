﻿namespace _01.SRP.P01.DrawingShape_Before
{
    using Contracts;
    class Rectangle
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Area
        {
            get { return this.Width * this.Height; }
        }

        public void Draw(IRenderer render, IDrawingContext context)
        {
            render.Render(context, this);
        }
    }
}