using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    public static class LineReader
    {
        public static string ReadLine()
        {
            var line = Console.ReadLine();
            if (line == null)
            {
                throw new ArgumentNullException();
            }
            if (line.Trim().Length == 0)
            {
                throw new ArgumentException();
            }

            return line;

        }
    }
}
