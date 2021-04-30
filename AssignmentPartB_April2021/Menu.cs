using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{
    public class Menu
    {
        private string input;
        private bool showMenu = true;
        private readonly TableView tv = new TableView();
        private readonly CreateRow cRow = new CreateRow();
        private readonly CreateRelation cRelation = new CreateRelation();
        //TODO 10: Create menus
        public bool MainMenu()
        {
            showMenu = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PRIVATE SCHOOL SECRETARY");
            Console.WriteLine("version 2.0\n\n");

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. View entries\n" +
                              "2. Insert\n" +
                              "3. Exit\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                        while (showMenu)
                        showMenu = ViewDataMenu();
                    return true;
                case "2":
                    while (showMenu)
                        showMenu = CreateCourseMenu();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public bool ViewDataMenu()
        {
            showMenu = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("VIEW DATA");
            Console.WriteLine("1. Courses\n" +
                              "2. Trainers\n" +
                              "3. Students\n" +
                              "4. Assignments\n" +
                              "5. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    while (showMenu)
                        showMenu = ViewCourses();
                    return true;
                case "2":
                    while (showMenu)
                        showMenu = ViewTrainers();
                    return true;
                case "3":
                    while (showMenu)
                        showMenu = ViewStudents();
                    return true;
                case "4":
                    while (showMenu)
                        showMenu = ViewAssignments();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        public bool ViewCourses()
        {

            showMenu = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("COURSES");
            Console.WriteLine(" 1. Basic courses\n" +
                              " 2. Available courses\n" +
                              " 3. Active courses\n" +
                              " 4. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    tv.ViewCourses();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "2":
                    tv.ViewAvailableCourses();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "3":
                    tv.ViewActiveCourses();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        public bool ViewTrainers()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TRAINERS");
            Console.WriteLine("1. Trainers\n" +
                              "2. Trainers per course\n" +
                              "3. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    tv.ViewTrainers();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "2":
                    tv.ViewTrainersPerCourse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public bool ViewStudents()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("STUDENTS");
            Console.WriteLine("1. Students\n" +
                              "2. Students per course\n" +
                              "3. Students with multiple courses\n" +
                              "4. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    tv.ViewStudents();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "2":
                    tv.ViewStudentsPerCourse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Feature not yet available");
                    Console.ResetColor();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        public bool ViewAssignments()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ASSIGNMENTS");
            Console.WriteLine("1. Assignment types\n" +
                              "2. Assingments per course\n" +
                              "3. Assignments per student\n" +
                              "4. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    tv.ViewAssignments();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "2":
                    tv.ViewAssignmentsPerCourse();

                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Feature not yet available");
                    //Console.ResetColor();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "3":
                    tv.ViewAssignmentsPerStudent();

                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Feature not yet available");
                    //Console.ResetColor();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        public bool InsertDataMenu()
        {
            Console.Clear();
            showMenu = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("INSERT DATA");
            Console.WriteLine("1. Courses\n" +
                              "2. Trainers\n" +
                              "3. Students\n" +
                              "4. Assignments\n" +
                              "5. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    while (showMenu)
                        showMenu = CreateCourseMenu();
                    return true;
                case "2":
                    while (showMenu)
                        showMenu = CreateTrainerMenu();
                    return true;
                case "3":
                    while (showMenu)
                        showMenu = CreateStudentMenu();
                    return true;
                case "4":
                    while (showMenu)
                        showMenu = CreateAssignmentMenu();
                    return true;
                case "5":
                    return false;
                default:
                    return true;

            }
        }

        private bool CreateAssignmentMenu()
        {
            throw new NotImplementedException();
        }

        private bool CreateStudentMenu()
        {
            throw new NotImplementedException();
        }

        private bool CreateTrainerMenu()
        {
            throw new NotImplementedException();
        }

        private bool CreateCourseMenu()
        {
            showMenu = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CREATE COURSE");
            Console.WriteLine(" 1. Basic course\n" +
                              " 2. Available course: Match Trainers to Course\n" +
                              " 3. Active course: Match Students to Course\n" +
                              " 4. Previous menu\n\n" +
                              "Please enter your choice");
            Console.ResetColor();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    cRow.CreateCourse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "2":
                    cRelation.CreateAvailableCourse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "3":
                    cRelation.CreateActiveCourse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
