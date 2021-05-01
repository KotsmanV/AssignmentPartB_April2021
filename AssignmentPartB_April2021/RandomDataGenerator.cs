using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartB_April2021
{
    public class RandomDataGenerator
    {
        readonly PrivateSchoolDBEntitiesNew dbContext = new PrivateSchoolDBEntitiesNew();

        private static Random rnd = new Random();

        private string[] firstNames = { "Frodo", "Merry", "Gandalf", "Logen", "Saruman",
                                        "Roose", "Eddard", "Tyrion", "Galadriel", "Sansa",
                                        "Arya", "Daenerys", "Naomi", "Anna", "Cersei", "Catelyn",
                                        "Robb", "Luthien", "Krisjen", "Natalia", "Bobbie",
                                        "Lyra","Asriel","Stanislaus","Ruta","Mary",
                                        "Frantz","Elio","Oliver","Magdalene","Fernando",
                                        "Giuseppe","Astrid","Jocasta","Antigone","Katie",
                                        "Juliette","Andromeda","Clarissa","Melpomene","Bayaz",
                                        "Ferro","Sophie","Viserys","Jaime","Daario",
                                        "Sandor","Melissandre","Lysa","Fatma","Selyse"
                                        };

        private string[] lastNames = {"Baggins", "Ninefingers","Stark","Lannister","Bolton",
                                      "Mormont","Stormborn","dan Glokta","Sult","Tinuviel",
                                      "Nagata","Holden","Burton","Avasarala","Anarion",
                                      "Coulter","Belacqua","Faa","Grumman","Skadi",
                                      "Bane","Thorne","Baratheon","Verne","Lovecraft",
                                      "Pessoa","Byron","Blake","Curie","Austen",
                                      "Green","Christie","Shelley","Palpatine","Revan", };

        private string[] subjects = { "Theory", "Drums", "Guitar", "Bass", "Vocals", "Rock Ensemble", "Metal Ensemble" };
        private DateTime[] dates = { new DateTime(2020, 9, 15), new DateTime(2021, 1, 15), new DateTime(2021,6,15) };

        private DateTime birthday = new DateTime(1980,1,1);
        private bool exists = false;
        public void CreateRandomStudent()
        {
            Student student = new Student()
            {
                FirstName = firstNames[rnd.Next(0, firstNames.Length)],
                LastName = lastNames[rnd.Next(0, lastNames.Length)],
                DateOfBirth = birthday.AddDays(rnd.Next(0, 8396)),                
                TuitionFees = 2500
            };
            dbContext.Students.Add(student);
            
            
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.DateOfBirth.Value.ToString("d")}");
            Console.ReadKey();
            dbContext.SaveChanges();
        }

        public void CreateRandomTrainer()
        {
            Trainer trainer = new Trainer()
            {
                FirstName = firstNames[rnd.Next(0, firstNames.Length)],
                LastName = lastNames[rnd.Next(0, lastNames.Length)],
                Subject = subjects[rnd.Next(0, subjects.Length)]
            };
            dbContext.Trainers.Add(trainer);
            Console.WriteLine($"{trainer.FirstName} {trainer.LastName} {trainer.Subject}");
            Console.ReadKey();
            dbContext.SaveChanges();
        }

        public void RandomAvailableCourse()
        {
            var trainers = (
                                from tr in dbContext.Trainers
                                select tr
                            ).ToList();

            var courses = (
                            from cr in dbContext.Courses
                            select cr
                            ).ToList();

            foreach (var trainer in trainers)
            {
                foreach (var course in courses)
                {

                    if (trainer.Subject.Trim().Equals(course.Title.Trim()))
                    {
                        AvailableCourse ac = new AvailableCourse();
                        ac.TrainerID = trainer.ID;
                        ac.CourseID = course.ID;

                        ac.Course = (
                                    from crs in dbContext.Courses
                                    where crs.ID == course.ID
                                    select crs
                                    ).FirstOrDefault();
                        ac.Trainer = (
                                        from tr in dbContext.Trainers
                                        where tr.ID == trainer.ID
                                        select tr
                                     ).FirstOrDefault();
                        
                        if (ac.Course.Type.Trim().Equals("Full Time"))
                        {
                            ac.StartDate = dates[0];
                            ac.EndDate = dates[2];
                        }
                        else if(ac.Course.Type.Trim().Equals("Part Time"))
                        {
                            ac.StartDate = dates[rnd.Next(0, 1)];
                            if (ac.StartDate.Equals(dates[0]))
                            {
                                ac.EndDate = dates[1];
                            }
                            else
                                ac.EndDate = dates[2];                            
                        }

                        var availCourses = (
                                            from avCr in dbContext.AvailableCourses
                                            select avCr
                                            ).ToList();
                        exists = false;
                        
                        foreach (var avC in availCourses)
                        {
                            if (ac.CourseID==avC.CourseID)
                            {
                                if (avC.TrainerID == ac.TrainerID)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                        }
                        if (!exists)
                        {
                            dbContext.AvailableCourses.Add(ac);
                            Console.WriteLine("Press key to Add Courses");
                            Console.ReadKey();
                            dbContext.SaveChanges();
                        }
                    }
                }
            }
        }

        public void RandomActiveCourse()
        {
            var courses = (
                            from ac in dbContext.AvailableCourses
                            select ac
                        ).ToList();

            var students = (
                            from stu in dbContext.Students
                            select stu
                            ).ToList();

            foreach (var course in courses)
            {
                foreach (var student in students)
                {
                    var activeCourses = (
                                            from ac in dbContext.ActiveCourses
                                            select ac
                                        ).ToList();

                    for (int i = 0; i < 2; i++)
                    {
                        exists = false;
                        ActiveCourse ac = new ActiveCourse();
                        ac.StudentID = student.ID;
                        var crs = courses[rnd.Next(0, courses.Count)];
                        ac.CourseID = crs.CourseID;
                        ac.TrainerID = crs.TrainerID;

                        foreach (var aCrs in activeCourses)
                        {
                            if (ac.CourseID == aCrs.CourseID)
                            {
                                if (ac.TrainerID == aCrs.TrainerID)
                                {
                                    if (ac.StudentID == aCrs.StudentID)
                                    {
                                        exists = true;
                                    }
                                }
                            }
                        }
                        if (!exists)
                        {
                            dbContext.ActiveCourses.Add(ac);
                            Console.WriteLine("Press key to Add Courses");
                            Console.ReadKey();
                            dbContext.SaveChanges();
                        }
                    }
                }

            }
            Console.WriteLine("Press key to Add Courses");
            Console.ReadKey();
            dbContext.SaveChanges();

        }


        public void AddRandomAssignments()
        {
            var aCrs = (
                            from ac in dbContext.ActiveCourses
                            select ac
                          ).ToList();

            foreach (var aCr in aCrs)
            {
                exists = false;
                ActiveAssignment aa = new ActiveAssignment();
                aa.CourseID = aCr.CourseID;
                aa.StudentID = aCr.StudentID;
                aa.AssignmentID = 1; //final
                aa.SubmissionDate = aCr.AvailableCourse.EndDate.Value.AddDays(-15);
                aa.ActiveCourse = aCr;

                var assign = (
                from ass in dbContext.ActiveAssignments
                select ass
                ).ToList();

                foreach (var ass in assign)
                {
                    if (ass.CourseID == aa.CourseID)
                    {
                        if (ass.StudentID == aa.StudentID)
                        {
                            if (ass.AssignmentID == aa.AssignmentID)
                            {
                                exists = true;
                            }
                        }
                    }
                }
                if (!exists)
                {
                    try
                    {
                        dbContext.ActiveAssignments.Add(aa);
                        Console.WriteLine("Press key to Add Courses");
                        Console.ReadKey();
                        dbContext.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        Console.WriteLine("Entity exists");
                    }

                }

                if (aCr.AvailableCourse.Course.Type.Trim().Equals("Full Time"))
                {
                    exists = false;
                    ActiveAssignment ma = new ActiveAssignment();
                    ma.CourseID = aCr.CourseID;
                    ma.StudentID = aCr.StudentID;
                    ma.AssignmentID = 2; //final
                    ma.SubmissionDate = aCr.AvailableCourse.StartDate.Value.AddMonths(3);


                    var assign2 = (
                                    from ass in dbContext.ActiveAssignments
                                    select ass
                                    ).ToList();


                    foreach (var ass in assign2)
                    {
                        if (ass.CourseID == ma.CourseID)
                        {
                            if (ass.StudentID == ma.StudentID)
                            {
                                if (ass.AssignmentID == ma.AssignmentID)
                                {
                                    exists = true;
                                }
                            }
                        }
                    }
                    if (!exists)
                    {
                        try
                        {
                            dbContext.ActiveAssignments.Add(ma);
                            Console.WriteLine("Press key to Add Courses");
                            Console.ReadKey();
                            dbContext.SaveChanges();
                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException)
                        {
                            Console.WriteLine("Entity exists");
                        }

                    }

                }



            }
        }
    }
}


