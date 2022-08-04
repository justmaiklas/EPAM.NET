using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true) {
                try
                {
                    var line = LineReader.ReadLine();
                    Console.WriteLine(line[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }
    }
}