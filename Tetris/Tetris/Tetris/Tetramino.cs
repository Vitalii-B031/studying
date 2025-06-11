namespace Tetris;

public class Tetramino
{
    public int Y;
    public int X;
    public Point[] Shape;
    public Color Color;
    Random random;

    public Tetramino(Point[] shape, Color color)
    {
        Shape=shape;
        Color=color;
        X = 0;
        Y = 0;
        
    }
    
}