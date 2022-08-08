using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReadAttribute : Attribute
    {
        
        public string Key { get; set; }
        public ReadAttribute(string key)
        {
            Key = key;
        }

    }
}
