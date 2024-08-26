using System.Text;

class Program
{
    static void Main()
    {
        //PrintA();
        //PrintB();
        //var c = PrintC().Result;
        //Console.WriteLine(c);

        Print();
        Console.ReadLine();
    }

    static void Print()
    {
        PrintA();
        PrintB();

        Task.WaitAll(PrintA(), PrintB());
       Thread.Sleep(2000);// force to wait 2 sec
        Console.WriteLine("Print () Completed");
    }
    static async Task PrintA()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"PrintA() : {i}");
            }
        });
        
    }

    static async Task PrintB()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i <= 15; i++)
            {
                Console.WriteLine($"PrintB() : {i}");
            }
        });
    }

    static async Task<string> PrintC()
    {
        return "Hello";
    }

    //static void PrintA()
    //{
    //    for(int i = 0; i <= 10; i++)
    //    {
    //        Console.WriteLine($"PrintA() : {i}");
    //    }
    //}

    //static void PrintB()
    //{
    //    for (int i = 0; i <= 20; i++)
    //    {
    //        Console.WriteLine($"PrintB() : {i}");
    //    }
    //}
}