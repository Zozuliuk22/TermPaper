using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public class TeamLead : RegisteredUser
    {
        protected Sheduler sheduler;

        public TeamLead(Sheduler sheduler)
        {
            this.sheduler = sheduler;
        }

        public void AddTask(string core, int time)
        {
            if (time < 0)
                throw new ArgumentException("The time to complete the task cannot be negative.");
            else if (core == null || core.Length == 0)
                throw new ArgumentException("The core wasn't entered. Please, enter the core.");
            else
            {
                sheduler.tasksUnallocated.Add(new Task(core, time, sheduler.MaxPriorityNow+1));
                sheduler.MaxPriorityNow = sheduler.MaxPriorityNow + 1;
            }
        }

        public void ChangeTask(int id, string core, string time, int priority)
        {
            if (priority > sheduler.MaxPriorityNow)
                throw new ArgumentException("Choose a priority from 1 to " + sheduler.MaxPriorityNow.ToString());
            else
            {
                bool change = false;
                for (int i = 0; i < sheduler.tasksUnallocated.Count; i++)
                {
                    if (sheduler.tasksUnallocated[i].ID == id)
                    {
                        change = true;
                        if(core != "-")
                            sheduler.tasksUnallocated[i].Core = core;
                        if(time != "-")
                            sheduler.tasksUnallocated[i].ExecutionTime = Convert.ToInt32(time);
                        if (sheduler.CheckPriority(priority))
                        {
                            sheduler.DownPriority(priority);
                            sheduler.tasksUnallocated[i].Priority = priority;
                            sheduler.SortTaskByPriority();
                        }
                        else
                            throw new ArgumentException("Task with priority " + priority.ToString() + " is in status 'Doing'. Choose a priority from 1 to " + sheduler.MaxPriorityNow.ToString());
                        break;
                    }
                }

                for (int i = 0; i < sheduler.team.Count; i++)
                {
                    if (sheduler.team[i].TookTasks.Count != 0)
                    {
                        List<Task> temp = sheduler.team[i].TookTasks;
                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (temp[j].ID == id)
                            {
                                change = true;
                                if(core != "-")
                                    temp[j].Core = core;
                                if(time != "-")
                                    temp[j].ExecutionTime = Convert.ToInt32(time);
                                if (sheduler.CheckPriority(priority))
                                {
                                    sheduler.DownPriority(priority);
                                    temp[i].Priority = priority;                                    
                                }
                                else
                                    throw new ArgumentException("Task with priority " + priority.ToString() + " is in status 'Doing'. Choose a priority from 1 to " + sheduler.MaxPriorityNow.ToString());
                                break;
                            }
                        }

                        if (change)
                        {
                            sheduler.team[i].TookTasks = temp;
                            break;
                        }
                    }
                }

                if (!change)
                    throw new ArgumentException("The task with this ID is not created or is not in status 'Doing'.");
            }
        }

        public void DelTask(int id)
        {
            bool del = false;
            for (int i = 0; i < sheduler.tasksUnallocated.Count; i++)
            {
                if (sheduler.tasksUnallocated[i].ID == id)
                {
                    sheduler.UpdateTaskByPriority(sheduler.tasksUnallocated[i].Priority);
                    sheduler.tasksUnallocated.RemoveAt(i);
                    sheduler.MaxPriorityNow = sheduler.MaxPriorityNow - 1;
                    del = true;
                }
            }
            for(int i = 0; i<sheduler.team.Count; i++)
            {
                List<Task> temp = sheduler.team[i].TookTasks;
                for(int j = 0; j<temp.Count; j++)
                {
                    if(temp[j].ID == id)
                    {
                        sheduler.UpdateTaskByPriority(temp[j].Priority);
                        temp.RemoveAt(j);
                        sheduler.MaxPriorityNow = sheduler.MaxPriorityNow - 1;
                        del = true;
                        break;
                    }
                }
                if (del)
                {
                    sheduler.team[i].TookTasks = temp;
                    break;
                }
                else
                {
                    temp = sheduler.team[i].TasksDone;
                    for (int j = 0; j < temp.Count; j++)
                    {
                        if (temp[j].ID == id)
                        {
                            temp.RemoveAt(j);
                            del = true;
                            break;
                        }
                    }
                    if (del)
                    {
                        sheduler.team[i].TasksDone = temp;
                        break;
                    }
                    else
                    {
                        for(i = 0; i<sheduler.team.Count; i++)
                        {
                            if(sheduler.team[i].ActiveTask.ID == id)
                            {
                                sheduler.team[i].ActiveTask = null;
                                del = true;
                                sheduler.MaxPriorityNow = sheduler.MaxPriorityNow - 1;
                                break;
                            }
                        }
                        if (del)
                        {
                            sheduler.team[i].TasksDone = temp;
                            break;
                        }
                    }
                }
                    
            }

            if (!del)
                throw new ArgumentException("The task with this ID is not created.");
        }

        public void GiveTask(int id, string name)
        {
            bool give = false, found = false;

            for (int i = 0; i < sheduler.CountEmployees; i++)
            {
                if (sheduler.team[i].Name == name)
                {
                    for (int j = 0; j < sheduler.tasksUnallocated.Count; j++)
                    {
                        if (sheduler.tasksUnallocated[j].ID == id)
                        {
                            found = true;
                            sheduler.team[i].TakeTask(sheduler.tasksUnallocated[j]);
                            sheduler.tasksUnallocated.RemoveAt(j);
                        }
                    }
                    if (!found)
                        throw new ArgumentException("No task with this id was found.");


                    give = true;
                }
            }

            if (!give)
                throw new ArgumentException("No employee found.");
        }

        public void ReturnTask(int id)
        {
            bool ret = false;
            for (int i = 0; i < sheduler.team.Count; i++)
            {
                List<Task> temp = sheduler.team[i].TookTasks;
                for (int j = 0; j < temp.Count; j++)
                {
                    if (temp[j].ID == id)
                    {
                        sheduler.tasksUnallocated.Add(temp[j]);
                        sheduler.SortTaskByPriority();
                        temp.RemoveAt(j);
                        ret = true;
                        break;
                    }
                }
                if (ret)
                {
                    sheduler.team[i].TookTasks = temp;
                    break;
                }
            }

            if (!ret)
                throw new ArgumentException("The task with this ID is not created or is not issued to the employee.");
        }
        
    }


}
