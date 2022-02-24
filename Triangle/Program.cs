using System;
using System.Threading;
 
namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите 1 сторону:");
                double side1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите 2 сторону:");
                double side2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите 3 сторону:");
                double side3 = Convert.ToDouble(Console.ReadLine());
                Triangle triangle = new Triangle(side1, side2, side3);
                if (!triangle.TriangleIsValid())
                {
                    Console.WriteLine("Такой треугольник не может существовать");
                }
                else
                {
                    Console.WriteLine(triangle.TriangleTypeDetermination());
                    Console.WriteLine(triangle.TypeAngleDetermination());
                    Console.WriteLine("Площадь треугольника: " + triangle.FindTriangleSquare());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный формат ввода");
            }
            
        }

        
    }
    class Triangle
    {
        public bool TriangleIsValid()
        {
            if ((side1 == 0 || side2 == 0 || side3 == 0) || (side1 < 0 || side2 < 0 || side3 < 0)
               ||(side1+side2) <= side3 || (side1 + side3) <= side2 || (side2 + side3) <= side1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public double side1 { get; set; }
        public double side2 { get; set; }
        public double side3 { get; set; }


        public string TriangleTypeDetermination()
        {
            if ((side1 == side2) && (side2 == side3))
            {
                return "Треугольник равносторонний";
            }
            else if(((side1 == side2) && (side2 != side3)) 
                   ||((side1 == side3) && (side2 != side3)) 
                   ||((side2 == side3) && (side1 != side3)))
            {
                return "Треугольник равнобедреный";
            }
            else
            {
                return "Треугольник разносторонний";
            }
        }
        private static void Sort(double a, double b, double c, out double mx, out double sr, out double mn)
        {
            mx = a;
            if (b > mx) mx = b;
            if (c > mx) mx = c;

            mn = a;
            if (b < mn) mn = b;
            if (c < mn) mn = c;
            sr = a + b + c - mx - mn;
        }
        public string TypeAngleDetermination()
        {
            double d = 0, e = 0, max, srd, min;
            Sort(side1, side2, side3, out max, out min, out srd);
            d = min * min + srd * srd;
            e = max * max;
            if (d > e) return "Остроугольный треугольник";
            else if (d < e) return "Тупоугольный треугольник";
            else return "Прямоугольный треугольник";
        }
        public double FindTriangleSquare()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

    }

}
