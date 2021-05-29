using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSheduler;

namespace ConsoleUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Sheduler sheduler = new Sheduler();
            Superior superior = new Superior(sheduler);
            TeamLead leader = new TeamLead(sheduler);

            while (true)
            {
                Head();
                StartPage();
                Console.Write("Enter your choice : ");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        return;
                    case "1":
                        Console.Clear();
                        Head();
                        RegistrationMenu();
                        Console.Write("Enter your choice : ");
                        str = Console.ReadLine();
                        switch (str)
                        {
                            case "0":
                                break; 
                            case "1":
                                Console.Clear();
                                Head();
                                Console.WriteLine(String.Format("{0,50}", "Registration of the Superior") + "\n");
                                Console.Write("Enter your name : ");
                                superior.Name = Console.ReadLine();
                                Console.Write("Enter your login : ");
                                superior.Login = Console.ReadLine();
                                Console.Write("Enter your password : ");
                                superior.Password = Console.ReadLine();
                                Console.WriteLine("\nGood!");
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                Head();
                                Console.WriteLine(String.Format("{0,50}", "Registration of the TeamLead") + "\n");
                                Console.Write("Enter your name : ");
                                leader.Name = Console.ReadLine();
                                Console.Write("Enter your login : ");
                                leader.Login = Console.ReadLine();
                                Console.Write("Enter your password : ");
                                leader.Password = Console.ReadLine();
                                Console.WriteLine("\nGood!");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Head();
                        LoginMenu();
                        Console.Write("Enter your choice : ");
                        str = Console.ReadLine();
                        switch (str)
                        {
                            case "0":
                                break;
                            case "1":
                                Console.Clear();
                                Head();
                                Console.Write(String.Format("{0,50}", "LOG IN") + "\n");
                                Console.WriteLine("Status : Superior");
                                Console.Write("Enter your login : ");
                                string login = Console.ReadLine();
                                Console.Write("Enter your password : ");
                                string password = Console.ReadLine();
                                if (superior.Login == login && superior.Password == password)
                                {
                                    Console.WriteLine("\nHello, " + superior.Name + "!");
                                    Console.ReadKey();
                                    Superior(sheduler, superior);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Incorrect login or password.");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case "2":
                                Console.Clear();
                                Head();
                                Console.Write(String.Format("{0,50}", "LOG IN") + "\n");
                                Console.WriteLine("Status : TeamLead");
                                Console.Write("Enter your login : ");
                                login = Console.ReadLine();
                                Console.Write("Enter your password : ");
                                password = Console.ReadLine();
                                if (leader.Login == login && leader.Password == password)
                                {
                                    Console.WriteLine("\nHello, " + leader.Name + "!");
                                    Console.ReadKey();
                                    TeamLead(sheduler, leader);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Incorrect login or password.");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case "3":
                                Console.Clear();
                                Head();
                                Console.WriteLine("Hello, Guest!");
                                Console.ReadKey();
                                Guest(sheduler);
                                break;
                        }
                        break;
                }
                Console.Clear();
            }
        }

        public static void Head()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n");
            Console.WriteLine(String.Format("{0,100}", "===================================================="));
            Console.WriteLine(String.Format("{0, 50}", "||") + String.Format("{0, 50}", "||"));
            Console.WriteLine(String.Format("{0, 50}", "||") + String.Format("{0,32}", "Task Sheduler") + String.Format("{0, 18}", "||"));
            Console.WriteLine(String.Format("{0, 50}", "||") + String.Format("{0, 50}", "||"));
            Console.WriteLine(String.Format("{0,100}", "===================================================="));
            Console.WriteLine("\n\n");
            Console.ResetColor();
        }

        public static void StartPage()
        {
            Console.WriteLine("\t" + String.Format("{0,100}", "Hi there. This is a program for planning tasks and monitoring their implementation. Select the registration function, or continue working as a user."));
            Console.WriteLine();
            Console.WriteLine(String.Format("{0, 40}", "MAIN MENU"));
            Console.WriteLine("1 - Check in");
            Console.WriteLine("2 - Log in");
            Console.WriteLine("0 - Exit\n");
        }

        public static void RegistrationMenu()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0, 40}", "REGISTRATION MENU") + "\n");
            Console.WriteLine("Select the type of profile you want to register\n");
            Console.WriteLine("1 - Superior");
            Console.WriteLine("2 - TeamLead");
            Console.WriteLine("0 - Exit\n");
        }

        public static void LoginMenu()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0, 40}", "LOG IN MENU") + "\n");
            Console.WriteLine("Select the type of profile you want to log in\n");
            Console.WriteLine("1 - Superior");
            Console.WriteLine("2 - TeamLead");
            Console.WriteLine("3 - Guest");
            Console.WriteLine("0 - Exit\n");
        }

        public static void Superior(Sheduler sheduler, Superior superior)
        {
            while (true)
            {
                Console.Clear();
                Head();
                GuestMenu();
                TeamLeadMenu();
                SuperiorMenu();
                Console.WriteLine("0 - EXIT\n");
                Console.Write("Enter your choice : ");
                string str = Console.ReadLine();
                try
                {
                    switch (str)
                    {
                        case "0":
                            return;
                        case "11":
                            string[,] temp = sheduler.GetTaskUnallocated();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unallocated tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,50}", "Core") + "  |   "
                                    + String.Format("{0,25}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "12":
                            temp = sheduler.GetTaskActive();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Active tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0,k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "13":
                            temp = sheduler.GetTaskNotStarted();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not started tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "14":
                            temp = sheduler.GetTaskDone();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Done tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "15":
                            if (sheduler.GetTaskUnallocated().GetLength(0) == 0 &&
                                sheduler.GetTaskActive().GetLength(0) == 0 &&
                                sheduler.GetTaskNotStarted().GetLength(0) == 0 &&
                                sheduler.GetTaskDone().GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no tasks.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                temp = sheduler.GetTaskNotStarted();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskActive();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0, k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskDone();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "16":
                            Console.Write("Enter name of employee : ");
                            string name = Console.ReadLine();
                            string[] temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%");
                            Console.ReadKey();
                            break;
                        case "17":
                            Console.Write("Enter name of employee : ");
                            name = Console.ReadLine();
                            temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%\n\n");
                            temp = sheduler.GetEmployeeTasks(name);
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                + String.Format("{0,10}", "Priority") + "  |   "
                                + String.Format("{0,50}", "Core") + "  |   "
                                + String.Format("{0,25}", "Status") + "  |   "
                                + String.Format("{0,25}", "Execution Time"));
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < temp.GetLength(0); i++)
                            {
                                Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;
                        case "18":
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,25}", "Name") + "  |   "
                                + String.Format("{0,25}", "Position") + "  |   "
                                + String.Format("{0,15}", "Business") );
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            for (int i = 0; i < sheduler.CountEmployees; i++)
                            {
                                temp2 = sheduler.GetEmployee(i);
                                Console.WriteLine(String.Format("{0,25}", temp2[0]) + "  |   "
                                + String.Format("{0,25}", temp2[1]) + "  |   "
                                + String.Format("{0,15}", temp2[2]+"%"));
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;
                        case "21":
                            Console.Write("Enter core : ");
                            string core = Console.ReadLine();
                            string input = "";
                            int time;
                            do
                            {
                                Console.Write("Enter execution time (days) : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out time));
                            superior.AddTask(core, time);
                            Console.WriteLine("\nA new task is created!");
                            Console.ReadKey();
                            break;
                        case "22":
                            Console.WriteLine("     If you do not want to change the characteristics of the task, enter '-'");
                            int id;
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            Console.Write("Enter new core : ");                            
                            string t1 = Console.ReadLine();
                            Console.Write("Enter new time : ");
                            string t2 = Console.ReadLine();
                            int t3;
                            do
                            {
                                Console.Write("Enter new priority : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out t3));
                            superior.ChangeTask(id, t1, t2, t3);
                            Console.ReadKey();
                            break;
                        case "23":
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            superior.DelTask(id);
                            Console.WriteLine("\nThe task is deleted!");
                            Console.ReadKey();
                            break;
                        case "24":
                            Console.WriteLine("Do you want to issue all tasks automatically? (yes/no)");
                            string answer = Console.ReadLine();
                            if(answer.Trim() == "yes")
                            {
                                sheduler.AutoGive();
                            }
                            else
                            {
                                Console.Write("Enter the name : ");
                                name = Console.ReadLine();
                                do
                                {
                                    Console.Write("Enter the ID of the task : ");
                                    input = Console.ReadLine();

                                } while (!Int32.TryParse(input, out id));
                                superior.GiveTask(id, name);
                                Console.WriteLine("\nTask with ID = " + id + " is issued to " + name + "!");
                            }
                            Console.ReadKey();
                            break;
                        case "25":
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            superior.ReturnTask(id);
                            Console.WriteLine("\nThe task has been returned!");
                            Console.ReadKey();
                            break;
                        case "31":
                            Console.Write("Enter name : ");
                            name = Console.ReadLine();
                            Console.Write("Enter position : ");
                            string position = Console.ReadLine();
                            superior.HireEmployee(name, position);
                            Console.WriteLine("\nThe employee was hired!");
                            Console.ReadKey();
                            break;
                        case "32":
                            Console.Write("Enter name : ");
                            name = Console.ReadLine();
                            superior.FireEmployee(name);
                            Console.WriteLine("\nThe employee was fired!");
                            Console.ReadKey();
                            break;
                        case "33":
                            Console.WriteLine("\nJunior = " + superior.GetLimitation("Junior"));
                            Console.WriteLine("Middle = " + superior.GetLimitation("Middle"));
                            Console.WriteLine("Senior = " + superior.GetLimitation("Senior"));
                            Console.ReadKey();
                            break;
                        case "34":
                            Console.Write("Enter the position : ");
                            position = Console.ReadLine();
                            Console.WriteLine("Old value is " + superior.GetLimitation(position));                            
                            int val;
                            do
                            {
                                Console.Write("Enter new value : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out val));
                            superior.ChangeLimitation(position, val);
                            Console.WriteLine("\nData for " + position + " is updated!");
                            Console.ReadKey();
                            break;

                    }

                }
                catch(NamesakeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }catch(ArgumentException ex){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public static void TeamLead(Sheduler sheduler, TeamLead leader)
        {
            while (true)
            {
                Console.Clear();
                Head();
                GuestMenu();
                TeamLeadMenu();
                Console.WriteLine("0 - EXIT\n");
                Console.Write("Enter your choice : ");
                string str = Console.ReadLine();
                try
                {
                    switch (str)
                    {
                        case "0":
                            return;
                        case "11":
                            string[,] temp = sheduler.GetTaskUnallocated();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unallocated tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,50}", "Core") + "  |   "
                                    + String.Format("{0,25}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "12":
                            temp = sheduler.GetTaskActive();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Active tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0, k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "13":
                            temp = sheduler.GetTaskNotStarted();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not started tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "14":
                            temp = sheduler.GetTaskDone();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Done tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "15":
                            if (sheduler.GetTaskUnallocated().GetLength(0) == 0 &&
                                sheduler.GetTaskActive().GetLength(0) == 0 &&
                                sheduler.GetTaskNotStarted().GetLength(0) == 0 &&
                                sheduler.GetTaskDone().GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no tasks.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                temp = sheduler.GetTaskNotStarted();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskActive();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0, k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskDone();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "16":
                            Console.Write("Enter name of employee : ");
                            string name = Console.ReadLine();
                            string[] temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%");
                            Console.ReadKey();
                            break;
                        case "17":
                            Console.Write("Enter name of employee : ");
                            name = Console.ReadLine();
                            temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%\n\n");
                            temp = sheduler.GetEmployeeTasks(name);
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                + String.Format("{0,10}", "Priority") + "  |   "
                                + String.Format("{0,50}", "Core") + "  |   "
                                + String.Format("{0,25}", "Status") + "  |   "
                                + String.Format("{0,25}", "Execution Time"));
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < temp.GetLength(0); i++)
                            {
                                Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;
                        case "18":
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,25}", "Name") + "  |   "
                                + String.Format("{0,25}", "Position") + "  |   "
                                + String.Format("{0,15}", "Business"));
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            for (int i = 0; i < sheduler.CountEmployees; i++)
                            {
                                temp2 = sheduler.GetEmployee(i);
                                Console.WriteLine(String.Format("{0,25}", temp2[0]) + "  |   "
                                + String.Format("{0,25}", temp2[1]) + "  |   "
                                + String.Format("{0,15}", temp2[2] + "%"));
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;
                        case "21":
                            Console.Write("Enter core : ");
                            string core = Console.ReadLine();
                            string input = "";
                            int time;
                            do
                            {
                                Console.Write("Enter execution time (days) : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out time));
                            leader.AddTask(core, time);
                            Console.WriteLine("\nA new task is created!");
                            Console.ReadKey();
                            break;
                        case "22":
                            Console.WriteLine("     If you do not want to change the characteristics of the task, enter '-'");
                            int id;
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            Console.Write("Enter new core : ");
                            string t1 = Console.ReadLine();
                            Console.Write("Enter new time : ");
                            string t2 = Console.ReadLine();
                            int t3;
                            do
                            {
                                Console.Write("Enter new priority : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out t3));
                            leader.ChangeTask(id, t1, t2, t3);
                            Console.ReadKey();
                            break;
                        case "23":
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            leader.DelTask(id);
                            Console.WriteLine("\nThe task is deleted!");
                            Console.ReadKey();
                            break;
                        case "24":
                            Console.WriteLine("Do you want to issue all tasks automatically? (yes/no)");
                            string answer = Console.ReadLine();
                            if (answer.Trim() == "yes")
                            {
                                sheduler.AutoGive();
                            }
                            else
                            {
                                Console.Write("Enter the name : ");
                                name = Console.ReadLine();
                                do
                                {
                                    Console.Write("Enter the ID of the task : ");
                                    input = Console.ReadLine();

                                } while (!Int32.TryParse(input, out id));
                                leader.GiveTask(id, name);
                                Console.WriteLine("\nTask with ID = " + id + " is issued to " + name + "!");
                            }
                            Console.ReadKey();
                            break;
                        case "25":
                            do
                            {
                                Console.Write("Enter the ID of the task : ");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out id));
                            leader.ReturnTask(id);
                            Console.WriteLine("\nThe task has been returned!");
                            Console.ReadKey();
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public static void Guest(Sheduler sheduler)
        {
            while (true)
            {
                Console.Clear();
                Head();
                GuestMenu();
                Console.WriteLine("0 - EXIT\n");
                Console.Write("Enter your choice : ");
                string str = Console.ReadLine();
                try
                {
                    switch (str)
                    {
                        case "0":
                            return;
                        case "11":
                            string[,] temp = sheduler.GetTaskUnallocated();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unallocated tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,50}", "Core") + "  |   "
                                    + String.Format("{0,25}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "12":
                            temp = sheduler.GetTaskActive();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Active tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0, k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "13":
                            temp = sheduler.GetTaskNotStarted();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not started tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "14":
                            temp = sheduler.GetTaskDone();
                            if (temp.GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Done tasks is absent.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            Console.ReadKey();
                            break;
                        case "15":
                            if (sheduler.GetTaskUnallocated().GetLength(0) == 0 &&
                                sheduler.GetTaskActive().GetLength(0) == 0 &&
                                sheduler.GetTaskNotStarted().GetLength(0) == 0 &&
                                sheduler.GetTaskDone().GetLength(0) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no tasks.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                    + String.Format("{0,10}", "Priority") + "  |   "
                                    + String.Format("{0,40}", "Core") + "  |   "
                                    + String.Format("{0,20}", "Status") + "  |   "
                                    + String.Format("{0,25}", "Employee") + "  |   "
                                    + String.Format("{0,15}", "Execution Time"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                temp = sheduler.GetTaskNotStarted();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5] + " days"));

                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskActive();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    int k = temp[i, 5].IndexOf(".");
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                  + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                  + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                  + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                  + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                  + String.Format("{0,15}", temp[i, 5].Substring(0, k) + " days"));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                temp = sheduler.GetTaskDone();
                                for (int i = 0; i < temp.GetLength(0); i++)
                                {
                                    Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,40}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,20}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4]) + "  |   "
                                   + String.Format("{0,15}", temp[i, 5]));
                                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.ReadKey();
                            break;
                        case "16":
                            Console.Write("Enter name of employee : ");
                            string name = Console.ReadLine();
                            string[] temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%");
                            Console.ReadKey();
                            break;
                        case "17":
                            Console.Write("Enter name of employee : ");
                            name = Console.ReadLine();
                            temp2 = sheduler.GetEmployee(name);
                            Console.WriteLine("\nName : " + temp2[0]);
                            Console.WriteLine("Position : " + temp2[1]);
                            Console.WriteLine("Business : " + temp2[2] + "%\n\n");
                            temp = sheduler.GetEmployeeTasks(name);
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,5}", "ID") + "  |   "
                                + String.Format("{0,10}", "Priority") + "  |   "
                                + String.Format("{0,50}", "Core") + "  |   "
                                + String.Format("{0,25}", "Status") + "  |   "
                                + String.Format("{0,25}", "Execution Time"));
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < temp.GetLength(0); i++)
                            {
                                Console.WriteLine(String.Format("{0,5}", temp[i, 0]) + "  |   "
                                   + String.Format("{0,10}", temp[i, 1]) + "  |   "
                                   + String.Format("{0,50}", temp[i, 2]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 3]) + "  |   "
                                   + String.Format("{0,25}", temp[i, 4] + " days"));
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;
                        case "18":
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0,25}", "Name") + "  |   "
                                + String.Format("{0,25}", "Position") + "  |   "
                                + String.Format("{0,15}", "Business"));
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            for (int i = 0; i < sheduler.CountEmployees; i++)
                            {
                                temp2 = sheduler.GetEmployee(i);
                                Console.WriteLine(String.Format("{0,25}", temp2[0]) + "  |   "
                                + String.Format("{0,25}", temp2[1]) + "  |   "
                                + String.Format("{0,15}", temp2[2] + "%"));
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.ReadKey();
                            break;

                    }
                }catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public static void GuestMenu()
        {
            Console.WriteLine(String.Format("{0,50}", "MENU TO DISPLAY INFORMATION") + "\n");
            Console.WriteLine("11 - Show unallocated tasks among employees");
            Console.WriteLine("12 - Show active tasks which are in status 'Doing'");
            Console.WriteLine("13 - Show not started tasks which are in status 'Not started'");
            Console.WriteLine("14 - Show done tasks which are in status 'Done'");
            Console.WriteLine("15 - Show all tasks");
            Console.WriteLine("\n16 - Show brief information about an employee");
            Console.WriteLine("17 - Show full information about an employee");
            Console.WriteLine("18 - Show information about the team\n");
        }

        public static void TeamLeadMenu()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,50}", "TASK MANAGEMENT MENU") + "\n");
            Console.WriteLine("21 - Add a new task");
            Console.WriteLine("22 - Change a task");
            Console.WriteLine("23 - Delete a task");
            Console.WriteLine("24 - Give tasks to the employee");
            Console.WriteLine("25 - Return the issued task");
        }

        public static void SuperiorMenu()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,50}", "MENU FOR WORKING WITH STAFF") + "\n");
            Console.WriteLine("31 - Hire an employee");
            Console.WriteLine("32 - Fire an employee");
            Console.WriteLine("33 - Get information about task restrictions");
            Console.WriteLine("34 - Change task constraint information");
        }

    }
}
