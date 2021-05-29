using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    internal class Employee : IEmployee
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public int MaxTasks { internal get; set; }

        public int Business
        {
            get
            {
                if (ActiveTask == null)
                    return 0;
                else
                    return Convert.ToInt32((QueueOfTasks.Count + 1) * 1.0 / MaxTasks * 100);
            }
        }

        public Task ActiveTask { get; set; }

        List<Task> QueueOfTasks = new List<Task>();
        List<Task> tasksDone = new List<Task>();

        public List<Task> TookTasks
        {
            get { return QueueOfTasks; }

            set { QueueOfTasks = value; }
        }

        public List<Task> TasksDone
        {
            get
            {
                return tasksDone;
            }
            set
            {
                tasksDone = value;
            }
        }

        internal Employee(string name, string position, int max)
        {
            Name = name;
            Position = position;
            MaxTasks = max;
            ActiveTask = null;
        }

        internal void TakeTask(Task task)
        {
            UpdateEmployee();
            if (Business < 100)
            {
                if (Business == 0)
                {
                    task.Status = "Doing";
                    ActiveTask = task;
                    task.Start = DateTime.Today;
                    task.End = DateTime.Today.AddDays(task.ExecutionTime);
                }
                else
                {
                    if (task.Priority < ActiveTask.Priority)
                    {
                        Task temp = ActiveTask;
                        temp.Status = "Not started";
                        string str = temp.End.Subtract(DateTime.Today).ToString();
                        str = str.Substring(0, str.IndexOf("."));
                        temp.ExecutionTime = Convert.ToInt32(str);
                        QueueOfTasks.Add(temp);
                        task.Status = "Doing";
                        ActiveTask = task;
                        task.Start = DateTime.Today;
                        task.End = DateTime.Today.AddDays(task.ExecutionTime);
                    }
                    else
                        QueueOfTasks.Add(task);
                    SortTaskByPriority();
                }
            }
            else
                throw new ArgumentException("The employee is busy and cannot take the task.");
        }

        private void SortTaskByPriority()
        {
            for (int i = 0; i < QueueOfTasks.Count; i++)
            {
                for (int j = 0; j < QueueOfTasks.Count - 1; j++)
                {
                    if (QueueOfTasks[j].Priority > QueueOfTasks[j + 1].Priority)
                    {
                        Task temp = QueueOfTasks[j];
                        QueueOfTasks[j] = QueueOfTasks[j + 1];
                        QueueOfTasks[j + 1] = temp;
                    }
                }
            }
        }

        internal void UpdateEmployee()
        {
            if(ActiveTask != null)
            {
                try
                {
                    while (DateTime.Compare(DateTime.Today, ActiveTask.End) >= 0)
                    {
                        ActiveTask.Status = "Done";
                        tasksDone.Add(ActiveTask);
                        ActiveTask = null;
                        if (QueueOfTasks.Count > 0)
                        {
                            ActiveTask = QueueOfTasks[0];
                            ActiveTask.Status = "Doing";
                            QueueOfTasks.RemoveAt(0);
                            ActiveTask.Start = tasksDone[tasksDone.Count - 1].End;
                            ActiveTask.End = ActiveTask.Start.AddDays(ActiveTask.ExecutionTime);
                        }
                    }
                }catch(NullReferenceException ex){

                }
            }
        }
    }
}
