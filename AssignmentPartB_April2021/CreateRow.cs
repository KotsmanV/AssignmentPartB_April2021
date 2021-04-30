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
            string input;
            Course course = new Course();
            Console.Write("Course title: ");
            course.Title = Console.ReadLine();

            Console.Write("1. Part Time\t2.Full Time ");
            input = Console.ReadLine();
            if (input == "1")
                course.Type = "Part Time";
            else if (input == "2")
                course.Type = "Full Time";
            else
                course.Type = "";

            Console.Write("1. Theory\t2.Instrument\t3. Ensemble ");
            input = Console.ReadLine();

            if (input == "1")
                course.Stream = "Theory";
            else if (input == "2")
                course.Stream = "Instrument";
            else if (input == "3")
                course.Stream = "Ensemble";
            else
                course.Type = "";

            Console.WriteLine("Commit changes? y/n");
            input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();

        }

        //TODO 06: Create Student query
        public void CreateStudent()
        {

            Student student = new Student();

            Console.Write("First name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Last name: ");
            student.LastName = Console.ReadLine();

            Console.Write("Date of birth: ");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Tuition fees:");
            student.TuitionFees = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();

        }


        //TODO 07: Create Trainer query
        public void CreateTrainer()
        {

            Trainer trainer = new Trainer();

            Console.Write("First name: ");
            trainer.FirstName = Console.ReadLine();

            Console.Write("Last name: ");
            trainer.LastName = Console.ReadLine();

            Console.Write("Subject: ");
            trainer.Subject = Console.ReadLine();

            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.Trainers.Add(trainer);
                dbContext.SaveChanges();
                
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();

        }

        //TODO 08: Create Assignment query
        public void CreateAssignment()
        {
            Assignment assignment = new Assignment();

            Console.Write("Title: ");
            assignment.Title = Console.ReadLine();

            Console.Write("Description: ");
            assignment.Description = Console.ReadLine();

            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                    dbContext.Assignments.Add(assignment);
                    dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();

        }
    }
}
