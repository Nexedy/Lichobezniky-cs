using System;

namespace Lichobezniky
{
    class Program
    {
        static double fce(double v)
        {
            return Math.Sin(v);
           
        }
        static double lichobez(double a, double b, int n)
        {
            double součet = 0; //součet funkčních hodnot
            
            double x = a; //bod, ve kterém se počíta funkční hodnota
            double krokH = (b - a) / n; //
            
            součet = (fce(a) + fce(b))/2;
            
            for (int i = 1; i <n;i++)
            {
                x += krokH;
                součet += fce(x);
            }

            return součet * krokH;
        }
        static double simpsonova(double a, double b, int n)
        {
            double součet = 0; //součet funkčních hodnot

            double x = a; //bod, ve kterém se počíta funkční hodnota
            double krokH = (b - a) / n; //
            součet = fce(a) + fce(b);

            /*
                        for (int i = 2; i < n; i+=2)
                        {
                            x += krokH;
                            součet += fce(x)*2;
                        }
                        for (int i = 1; i < n; i += 2)
                        {
                            x += krokH ;
                            součet += fce(x)*4;
                        }*/
            for (int i = 1; i < n; i++)
            {
                x += krokH;
                if (i % 2 == 0) součet += fce(x) * 2;
                else součet += fce(x) * 4;
            }

            return součet * krokH/3;
        }
            static void Main(string[] args)
        {
            Console.WriteLine("NUMERICKÁ INTEGRACE");
            Console.WriteLine();
            Console.Write("Zadej dolní mez intervalu: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Zadej horní mez intervalu: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Zadej dělení intervalu: ");
            int n = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Obsah obrazce ohraničeného grafem fce a osou x na intervalu <{0}; {1}> je: ", a,b);
            Console.WriteLine("Lichoběžníková metoda: {0}", lichobez(a,b,n));
            Console.WriteLine("Simpsonova metoda: {0}", simpsonova(a,b,n));
            
        }
    }
}
