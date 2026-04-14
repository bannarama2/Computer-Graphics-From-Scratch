using System.Drawing;

class Program
{

    //Canvas Resolution
    static int canvasWidth = 640;
    static int canvasHeight = 640;

    //Viewport dimensions
    static int viewportWidth = 1;
    static int viewportHeight = 1;

    //book says viewidth viewheight and distance are all going to be 1
    static float distance = 1f;

    //camera position Vec3 with all points at 0
    static Vec3 cameraPos = new Vec3(0, 0, 0);

    //BACKGROUND COLOR
    static Color BACKGROUND_COLOR = Color.White;

    //SPHERES TO BE RENDERED
    static Sphere[] spheresList =
    {
        new Sphere(new Vec3(0, -1, 3), 1, Color.Red),
        new Sphere(new Vec3(2, 0, 4), 1, Color.Blue),
        new Sphere(new Vec3(-2, 0, 4), 1, Color.Green)
    };

    static void Main(string[] args)
    {

        Canvas canvas = new Canvas(canvasWidth, canvasHeight);

        for (int x = -canvasWidth / 2; x <= canvasWidth / 2; x++)
        {
            for (int y = -canvasHeight / 2; y <= canvasHeight / 2; y++)
            {
                Vec3 direction = CanvasToViewport(x, y);
                Color color = TraceRay(cameraPos, direction, 1, float.MaxValue);
                canvas.PutPixel(x, y, color);
            }
        }

        canvas.Save();

    }

    static Vec3 CanvasToViewport(int canvasX, int canvasY)
    {
        float viewportX = canvasX * ((float)viewportWidth / canvasWidth);
        float viewportY = canvasY * ((float)viewportHeight / canvasHeight);

        Vec3 viewport = new Vec3(viewportX, viewportY, distance);
        return viewport;
    }

    static Color TraceRay(Vec3 cameraPos, Vec3 direction, float tMin, float tMax)
    {
        float closestT = float.MaxValue;
        Sphere? closestSphere = null;

        foreach (Sphere sphere in spheresList)
        {
            // (Vec3, Vec3) t1, t2 = IntersectRaySphere(cameraPos, direction, sphere);
            (float first, float second) t = IntersectRaySphere(cameraPos, direction, sphere);

            if (t.first >= tMin && t.first <= tMax && t.first < closestT)
            {
                closestT = t.first;
                closestSphere = sphere;
            }
            else if (t.second >= tMin && t.second <= tMax && t.second < closestT)
            {
                closestT = t.second;
                closestSphere = sphere;
            }
        }

        if (closestSphere != null)
        {
            return closestSphere.Value.color;
        }

        return BACKGROUND_COLOR;
    }

    static (float, float) IntersectRaySphere(Vec3 cameraPos, Vec3 direction, Sphere sphere)
    {
        float r = sphere.radius;
        Vec3 CO = cameraPos - sphere.centerPoint;

        float a = direction * direction;
        float b = direction * CO * (float)2;
        float c = (CO * CO) - r * r;

        float discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            return (float.MaxValue, float.MaxValue);
        }

        float t1 = (-b + (float)Math.Sqrt(discriminant)) * (1 / (2 * a));
        float t2 = (-b - (float)Math.Sqrt(discriminant)) * (1 / (2 * a));

        return (t1, t2);
    }
}