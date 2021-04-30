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
            Menu menu = new Menu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }

            //TableView tv = new TableView();
            //CreateRelation cr = new CreateRelation();
            //tv.ViewCourses();
            //Console.WriteLine();

            //Console.WriteLine();
            //tv.ViewTrainers();
            //Console.WriteLine();
            //tv.ViewAssignments();
            //Console.WriteLine();
            //tv.ViewTrainersPerCourse();
            //tv.ViewStudentsPerCourse();
            //tv.ViewAvailableCourses();
            //cnc.CreateCourse();

            //cnc.CreateStudent();
            //cnc.ViewStudents();
            //cnc.CreateTrainer();
            //tv.ViewTrainers();

            //cr.CreateAvailableCourse();
            //tv.ViewActiveCourses();
            //cr.CreateActiveCourse();

            //cr.CreateActiveAssignment();
        }
    }
}
