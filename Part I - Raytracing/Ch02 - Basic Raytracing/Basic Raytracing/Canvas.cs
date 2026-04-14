using System.Drawing;

public class Canvas
{
    private int WIDTH, HEIGHT;
    Bitmap bitMap;

    public Canvas(int width, int height)
    {
        WIDTH = width;
        HEIGHT = height;

        bitMap = new Bitmap(WIDTH, HEIGHT);

    }


    public void PutPixel(int x, int y, Color color)
    {
        int screenX = WIDTH / 2 + x;
        int screenY = HEIGHT / 2 - y;

        if (screenX < 0 || screenX >= WIDTH || screenY < 0 || screenY >= HEIGHT) return;

        bitMap.SetPixel(screenX, screenY, color);
    }

    public void Save()
    {
        bitMap.Save("C:/Users/ybehe/Documents/My Folders/VS Code files/C# files/Computer Graphics From Scratch/Part I - Raytracing/Ch02 - Basic Raytracing/Basic Raytracing/ImageSaves/img.png");
    }

}