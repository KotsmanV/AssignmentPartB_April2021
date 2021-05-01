using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO 16: Fix random courses
            //TODO 17: Fix random assignments
            //TODO 18: Fix random data in general
            //TODO 19: Duplicate data exception
            
            //TODO 20: String format
            //TODO 21: Dates
            //TODO 22: Tuition fees

            Menu menu = new Menu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }
        }
    }
}
