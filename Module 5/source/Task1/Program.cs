using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                LineReader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}