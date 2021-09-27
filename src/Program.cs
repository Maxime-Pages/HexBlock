using System;

namespace HexBloc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur le jeu du Hex");
        // board

        // demande joueur            
                }
    }

    class Hex
    {
        private System.Drawing.PointF[] points;
    private float side;
    private float h;
    private float r;
    private Hexagonal.HexOrientation orientation;
    private float x;
    private float y; 
    
    private void CalculateVertices()
    {
        h = Hexagonal.Math.CalculateH(side);
        r = Hexagonal.Math.CalculateR(side); 
        switch (orientation)
        {       
            case Hexagonal.HexOrientation.Flat:
                // x,y coordinates are top left point

                points = new System.Drawing.PointF[6];
                points[0] = new PointF(x, y);
                points[1] = new PointF(x + side, y);
                points[2] = new PointF(x + side + h, y + r);
                points[3] = new PointF(x + side, y + r + r);
                points[4] = new PointF(x, y + r + r);
                points[5] = new PointF(x - h, y + r );
                break;
            case Hexagonal.HexOrientation.Pointy:
                //x,y coordinates are top center point

                points = new System.Drawing.PointF[6];
                points[0] = new PointF(x, y);
                points[1] = new PointF(x + r, y + h);
                points[2] = new PointF(x + r, y + side + h);
                points[3] = new PointF(x, y + side + h + h);
                points[4] = new PointF(x - r, y + side + h);
                points[5] = new PointF(x - r, y + h);
                break;
            default:
                throw new Exception("No HexOrientation defined for Hex object.");
        }
    }
}

public enum HexOrientation
{
    Flat = 0,
    Pointy = 1,
}
    }
