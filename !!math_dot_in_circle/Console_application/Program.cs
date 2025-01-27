using System;

class PointInCircle
{
    static void Main()
    {
        double distance, pointX, pointY, centerX, centerY, radius;
        while (true)
        {
            try
            {
                Console.Write("Введите координату X точки: ");
                pointX = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите координату Y точки: ");
                pointY = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите координату X центра круга: ");
                centerX = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите координату Y центра круга: ");
                centerY = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите радиус круга: ");
                radius = Convert.ToDouble(Console.ReadLine());

                distance = Math.Sqrt(Math.Pow(pointX - centerX, 2) + Math.Pow(pointY - centerY, 2));
                if (distance <= radius)
                {
                    Console.WriteLine("Принадлежит");
                }
                else
                {
                    Console.WriteLine("Не принадлежит");
                }
            }
            catch
            {
                Console.WriteLine("Введено не число");
            }
        }
    }
}