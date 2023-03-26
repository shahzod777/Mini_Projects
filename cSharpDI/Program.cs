
public interface IDraw
{
  void Draw();
}

public class Triangle : IDraw
{
  public void Draw()
  {
    Console.WriteLine("Drawing triangle...");
  }
}

public class Rectangle : IDraw
{
  public void Draw()
  {
    Console.WriteLine("Drawing rectangle...");
  }
}

class Program
{
  public static void Main(string[] args)
  {
    IDraw triangle = new Triangle();
    triangle.Draw();
    IDraw rectangle = new Rectangle();
    rectangle.Draw();
    const int length = 2;
    double width = 12E-5D;
    double Height = 5.1;
    int height = (int) Height;
    Console.WriteLine("{0} {1}", Height, height);
    for(int i = 0; i < 5; i++)
    {
      int h = height;
      h=h&2;
      height = h;
      Console.WriteLine(h);
    }

  }
}

