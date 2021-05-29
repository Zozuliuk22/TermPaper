using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public class Sheduler
    {
        internal List<Employee> team = new List<Employee>();
        internal List<Task> tasksUnallocated = new List<Task>();
        private int maxPriorityNow = 0;

        public int CountEmployees { get { return team.Count; } }

        internal int MaxPriorityNow
        {
            get { return maxPriorityNow; }
            set { maxPriorityNow = value; }
        }

        public string[,] GetTaskUnallocated()
        {
            ResetStatus();
            UpdateTaskByPriority();
            string[,] data = new string[tasksUnallocated.Count, 5];
            for (int i = 0; i < tasksUnallocated.Count; i++)
            {
                data[i, 0] = tasksUnallocated[i].ID.ToString();
                data[i, 1] = tasksUnallocated[i].Priority.ToString();
                data[i, 2] = tasksUnallocated[i].Core;
                data[i, 3] = tasksUnallocated[i].Status;
                data[i, 4] = tasksUnallocated[i].ExecutionTime.ToString();
            }
            return data;
        }

        public string[] GetEmployee(int index)
        {
            if (index < 0 || index >= CountEmployees)
                throw new ArgumentException("The employee index cannot be negative or greater than the number of employees.");
            else
            {
                ResetStatus();
                UpdateTaskByPriority();
                return new string[] { team[index].Name,
                    team[index].Position,
                    team[index].Business.ToString()};
            }
        }

        public string[] GetEmployee(string name)
        {
            ResetStatus();
            UpdateTaskByPriority();
            bool found = false;
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Name == name)
                {                    
                    found = true;
                    string[] data = new string[3] {team[i].Name,
                        team[i].Position,
                        team[i].Business.ToString() };

                    return data;
                }
            }
            if (!found)
                throw new ArgumentException("No employee found.");
            return null;
        }

        public string[,] GetEmployeeTasks(string name)
        {
            ResetStatus();
            UpdateTaskByPriority();
            bool found = false;
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Name == name)
                {
                    team[i].UpdateEmployee();
                    found = true;
                    if (team[i].Business == 0)
                        throw new ArgumentException("This employee has not tasks.");
                    else
                    {
                        string[,] tasks = new string[team[i].TookTasks.Count + 1, 5];
                        tasks[0, 0] = team[i].ActiveTask.ID.ToString();
                        tasks[0, 1] = team[i].ActiveTask.Priority.ToString();
                        tasks[0, 2] = team[i].ActiveTask.Core;
                        tasks[0, 3] = team[i].ActiveTask.Status;
                        tasks[0, 4] = team[i].ActiveTask.End.Subtract(DateTime.Today).ToString();
                        for (int j = 0; j < team[i].TookTasks.Count; j++)
                        {
                            tasks[j + 1, 0] = team[i].TookTasks[j].ID.ToString();
                            tasks[j + 1, 1] = team[i].TookTasks[j].Priority.ToString();
                            tasks[j + 1, 2] = team[i].TookTasks[j].Core;
                            tasks[j + 1, 3] = team[i].TookTasks[j].Status;
                            tasks[j + 1, 4] = team[i].TookTasks[j].ExecutionTime.ToString();
                        }
                        return tasks;
                    }
                }
            }

            if (!found)
                throw new ArgumentException("No employee found.");
            return null;
        }

        public string[,] GetTaskDone()
        {
            ResetStatus();
            UpdateTaskByPriority();
            if (team.Count > 0)
            {
                string[,] data = new string[0, 6];
                for (int i = 0; i<team.Count; i++)
                {
                    string[,] temp = data;
                    data = new string[temp.GetLength(0) + team[i].TasksDone.Count, 6];
                    for (int j = 0; j < temp.GetLength(0); j++)
                    {
                        for (int k = 0; k < temp.GetLength(1); k++)
                            data[j, k] = temp[j, k];
                    }
                    List<Task> tempDone = team[i].TasksDone;
                    for(int j = temp.GetLength(0), k = 0; j<data.GetLength(0); j++, k++)
                    {
                        data[j, 0] = tempDone[k].ID.ToString();
                        data[j, 1] = "-";
                        data[j, 2] = tempDone[k].Core;
                        data[j, 3] = tempDone[k].Status;
                        data[j, 4] = team[i].Name;
                        data[j, 5] = tempDone[k].End.ToString("d");
                    }
                }
                return data;
            }
            else
                throw new ArgumentException("No employees found.");
        }

        public string[,] GetTaskActive()
        {
            ResetStatus();
            UpdateTaskByPriority();
            if (team.Count > 0)
            {
                string[,] data = new string[0, 6];
                for (int i = 0; i < team.Count; i++)
                {
                    if (team[i].ActiveTask != null)
                    {
                        string[,] temp = data;
                        data = new string[temp.GetLength(0) + 1, 6];
                        for (int k = 0; k < temp.GetLength(0); k++)
                            for (int k2= 0; k2< temp.GetLength(1); k2++)
                                data[k, k2] = temp[k, k2];
                        data[temp.GetLength(0), 0] = team[i].ActiveTask.ID.ToString();
                        data[temp.GetLength(0), 1] = team[i].ActiveTask.Priority.ToString();
                        data[temp.GetLength(0), 2] = team[i].ActiveTask.Core;
                        data[temp.GetLength(0), 3] = team[i].ActiveTask.Status;
                        data[temp.GetLength(0), 4] = team[i].Name;
                        data[temp.GetLength(0), 5] = team[i].ActiveTask.End.Subtract(DateTime.Today).ToString();
                    }
                }
                return data;
            }
            else
                throw new ArgumentException("No employees found.");
        }

        public string[,] GetTaskNotStarted()
        {
            ResetStatus();
            UpdateTaskByPriority();
            string[,] data = new string [tasksUnallocated.Count, 6];
            for(int i = 0; i< tasksUnallocated.Count; i++)
            {
                data[i, 0] = tasksUnallocated[i].ID.ToString();
                data[i, 1] = tasksUnallocated[i].Priority.ToString();
                data[i, 2] = tasksUnallocated[i].Core;
                data[i, 3] = tasksUnallocated[i].Status;
                data[i, 4] = "Unallocated";
                data[i, 5] = tasksUnallocated[i].ExecutionTime.ToString();
            }
            for(int i = 0; i<team.Count; i++)
            {
                if (team[i].TookTasks.Count != 0)
                {
                    string[,] temp = data;
                    data = new string[temp.GetLength(0) + team[i].TookTasks.Count, 6];
                    for (int k = 0; k < temp.GetLength(0); k++)
                        for (int k2 = 0; k2 < temp.GetLength(1); k2++)
                            data[k, k2] = temp[k, k2];
                    for (int k = 0; k < team[i].TookTasks.Count; k++)
                    {
                        data[temp.GetLength(0) + k, 0] = team[i].TookTasks[k].ID.ToString();
                        data[temp.GetLength(0) + k, 1] = team[i].TookTasks[k].Priority.ToString();
                        data[temp.GetLength(0) + k, 2] = team[i].TookTasks[k].Core;
                        data[temp.GetLength(0) + k, 3] = team[i].TookTasks[k].Status;
                        data[temp.GetLength(0) + k, 4] = team[i].Name;
                        data[temp.GetLength(0) + k, 5] = team[i].TookTasks[k].ExecutionTime.ToString();
                    }
                }
            }
            return data;
        }

        private void ResetStatus()
        {
            for(int i = 0; i<team.Count; i++)
            {
                team[i].UpdateEmployee();
            }
        }

        public string AutoGive()
        {            
            int startCountOfTasksUnllocated = tasksUnallocated.Count;
            int startBusiness = 25;
            while(tasksUnallocated.Count > 0 || startBusiness <= 100)
            {
                SortTeamByBusiness();
                AutoGiveToPartOfTeam(startBusiness);
                startBusiness += 25;
            }

            if(tasksUnallocated.Count > 0)
                return "All employees are busy. Given " + (startCountOfTasksUnllocated - tasksUnallocated.Count).ToString() + " tasks.";
            else
                return "Given " + (startCountOfTasksUnllocated - tasksUnallocated.Count).ToString() + " tasks.";
        }

        private void SortTeamByBusiness()
        {
            for(int i = 0; i<team.Count; i++)
            {
                for(int j = 0; j<team.Count-1; j++)
                {
                    if (team[j].Business > team[j + 1].Business)
                    {
                        Employee temp = team[i];
                        team[i] = team[j];
                        team[j] = temp;
                    }
                }
            }
        }

        private void AutoGiveToPartOfTeam(int business)
        {
            for(int i = 0; i<team.Count; i++)
            {
                while(team[i].Business < business && tasksUnallocated.Count > 0)
                {
                    team[i].TakeTask(tasksUnallocated[0]);
                    tasksUnallocated.RemoveAt(0);
                }
            }
        }

        internal void SortTaskByPriority()
        {
            for (int i = 0; i < tasksUnallocated.Count; i++)
            {
                for (int j = 0; j < tasksUnallocated.Count - 1; j++)
                {
                    if (tasksUnallocated[j].Priority > tasksUnallocated[j+1].Priority)
                    {
                        Task temp = tasksUnallocated[j];
                        tasksUnallocated[j] = tasksUnallocated[j + 1];
                        tasksUnallocated[j + 1] = temp;
                    }
                }
            }
        }

        internal void UpdateTaskByPriority(int priority)
        {
            for(int i = 0; i <tasksUnallocated.Count; i++)
            {
                if (tasksUnallocated[i].Priority > priority)
                    tasksUnallocated[i].Priority = tasksUnallocated[i].Priority - 1;
            }
            for(int i = 0; i<team.Count; i++)
            {
                if(team[i].Business >0)
                    if (team[i].ActiveTask.Priority > priority)
                        team[i].ActiveTask.Priority = team[i].ActiveTask.Priority - 1;
            }
            for(int i = 0; i<team.Count; i++)
            {
                List<Task> temp = team[i].TookTasks;
                for (int j = 0; j < temp.Count; j++)
                    if (temp[j].Priority > priority)
                        temp[j].Priority = temp[j].Priority - 1;
                team[i].TookTasks = temp;
            }
            for(int i = 0; i<team.Count; i++)
            {
                List<Task> temp = team[i].TasksDone;
                for (int j = 0; j < temp.Count; j++)
                    if (temp[j].Priority != 0 && temp[j].Priority > priority)
                        temp[j].Priority = temp[j].Priority - 1;
                team[i].TasksDone = temp;
            }
        }

        internal void UpdateTaskByPriority()
        {
            for(int i = 0; i<team.Count; i++)
            {
                List<Task> temp = team[i].TasksDone;
                for(int j = 0; j<temp.Count; j++)
                {
                    if(temp[j].Priority != 0)
                    {
                        UpdateTaskByPriority(temp[j].Priority);
                        temp[j].Priority = 0;
                        MaxPriorityNow = MaxPriorityNow - 1;
                    }
                }
                team[i].TasksDone = temp;
            }
        }

        internal bool CheckPriority(int priority)
        {
            for (int i = 0; i < team.Count; i++)
                if (team[i].Business > 0 && team[i].ActiveTask.Priority == priority)
                    return false;
            return true;
        }

        internal void DownPriority(int priority)
        {
            for (int i = 0; i < tasksUnallocated.Count; i++)
            {
                if (tasksUnallocated[i].Priority >= priority)
                    tasksUnallocated[i].Priority = tasksUnallocated[i].Priority + 1;
            }
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Business > 0)
                    if (team[i].ActiveTask.Priority >= priority)
                        team[i].ActiveTask.Priority = team[i].ActiveTask.Priority + 1;
            }
            for (int i = 0; i < team.Count; i++)
            {
                List<Task> temp = team[i].TookTasks;
                for (int j = 0; j < temp.Count; j++)
                    if (temp[j].Priority >= priority)
                        temp[j].Priority = temp[j].Priority + 1;
                team[i].TookTasks = temp;
            }
            for (int i = 0; i < team.Count; i++)
            {
                List<Task> temp = team[i].TasksDone;
                for (int j = 0; j < temp.Count; j++)
                    if (temp[j].Priority != 0 && temp[j].Priority >= priority)
                        temp[j].Priority = temp[j].Priority + 1;
                team[i].TasksDone = temp;
            }
        }
    }
}
