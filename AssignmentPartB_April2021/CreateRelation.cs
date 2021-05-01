using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{


    public class CreateRelation
    {
        readonly PrivateSchoolDBEntitiesNew dbContext = new PrivateSchoolDBEntitiesNew();
        readonly TableView tv = new TableView();


        //TODO 11: Match Trainer to Course
        public void CreateAvailableCourse()
        {
            Console.Clear();
            int courseID;
            int trainerID;
            DateTime startDate;
            DateTime endDate;

            tv.ViewCourses();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select a Course by typing the ID: ");
            courseID = int.Parse(Console.ReadLine());
            Console.ResetColor();

            tv.ViewTrainers();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select a Trainer by typing the ID: ");
            Console.ResetColor();
            trainerID = int.Parse(Console.ReadLine());


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Starting Date: ");
            Console.ResetColor();
            startDate = DateTime.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ending Date: ");
            Console.ResetColor();
            endDate = DateTime.Parse(Console.ReadLine());

            AvailableCourse ac = new AvailableCourse()
            {
                CourseID = courseID,
                TrainerID = trainerID,
                StartDate = startDate,
                EndDate = endDate                
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commit changes? y/n");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            
            if (input.Equals("y"))
            {
                try
                {
                    dbContext.AvailableCourses.Add(ac);
                    dbContext.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Changes saved to database.");
                    Console.ResetColor();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entity exists");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Changes not committed. Please retry.");
                Console.ResetColor();
            }

            Console.ReadKey();

        }


        //TODO 12: Match Students to Course
        public void CreateActiveCourse()
        {
            Console.Clear();
            int courseID;
            int studentID;
            bool isInt = true;
            string strInput;

            List<int> userIDs = new List<int>();

            tv.ViewAvailableCourses();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select a Course by typing the ID: ");
            Console.ResetColor();
            courseID = int.Parse(Console.ReadLine());
            var availableCourse = dbContext.AvailableCourses.Where(ac => ac.ID == courseID).FirstOrDefault();

            while(isInt)
            {
                Console.Clear();

                tv.ViewStudents();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Any other key stops the process.");
                Console.Write("Pick a student by typing in the ID: ");

                Console.ResetColor();
                strInput = Console.ReadLine();
                isInt = int.TryParse(strInput, out int output);

                if (output > 0)
                {
                    studentID = output;
                    userIDs.Add(studentID);
                }
                else
                    continue;

            }

            foreach (var id in userIDs)
            {
                ActiveCourse activeCourse = new ActiveCourse()
                {
                    CourseID = availableCourse.CourseID,
                    TrainerID = availableCourse.TrainerID,
                    StudentID = id
                };
                dbContext.ActiveCourses.Add(activeCourse);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Commit changes? y/n ");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
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

        //TODO 13: Match Assingments to Courses and Students
        public void CreateActiveAssignment()
        {
            string courseTitle;
            int assignmentID;

            Console.Clear();

            tv.ViewActiveCourses();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Be exact in typing");
            Console.Write("Select a Course by typing the Title: ");

            Console.ResetColor();
            courseTitle = Console.ReadLine();

            var activeCourses = (
                         from actCrs in dbContext.ActiveCourses
                         join crs in dbContext.Courses on actCrs.CourseID equals crs.ID
                         join avlCrs in dbContext.AvailableCourses on actCrs.CourseID equals avlCrs.CourseID
                         where crs.Title == courseTitle
                         select actCrs
                         ).ToList();

            tv.ViewAssignments();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select an assignment type by typing in the ID:");
            Console.ResetColor();
            assignmentID = int.Parse(Console.ReadLine());
            var assignment = (
                                from ass in dbContext.Assignments
                                where ass.ID == assignmentID
                                select ass
                              ).FirstOrDefault();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Input Submission Date: ");
            Console.ResetColor();
            DateTime subDate = DateTime.Parse(Console.ReadLine());

            foreach (var activeCourse in activeCourses)
            {
                ActiveAssignment activeAssignment = new ActiveAssignment()
                {
                    CourseID = activeCourse.CourseID,
                    StudentID = activeCourse.StudentID,
                    AssignmentID = assignment.ID,
                    SubmissionDate = subDate
                };
                dbContext.ActiveAssignments.Add(activeAssignment);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Commit changes? y/n ");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
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


    }
}
