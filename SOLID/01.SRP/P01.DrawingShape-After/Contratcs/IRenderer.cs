namespace _01.SRP.P02.DrawingShape_After.Contratcs
{
    public interface IRenderer
    {
        void Render(IDrawingContext drawingContext, IShape shape);
    }
}