using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WriteAttribute : ReadAttribute
    {
        public WriteAttribute(string key) : base(key)
        {
        }
    }
}
