public struct Vec3
{
    public float X, Y, Z;

    public Vec3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    //Adding vectors with a number
    public static Vec3 operator +(Vec3 a, float b)
    {
        Vec3 resultVector = new Vec3(a.X + b, a.Y + b, a.Z + b);
        return resultVector;
    }

    //Subtracting a number from a vector
    public static Vec3 operator -(Vec3 a, float b)
    {
        Vec3 resultVector = new Vec3(a.X - b, a.Y - b, a.Z - b);
        return resultVector;
    }

    //Adding Vectors
    public static Vec3 operator +(Vec3 a, Vec3 b)
    {
        Vec3 resultVector = new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        return resultVector;
    }

    //Subtracting Vectors
    public static Vec3 operator -(Vec3 a, Vec3 b)
    {
        Vec3 resultVector = new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        return resultVector;
    }

    //Unary minus (flipping direction)
    public static Vec3 operator -(Vec3 a)
    {
        Vec3 flippedVector = new Vec3(-a.X, -a.Y, -a.Z);
        return flippedVector;
    }

    //Dot Product
    public static float operator *(Vec3 a, Vec3 b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    //Scalar product
    public static Vec3 operator *(Vec3 a, float b)
    {
        Vec3 resultVector = new Vec3(a.X * b, a.Y * b, a.Z * b);
        return resultVector;
    }

    //Magnitude of a Vector also called Length 
    public float Length()
    {
        double length = Math.Sqrt(X * X + Y * Y + Z * Z);
        return (float)length;
    }

    //Cross product
    public Vec3 Cross(Vec3 a, Vec3 b)
    {
        float crossX = a.Y * b.Z - a.Z * b.Y;
        float crossY = a.X * b.Z - a.Z * b.X;
        float crossZ = a.X * b.Y - a.Y * b.X;

        Vec3 crossProduct = new Vec3(crossX, crossY, crossZ);
        return crossProduct;
    }

    public Vec3 Normalize()
    {
        float magnitude = Length();

        Vec3 normal = new Vec3();

        if (magnitude <= 0)
        {
            return normal;
        }

        normal = new Vec3(X / magnitude, Y / magnitude, Z / magnitude);
        return normal;
    }
}