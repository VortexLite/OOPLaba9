using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLaba_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"f(x) = 1/(sqrt(abs(x))) {Trapezoid(func1, 5,10)}");
            Console.WriteLine($"f(x) = 1/(x^2 + 1) {Trapezoid(func2, 7, 14)}");
            Console.WriteLine($"f(x) = 1/ln(x) {Trapezoid(func3, 4, 7)}");
            Console.WriteLine();
            
            MyEvent ev = new MyEvent();
            ev.Keypress += handler;

            ev.Read();

            Console.ReadLine();
        }

        delegate double MathDelegate(double x);
        static double func1(double x) { return 1/(Math.Sqrt(Math.Abs(x))); }
        static double func2(double x) { return 1 / (Math.Pow(x, 2) + 1); }
        static double func3(double x) { return Math.Log(x, Math.E); }

        static double Trapezoid(MathDelegate D, double a, double b, int precision = 100) 
        {
            double h = Math.Abs(b - a) / precision;
            double sum = (D(a) + D(b)) / 2;
            for (double i = a + h; i < b; i += h)
            {
                sum += D(i);
            }
            return h * sum;
        }

        static void handler(string text)
        {
            Console.WriteLine(text);
        }

        delegate void Event(string text);

        class MyEvent
        {
            static public string name = "оман";
            public event Event Keypress;
            public void Read()
            {
                Console.WriteLine("Введіть першу букву");
                while (true) 
                {
                    char symbol = Console.ReadKey(true).KeyChar;
                    Console.Write(symbol);
                    if (symbol == 'Р' || symbol == 'P') 
                    {
                        Keypress(name);
                    }
                }
            }
        }
    }
}
