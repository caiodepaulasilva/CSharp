using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TranscreverNúmeros
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Tradutor tradutor = new Tradutor();
            tradutor.EntrarNumeros();
            tradutor.OrdenarNumeros();
            tradutor.TranscreverNumeros();
        }
    }

    class Tradutor
    {

        int[] numbers;

        Dictionary<int, string> unidades = new Dictionary<int, string>() { { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "trhee" }, { 4, "four" }, { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" }, { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fiveteen" }, { 16, "sixteen" }, { 17, "seventeen" }, { 18, "eighteen" }, { 19, "nineteen" }};
        Dictionary<int, string> x10 = new Dictionary<int, string>() { { 1, "ten" }, { 2, "twenty" }, { 3, "thirty" }, { 4, "forty" }, { 5, "fifty" }, { 6, "sixty" }, { 7, "seventy" }, { 8, "eighty" }, { 9, "ninety" } };
        Dictionary<int, string> x100 = new Dictionary<int, string>() { { 1, "hundred" } };

        public void EntrarNumeros()
        {
            Console.Write($"1 - Define a length of numbers to verify: ");
            int length = int.Parse(Console.ReadLine());
            numbers = new int[length];
            Console.WriteLine("\nSet:");

            for (var number = 0; number < length; number++)
            {
                Console.Write("-");
                numbers.SetValue(int.Parse(Console.ReadLine()), number);
            }
        }

        public void OrdenarNumeros()
        {
            Array.Sort(numbers);
            Console.WriteLine("\n2 - The numbers will be arranged in ascending order");
        }

        public void TranscreverNumeros()
        {
            var value = "";

            void getDec(int number)
            {
              
              
                if (number < 20)
                { Console.WriteLine(unidades.TryGetValue(number, out value) ? value : "non defined"); }

                else
                {
                    if (number % 10 == 0)
                    { Console.WriteLine(x10.TryGetValue(number, out value) ? value : "non defined"); }
                    else
                    {
                         
                        Console.Write(x10.TryGetValue(int.Parse(number.ToString().Substring(0, 1)), out value) ? value  + " ": "non defined");
                        Console.WriteLine(unidades.TryGetValue(int.Parse(number.ToString().Substring(1, 1)),out value) ? value : "non defined" );
                    }
                }
            }
            void getCent(int number)

                
            {
                if (number % 100 == 0)
                {
                    Console.Write(unidades.TryGetValue(int.Parse(number.ToString().Substring(0,1)), out value) ? value  + " ": "non defined");
                    Console.Write(x100.TryGetValue(1, out value) ? value  + " " : "non defined");                   
                }
                else
                {
                    Console.Write(unidades.TryGetValue(int.Parse(number.ToString().Substring(0, 1)), out value) ? value  + " " : "non defined");
                    Console.Write(x100.TryGetValue(1, out value) ? value + " and ": "non defined" );             
                    getDec(int.Parse(number.ToString().Substring(1, 2)));
                }
            }

            Console.WriteLine("\n3 - The organized and transcribed numbers:");
            Console.WriteLine("Get:");

            foreach (var number in numbers)
            {
                if (number < 100)
                {
                    getDec(number);
                }
                else if (number >= 100 && number < 1000)
                {
                    getCent(number);
                }
            }
            Console.ReadLine();
        }
    }
}