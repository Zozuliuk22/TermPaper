using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public interface IEmployee
    {
        string Name { get; set; }

        int Business { get; }

        Task ActiveTask { get; set; }

        List<Task> TookTasks { get; set; }

        List<Task> TasksDone { get; set; }


    }
}
