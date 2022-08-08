using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Attributes;

namespace Reflection.Models
{
    public class ConfigurationComponentBase
    {
        [Read("Count")] public int Count { get; set; }
        [Write("Amount")] public float Amount { get; set; }
        [Read("Name")] public string? Name { get; set; }
        [Write("Time")] public TimeSpan Time { get; set; }
    }
}
