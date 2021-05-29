using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    public class Superior : TeamLead
    {
        Limitation limitation = new Limitation();

        public Superior(Sheduler sheduler) : base(sheduler) { }

        public void HireEmployee(string name, string position)
        {
            if (IsName(name))
            {
                if (IsPosition(position))
                    if (!IsHired(name))
                        sheduler.team.Add(new Employee(name, position, limitation[position]));
                    else
                        throw new NamesakeException("An employee with this name is hired.", name, position);
                else
                    throw new ArgumentException("The entered position is not correct. Enter 'Junior', 'Middle', or 'Senior'.");
            }
            else
                throw new ArgumentException("The entered name is not correct. A name cann't be less than 2 symbols.");
        }

        public void FireEmployee(string name)
        {
            if (IsHired(name))
            {
                for (int i = 0; i < sheduler.CountEmployees; i++)
                {
                    if (sheduler.team[i].Name == name)
                    {
                        SaveTasks(i);
                        sheduler.team.RemoveAt(i);
                        break;
                    }
                }
            }
            else
                throw new ArgumentException("No employee with this name was found.");
        }

        private void SaveTasks(int index)
        {
            List<Task> tookTasks = sheduler.team[index].TookTasks;
            for(int i = 0; i<tookTasks.Count; i++)
            {
                sheduler.tasksUnallocated.Add(tookTasks[i]);
            }
            if(sheduler.team[index].ActiveTask != null)
            {
                Task temp = sheduler.team[index].ActiveTask;
                temp.Status = "Not started";
                string str = temp.End.Subtract(DateTime.Today).ToString();
                str = str.Substring(0, str.IndexOf("."));
                temp.ExecutionTime = Convert.ToInt32(str);
                sheduler.tasksUnallocated.Add(temp);
            }
        }

        internal bool IsHired(string name)
        {
            for (int i = 0; i < sheduler.CountEmployees; i++)
            {
                if (sheduler.team[i].Name == name)
                    return true;
            }
            return false;
        }

        private bool IsName(string name)
        {
            if (name == null || name.Length < 2)
                return false;
            else
                return true;
        }

        private bool IsPosition(string position)
        {
            if (position == "Junior" || position == "Middle" || position == "Senior")
                return true;
            else
                return false;
        }

        public void ChangeLimitation(string position, int value)
        {
            limitation[position] = value;
            Update();
        }

        private void Update()
        {
            for (int i = 0; i < sheduler.CountEmployees; i++)
            {
                sheduler.team[i].MaxTasks = limitation[sheduler.team[i].Position];
            }
        }

        public int GetLimitation(string position)
        {
            if (position == "Junior")
                return limitation["Junior"];
            else if (position == "Middle")
                return limitation["Middle"];
            else if (position == "Senior")
                return limitation["Senior"];
            else
                throw new ArgumentException("The entered position is not correct. Enter 'Junior', 'Middle', or 'Senior'.");
        }
    }
}
