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
            tv.ViewTrainers();

            Console.Write("Select a Course by typing the ID: ");
            courseID = int.Parse(Console.ReadLine());
            
            Console.Write("Select a Trainer by typing the ID: ");
            trainerID = int.Parse(Console.ReadLine());
            
            Console.Write("Starting Date: ");
            startDate = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Ending Date: ");
            endDate = DateTime.Parse(Console.ReadLine());

            AvailableCourse ac = new AvailableCourse()
            {
                CourseID = courseID,
                TrainerID = trainerID,
                StartDate = startDate,
                EndDate = endDate
                
            };

            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {            
                dbContext.AvailableCourses.Add(ac);
                dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
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
            Console.Write("Select a Course by typing the ID: ");
            courseID = int.Parse(Console.ReadLine());
            var availableCourse = dbContext.AvailableCourses.Where(ac => ac.ID == courseID).FirstOrDefault();

            while(isInt)
            {
                Console.Clear();

                tv.ViewStudents();

                Console.WriteLine("Pick a student by typing in the ID: ");
                Console.WriteLine("Any other key stops the process.");
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

            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();
            

        }

        //TODO 13: Match Assingments to Courses and Students
        public void CreateActiveAssignment()
        {
            string courseTitle;
            int assignmentID;

            Console.Clear();

            tv.ViewActiveCourses();


            Console.WriteLine("Select a Course by typing the Title: ");
            Console.WriteLine("Be exact in typing");
            courseTitle = Console.ReadLine();

            var activeCourses = (
                         from actCrs in dbContext.ActiveCourses
                         join crs in dbContext.Courses on actCrs.CourseID equals crs.ID
                         join avlCrs in dbContext.AvailableCourses on actCrs.CourseID equals avlCrs.CourseID
                         where crs.Title == courseTitle
                         select actCrs
                         ).ToList();

            tv.ViewAssignments();
            Console.WriteLine("Select an assignment type by typing in the ID");
            assignmentID = int.Parse(Console.ReadLine());
            var assignment = (
                                from ass in dbContext.Assignments
                                where ass.ID == assignmentID
                                select ass
                              ).FirstOrDefault();

            Console.Write("Input Submission Date (yyyy/mm/dd): ");
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


            Console.WriteLine("Commit changes? y/n");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("y"))
            {
                dbContext.SaveChanges();
            }
            else
                Console.WriteLine("Changes not committed. Please retry.");
            Console.ReadKey();

        }


    }
}
