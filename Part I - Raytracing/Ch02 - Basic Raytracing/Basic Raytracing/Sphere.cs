using System.Drawing;

public struct Sphere
{
    public Vec3 centerPoint;
    public float radius;
    public Color color;

    public Sphere(Vec3 centerP, float r, Color c)
    {
        centerPoint = centerP;
        radius = r;
        color = c;
    }
}