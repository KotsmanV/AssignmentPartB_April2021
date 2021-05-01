using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{
    public class CreateRow
    {
        readonly PrivateSchoolDBEntitiesNew dbContext = new PrivateSchoolDBEntitiesNew();

        //TODO 05: Create Course query
        public void CreateCourse()
        {
            Console.Clear();
            string input;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("NEW COURSE");
            
            Course course = new Course();

            Console.Write("Course title: ");
            Console.ResetColor();
            course.Title = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Part Time\t2. Full Time ");
            Console.ResetColor();
            input = Console.ReadLine();
            if (input == "1")
                course.Type = "Part Time";
            else if (input == "2")
                course.Type = "Full Time";
            else
                course.Type = "";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Theory\t2.Instrument\t3. Ensemble ");
            Console.ResetColor();
            input = Console.ReadLine();

            if (input == "1")
                course.Stream = "Theory";
            else if (input == "2")
                course.Stream = "Instrument";
            else if (input == "3")
                course.Stream = "Ensemble";
            else
                course.Type = "";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commit changes? y/n");
            Console.ResetColor();
            input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changes saved to database.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Changes not committed. Please retry.");
                Console.ResetColor();
            }

            Console.ReadKey();

        }

        //TODO 06: Create Student query
        public void CreateStudent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("NEW STUDENT");
            Console.ResetColor();

            Student student = new Student();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("First name: ");
            Console.ResetColor();
            student.FirstName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Last name: ");
            Console.ResetColor();
            student.LastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Date of birth: ");
            Console.ResetColor();
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Tuition fees:");
            Console.ResetColor();
            student.TuitionFees = decimal.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commit changes? y/n");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changes saved to database.");
                Console.ResetColor();
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Changes not committed. Please retry.");
                Console.ResetColor();
            }
            Console.ReadKey();

        }


        //TODO 07: Create Trainer query
        public void CreateTrainer()
        {
            Console.Clear();
            Trainer trainer = new Trainer();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("NEW TRAINER");

            Console.Write("First name: ");
            Console.ResetColor();
            trainer.FirstName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Last name: ");
            Console.ResetColor();
            trainer.LastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Subject: ");
            Console.ResetColor();
            trainer.Subject = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commit changes? y/n");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.Trainers.Add(trainer);
                dbContext.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changes saved to database.");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Changes not committed. Please retry.");
                Console.ResetColor();
            }

            Console.ReadKey();

        }

        //TODO 08: Create Assignment query
        public void CreateAssignment()
        {
            Assignment assignment = new Assignment();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CREATE NEW ASSIGNMENT");


            Console.Write("Title: ");
            Console.ResetColor();
            assignment.Title = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Description: ");
            Console.ResetColor();
            assignment.Description = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commit changes? y/n");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                    dbContext.Assignments.Add(assignment);
                    dbContext.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changes saved to database.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changes not committed. Please retry.");
                Console.ResetColor();
            }

            Console.ReadKey();

        }
    }
}
