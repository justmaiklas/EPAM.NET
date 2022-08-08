using System.Configuration;
using Reflection.Attributes;
using Reflection.Models;

namespace Reflection;

class Program
{
    public static void Main()
    {
        var configurationComponentManger = new ConfigurationComponentManager
        {
            Configuration =
            {
                Time = new TimeSpan(9, 9, 9, 9)
            }
        };
        configurationComponentManger.SaveSettings();
        Console.WriteLine("Done");
    }
}
