using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public class Task
    {
        static int counter = 0;

        internal string Core { get; set; }

        internal string Status { get; set; }

        internal int ExecutionTime { get; set; }

        internal int Priority { get; set; }

        internal int ID { get; set; }

        internal DateTime Start { get; set; }

        internal DateTime End { get; set; }

        internal Task(string core, int time, int priority, string status = "Not started")
        {
            Core = core;
            ExecutionTime = time;
            Status = status;
            counter++;
            ID = counter;
            Priority = priority;
        }
    }
}
