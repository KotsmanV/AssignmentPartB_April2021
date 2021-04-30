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

            RandomDataGenerator rDG = new RandomDataGenerator();
            //for (int i = 0; i < 24; i++)
            //{
            //    rDG.CreateRandomStudent();
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    rDG.CreateRandomTrainer();
            //}
            //rDG.RandomAvailableCourse();
            //rDG.RandomActiveCourse();
            //rDG.AddRandomAssignments();


            Menu menu = new Menu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }
        }
    }
}
