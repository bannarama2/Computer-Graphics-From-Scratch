public struct Light
{
    public enum Type
    {
        Point,
        Directional,
        Ambient
    }

    public Type lightType;
    public float intensity;
    public Vec3? position;
    public Vec3? direction;

    public Light(Type type, float i, Vec3? pos, Vec3? dir)
    {
        lightType = type;
        intensity = i;
        position = pos;
        direction = dir;
    }
}