using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public class NamesakeException : ArgumentException
    {
        public NamesakeException(string message, string name, string position) : base(message)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; set; }

        public string Position { get; set; }
    }
}
