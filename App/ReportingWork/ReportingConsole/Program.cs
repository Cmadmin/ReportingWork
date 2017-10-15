using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingConsole
{
    class Compute
    {
        public static double Add(int a, int b)
        {
            return a + b;
        }

        public static double Sub(int a, int b)
        {
            return a - b;
        }

        public static double Div(int a, int b)
        {
            return a / b;
        }

        public static double Mult(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        private delegate double ComputeNumber(int no1, int no2);

        private static double DoNumbers(ComputeNumber compute, int no1, int no2)
        {
            return compute(no1, no2);
        } 

        
        static void Main(string[] args)
        {
            //new Thread(DoTask1).Start();

            //new Thread(() =>
            //{
            //    DoTask2("You suck");
            //}).Start();
            // var result = CallWithAsync();
            //Console.WriteLine("main " + result.Result);

            Console.WriteLine("Bull frogs");
            Console.WriteLine("Addition result: " + DoNumbers(Compute.Add, 3, 5));
            Thread.Sleep(1000);

            Console.WriteLine("Bull frogs");
            Console.WriteLine("Subtraction result: " + DoNumbers(Compute.Sub, 7, 5));
            Thread.Sleep(1000);


            Console.WriteLine("Bull frogs");
            Console.WriteLine("Division result: " + DoNumbers(Compute.Div, 7, 5));
            Console.WriteLine("Bell frogs");
            Console.WriteLine("Division result: " + DoNumbers((int a, int b) => a / b, 7, 5));
            Thread.Sleep(1000);

            Console.WriteLine("Bull frogs");
            Console.WriteLine("Multiplication result: " + DoNumbers(Compute.Mult, 7, 5));
            Thread.Sleep(1000);


            Console.ReadKey();
        }

        private static void DoTask1()
        {
            for (var x = 1; x < 50; x++)
            {
                Console.Write(x + ",");
                Thread.Sleep(100);
            }
        }

        private static string DoTask2(string mystring)
        {
            Thread.Sleep(1000);
            Console.WriteLine(mystring);
            Thread.Sleep(1000);
            Console.WriteLine(mystring + " 2");
            return mystring;
        }

        private static Task<string> DoTask3(string mystring)
        {
            DoTask1();
            Console.WriteLine();
            Console.WriteLine("Doing task 3");
            return Task.Run(() => mystring) ;
        }

        private static async Task<string> CallWithAsync()
        {
            var result = await DoTask3("I have completed my work.");
            Console.WriteLine("doing some other stuff");
            Console.WriteLine(result);
            return result;
        }

        private void TestingAsync()
        {
            Thread.Sleep(1000);
            Console.WriteLine("This is just a test 2");
        }
    }
}
