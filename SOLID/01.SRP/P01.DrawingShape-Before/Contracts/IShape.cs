namespace _01.SRP.P01.DrawingShape_Before.Contracts
{
    public interface IShape
    {
        void Draw(IRenderer renderer, IDrawingContext drawingContext);
    }
}