using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static double X;

        static void Main(string[] args)
        {
            Fibonacci_Method(Z2);
            Console.ReadKey();
        }

        /// <summary>
        /// В программе производится поиск отрезка (A,B),
        /// содержащего точки минимума унимодальной функции F(x),
        /// за N вычислений функции.
        /// Необходимые числа Фибоначчи вычисляются здесь же.
        /// </summary>
        static void Fibonacci_Method(Func<double> Z)
        {
            Console.WriteLine("Поиск методом Фибоначчи");
            int[] F = new int[40];
            double A, B, E,X1, X2, X3, X4 , F2, F4;
            Console.WriteLine("Задайте N");
            int N = int.Parse(Console.ReadLine());
            F[0] = 1;F[1] = 1;
            for (int i = 2; i <= N; i++)
                F[i] = F[i - 1] + F[i - 2];
            Console.WriteLine("Задайте Epsilon");
            E = double.Parse(Console.ReadLine());
            Console.WriteLine("Задайте интервал (A,B)");
            string[] str = Console.ReadLine().Split(' ');
            A = double.Parse(str[0]);
            B = double.Parse(str[1]);
            X1 = A;
            X2 = A + ((B - A) * F[N - 1] + E * Math.Pow(-1, N))/ F[N];X3 = B;
            X = X2;F2 = Z();
            Console.WriteLine("\tТекущий интервал");
            int K = 1; Console.WriteLine($"{X1,-20}\t{X3,-20}");
            while (K <= N)
            {
                X4 = X1 - X2 + X3;
                X = X4; F4 = Z();
                if (F4 > F2)
                {
                    if (X2 < X4)
                    {
                        X3 = X4; 
                    }
                    else
                    {
                        X1 = X4;
                    }
                }
                else
                {
                    if (X2 < X4)
                    {
                        X1 = X2; X2 = X4; F2 = F4;
                    }
                    else
                    {
                        X3 = X2; X2 = X4; F2 = F4; 
                    }
                }
                K++;
                Console.WriteLine($"{X1,-20}\t{X3,-20}");
            }
            Console.WriteLine("\tКонечный интервал");
            Console.WriteLine($"{X1}\t{X3}");
            Console.WriteLine($"Значение функции равно {F2}");
        }
        //Функция f(x)=2∙x^2-e^x.
        static double Z1()
        {
            return 2*Math.Pow(X,2) - Math.Pow(Math.E, X);
        }
        //Функция f(x)=x^4-14∙x^3+60∙x^2-70∙x 
        static double Z2()
        {
            return Math.Pow(X, 4) - 14 * Math.Pow(X, 3) + 60 * Math.Pow(X, 2) - 70 * X;
        }
        //Функция f(x)=2∙x^2-e^x.
        static double Z3()
        {
            return 2 * Math.Pow(X, 2) + 3*Math.Pow(Math.E, -X);
        }
    }
}
