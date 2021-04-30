using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{
    public class TableView
    {
        readonly PrivateSchoolDBEntitiesNew dbContext = new PrivateSchoolDBEntitiesNew();
        int counter = 1;
        
        
        public void ViewCourses()
        {
            Console.Clear();
            counter = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Courses");
            Console.WriteLine($"{"no",2}\t{"ID",-2}\t{"Title",-20}\t{"Stream",-15}\t{"Type",-15}");
            Console.ResetColor();

            var courses = (
                                from crs in dbContext.Courses
                                orderby crs.Stream ascending, crs.Title ascending
                                select crs
                            ).ToList();
            
            foreach (var course in courses)
            {
                Console.WriteLine($"{counter++,2}\t{course.ID,-2}\t{course.Title,-20}\t{course.Stream,-15}\t{course.Type,-15}");
            }
            Console.WriteLine();
        }

        public void ViewStudents()
        {
            Console.Clear();
            counter = 1;
            var students = (
                                from stu in dbContext.Students
                                orderby stu.LastName, stu.FirstName
                                select stu
                            ).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Students");
            Console.WriteLine($"{"no",2}\t{"ID",-2}\t{"Last Name",-20}\t{"First Name",-15}\t{"Date of Birth",-15}");
            Console.ResetColor();
            foreach (var student in students)
            {
                try
                {
                    Console.WriteLine($"{counter++,-2}\t{student.ID,-2}\t{student.LastName,-20}\t{student.FirstName,-15}\t" +
                              $"{student.DateOfBirth.Value.ToString("d"),-15}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{counter++,-2}\t{student.ID,-2}\t{student.LastName,-20}\t{student.FirstName,-15}\t" +
                                      $"{"Not available",-15}");
                }

            }
            Console.WriteLine();
        }

        public void ViewTrainers()
        {
            Console.Clear();
            counter = 1;
            var trainers = from t in dbContext.Trainers
                                  orderby t.LastName, t.FirstName
                                  select t;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Trainers");
            Console.WriteLine($"{"no",-2}\t{"ID",-2}\t{"LastName",-20}\t{"FirstName",-15}\t{"Subject",-15}");
            Console.ResetColor();
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{counter++,-2}\t{trainer.ID,-2}\t{trainer.LastName,-20}\t{trainer.FirstName,-15}\t{trainer.Subject,-15}");
            }
            Console.WriteLine();
        }

        //TODO 04: View Assignments
        public void ViewAssignments()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Assignment types");
            Console.WriteLine($"{"no",2}\t{"ID",-2}\t{"Title",-20}\t{"Description",-15}");

            Console.ResetColor();

            var assignments = (
                                    from ass in dbContext.Assignments
                                    orderby ass.Title
                                    select ass
                                ).ToList();


            counter = 1;
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"{counter++,-2}\t{assignment.ID,-2}\t{assignment.Title,-20}\t{assignment.Description,-15}");
            }
            Console.WriteLine();
        }

        //TODO 14: Assignments per Course
        public void ViewAssignmentsPerCourse()
        {
            Console.Clear();
            ViewCourses();

            int input;
            Console.Write("Select a course by typing in the ID: ");
            input = int.Parse(Console.ReadLine());

            var course = (
                                from crs in dbContext.Courses
                                where crs.ID == input
                                select crs
                            ).FirstOrDefault();
            var assignments = (
                                    from ass in dbContext.ActiveAssignments
                                    join crs in dbContext.ActiveCourses on ass.CourseID equals crs.ID
                                    join stu in dbContext.Students on ass.StudentID equals stu.ID
                                    where crs.CourseID == course.ID
                                    orderby stu.LastName
                                    select new
                                    {
                                        assID = ass.ID,
                                        assTitle = ass.Assignment.Title,
                                        assSubDate = ass.SubmissionDate,
                                        stuID = stu.ID,
                                        stuLastName = stu.LastName,
                                        stuFirstName = stu.FirstName
                                    }
                                ).Distinct().ToList();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Viewing Assignments per Student for Course with Active ID {course.ID}: {course.Title}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"no",-2} {"sID", -3}  {"Last Name", -15}\t{"First Name", -15}\t{"aID",-3} {"Title",-20}\t{"Submission Date",-18}");
            Console.ResetColor();

            foreach (var assignment in assignments)
                {
                    try
                    {
                        Console.WriteLine($"{counter++,-2} {assignment.stuID, -3} {assignment.stuLastName, -15}\t{assignment.stuFirstName, -15}\t{assignment.assID,-3} {assignment.assTitle,-20}\t{assignment.assSubDate.Value.ToString("d"),-10}");

                    }
                    catch (Exception e)
                    {

                    Console.WriteLine($"{counter++,-2} {assignment.stuID,-3} {assignment.stuLastName,-15}\t{assignment.stuFirstName,-15}\t{assignment.assID,-3} {assignment.assTitle,-20}\t{"Date not available", -18}");
                }
                }
            
        }


        //TODO 15: Assignments per Student
        public void ViewAssignmentsPerStudent()
        {

            Console.Clear();
            ViewStudents();

            int input;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select a student by typing in the ID: ");
            Console.ResetColor();
            input = int.Parse(Console.ReadLine());

            var stud =     (
                                from stu in dbContext.Students
                                where stu.ID == input
                                select stu
                           ).FirstOrDefault();

            var assignments = (
                            from stu in dbContext.Students
                            join aa in dbContext.ActiveAssignments on stu.ID equals aa.StudentID
                            where stu.ID == input
                            orderby aa.Assignment.Title
                            select new
                            {
                                aa.AssignmentID,
                                aa.Assignment.Title,
                                aa.CourseID,
                                CourseTitle = aa.ActiveCourse.AvailableCours.Cours.Title,
                                aa.SubmissionDate
                            }
                        ).ToList();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Assignments for Student ID {stud.ID} : {stud.LastName, -15}, {stud.FirstName, -15}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"no",-2} {"ID", -2}  {"Title", -20}\t{"Course ID", -5}\t{"Course Title", -15}\t{"Submission Date", -20}");
            Console.ResetColor();

            foreach (var assignment in assignments)
            {
                try
                {
                    Console.WriteLine($"{counter++,-2} {assignment.AssignmentID,-2}  {assignment.Title,-20}\t{assignment.CourseID,-5}\t{assignment.CourseTitle,-15}\t{assignment.SubmissionDate.Value.ToString("d"),-20}");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"{counter++,-2} {assignment.AssignmentID,-2}  {assignment.Title,-20}\t{assignment.CourseID,-5}\t{assignment.CourseTitle,-15}\t{"Date not available",-20}");
                }
            }
        }

        //TODO 09: fix where in query
        public void ViewTrainersPerCourse()
        {
            int input;
            ViewAvailableCourses();
            Console.Write("Select a course by typing in the ID: ");
            input = int.Parse(Console.ReadLine());

            //Console.Clear();

            //var query =
            //    (
            //        from trainer in dbContext.Trainers
            //        join availCourse in dbContext.AvailableCourses on trainer.ID equals availCourse.TrainerID
            //        join crs in dbContext.Courses on availCourse.CourseID equals crs.ID
            //        where availCourse.CourseID == input
            //        orderby trainer.LastName
            //        select new
            //        {
            //            crs.Title,
            //            trainer.LastName,
            //            trainer.FirstName,
            //            trainer.Subject
            //        }
            //    ).ToList();

            //counter = 1;

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Trainers per Course");
            //Console.WriteLine($"{"no",-2}  {"Course Title",-15}\t{"Last Name",-20}\t{"First Name",-15}\t{"Subject",-15}");
            //Console.ResetColor();
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{counter++,-2}  {item.Title,-15}\t{item.LastName,-20}\t{item.FirstName,-15}\t{item.Subject,-15}");
            //}
            //Console.WriteLine();
        }


        //TODO 01: View students per course
        public void ViewStudentsPerCourse()
        {
            int input;


            ViewAvailableCourses();
            Console.Write("Select a course by typing in the ID: ");
            input = int.Parse(Console.ReadLine());           
            

            var query =
                (
                    from activeCourse in dbContext.ActiveCourses
                    join student in dbContext.Students on activeCourse.StudentID equals student.ID
                    join crs in dbContext.Courses on activeCourse.CourseID equals crs.ID
                    where crs.ID == input
                    orderby student.LastName
                    select new
                    {
                        crs.Title,
                        student.ID,
                        student.LastName,
                        student.FirstName,
                        student.DateOfBirth,
                        student.TuitionFees
                    }
                ).ToList();

            Console.Clear();

            counter = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Students in selected Course");
            Console.WriteLine($"{"no",-2}  {"Course Title",-15}\t{"Last Name",-15}\t{"First Name",-15}\t{"Subject",-15}");
            Console.ResetColor();
            foreach (var item in query)
            {

                Console.WriteLine($"{counter++,-2}  {item.Title,-15}\t{item.LastName,-15}\t{item.FirstName,-15}\t");
            }
            Console.WriteLine();
        }

        //TODO 03: View Available Courses
        public void ViewAvailableCourses()
        {
            Console.Clear();
            var query =
                (
                    from course in dbContext.Courses
                    join availCourse in dbContext.AvailableCourses on course.ID equals availCourse.CourseID
                    join trainer in dbContext.Trainers on availCourse.TrainerID equals trainer.ID                    
                    orderby course.Title
                    select new
                    {
                        availCourse.ID,
                        course.Title,
                        trainer.LastName,
                        trainer.FirstName,
                        trainer.Subject,
                        availCourse.StartDate,
                        availCourse.EndDate
                    }
                ).ToList();

            counter = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Available Courses and Trainers");
            Console.WriteLine($"{"no",-2}  {"ID", -2}  {"Course Title",-20}\t{"Last Name",-20}\t{"First Name",-15}\t{"Subject",-15}\t{"Start Date", -10}\t{"End Date", -10}");
            Console.ResetColor();
            foreach (var item in query)
            {
                Console.WriteLine($"{counter++,-2}  {item.ID,-2}  {item.Title,-20}\t{item.LastName,-20}\t{item.FirstName,-15}\t{item.Subject,-15}\t{item.StartDate.Value.ToString("d"), -10}\t{item.EndDate.Value.ToString("d"), -10}");
            }
            Console.WriteLine();
        }

        //TODO 02: View Active Courses
        public void ViewActiveCourses()
        {
            Console.Clear();

            var availCrsID = (
                            from activeCourse in dbContext.ActiveCourses
                            //join course in dbContext.Courses on availCourse.CourseID equals course.ID
                            //orderby course.Title
                            select activeCourse.CourseID
                        ).Distinct().ToList();

            counter = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Active Courses");
            Console.WriteLine($"{"no",-2}  {"Course Title",-20}\t{"Last Name",-20}\t{"First Name",-15}\t{"Start Date",-15}\t{"End Date",-15}");
            Console.ResetColor();
            foreach (var id in availCrsID)
            {
                
                    var courseQuery = (
                                        from activeCrs in dbContext.ActiveCourses
                                        join availCrs in dbContext.AvailableCourses on activeCrs.CourseID equals availCrs.CourseID
                                        join crs in dbContext.Courses on activeCrs.CourseID equals crs.ID
                                        where crs.ID == id
                                        select new
                                        {
                                            ActiveCourseID = activeCrs.ID,
                                            Title = crs.Title,
                                            Trainer = availCrs.Trainer,
                                            StartDate = availCrs.StartDate,
                                            EndDate = availCrs.EndDate
                                        }
                                       ).FirstOrDefault();

                    try
                    {
                        Console.WriteLine($"{counter++,-2}  {courseQuery.Title, -20}\t{courseQuery.Trainer.LastName, -20}\t{courseQuery.Trainer.FirstName, -15}" +
                                          $"{courseQuery.StartDate.GetValueOrDefault(defaultValue: new DateTime(01/01/2020)).ToString("d"),-15}\t" +
                                          $"{courseQuery.EndDate.GetValueOrDefault(defaultValue: new DateTime(01/06/2021)).ToString("d"),-15}");
                    }
                    catch (NullReferenceException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"No Course with active ID {id} is available yet.");
                        Console.ResetColor();
                    }
            }
        }
    }
}
