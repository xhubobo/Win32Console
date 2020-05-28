using System;
using Samples.Test;

namespace Samples
{
    class Program
    {
        private const string ExeFileName = "Win32Console.exe";

        static void Main(string[] args)
        {
            StringArraySort.Test(ExeFileName);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}