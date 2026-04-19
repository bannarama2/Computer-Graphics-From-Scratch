using System.Drawing;

public struct Sphere
{
    public Vec3 centerPoint;
    public float radius;
    public Color color;
    public float specular;

    public Sphere(Vec3 centerP, float r, Color c, float s)
    {
        centerPoint = centerP;
        radius = r;
        color = c;
        specular = s;
    }
}