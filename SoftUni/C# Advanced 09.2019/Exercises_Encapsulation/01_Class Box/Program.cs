using System;

namespace _01_Class_Box
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);

                var surfaceArea = box.SurfaceArea();
                var lateralSurface = box.LateralSurface();
                var volume = box.Volume();

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurface:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
