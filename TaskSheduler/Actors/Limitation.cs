using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSheduler
{
    internal class Limitation
    {
        private string[,] limitation = new string[3, 2] { { "Junior", "3" }, { "Middle", "5" }, { "Senior", "7" } };

        public int this[string index]
        {
            get
            {
                if (index == "Junior")
                    return Convert.ToInt32(limitation[0, 1]);
                else if (index == "Middle")
                    return Convert.ToInt32(limitation[1, 1]);
                else if (index == "Senior")
                    return Convert.ToInt32(limitation[2, 1]);
                else
                    throw new ArgumentException("The entered position is not correct. Enter 'Junior', 'Middle', or 'Senior'.");
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The maximum number of tasks performed cannot be negative.");
                else
                {
                    if (index == "Junior")
                        limitation[0, 1] = value.ToString();
                    else if (index == "Middle")
                        limitation[1, 1] = value.ToString();
                    else if (index == "Senior")
                        limitation[2, 1] = value.ToString();
                }
            }
        }
    }
}
