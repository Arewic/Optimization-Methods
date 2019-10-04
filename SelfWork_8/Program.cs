using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWork_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a = 0.2");
            Console.WriteLine("b = 1");
            Console.WriteLine("e = 0.0001");
            Console.WriteLine("");
            Console.WriteLine("Метод дихотомии");
            DichotomyMethod(0.2,1,0.0001);
            Console.WriteLine("");
            Console.WriteLine("Метод Ньютона");
            NewtonMethod(0.2, 1, 0.0001);
            Console.ReadKey();
        }
        /// <summary>
        /// Метод дихотомии
        /// </summary>
        /// <param name="a">начало отрезка</param>
        /// <param name="b">конец отрезка</param>
        /// <param name="e">заданная точность</param>
        static void DichotomyMethod(double a, double b, double e)
        {
            int n = 1;
            double x,x1, x2, f1, f2;
            double d = (b - a) * e;
            do
            {
                x1 = (b + a - d) / 2;
                x2 = (b + a + d) / 2;
                f1 = Fn(x1);
                f2 = Fn(x2);
                if (f1 <= f2)
                    b = x2;
                else
                    a = x1;
                n++;
            } while ((b - a) / 2 > e);
            x = (a + b) / 2;
            Console.WriteLine($"x* = {x} , кол-во итераций = {n}");
        }
        /// <summary>
        /// Метод Ньютона
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        public static void NewtonMethod(double a, double b, double e)
        {
            double x;
            int n = 1;
            do
            {
                x = a - Der(a) / DDer(a);
                a = x;
                n++;
            } while (Math.Abs(Der(x)) > e);
            Console.WriteLine($"x* = {x} , кол-во итераций = {n}");
        }

        //Функция 
        static double Fn(double x)
        {
            return x * Math.Sin(1/x);
        }
        //Производная 
        static double Der(double x)
        {
            return Math.Sin(1 / x)- 1/x * Math.Cos(1 / x); 
        }
        //Двойная производная 
        static double DDer(double x)
        {
            return -Math.Sin(1 / x)/Math.Pow(x,3);
        }
    }
}
