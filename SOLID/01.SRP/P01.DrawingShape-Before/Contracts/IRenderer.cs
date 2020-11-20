namespace _01.SRP.P01.DrawingShape_Before.Contracts
{
    public interface IRenderer
    {
        void Render(IDrawingContext context, IShape shape);
    }
}