using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VCManager.Core
{
    public class Student
    {
        public bool IsUfb { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? LastVisited { get; set; }
        public string LectureLastViewed { get; set; }
        public int Progress { get; set; }
        public int QuestionsAsked { get; set; }
        public int QuestionsAnswered { get; set; }
        public DateTime? LastMessaged { get; set; }
        public DateTime Enrolled { get; set; }
        public string StudentName { get; set; }

        // Student Name, Udemy for Business,Enrolled,Started Date, Last Visited,Lecture Last Viewed,
        //Progress,Questions Asked, Questions Answered,Last Messaged
        //Panfeng,False,2017-08-27 06:05:56+00:00,,,,0,0,0,2017-08-27 06:05:56+00:00
        public static Student ParseCsv(string line)
        {
            //var parts = Regex.Split(line, ",(?=(?:[^']*'[^']*')*[^']*$)");
            var parts = line.Split(',');
            return new Student()
            {
                StudentName = parts[0],
                IsUfb = Boolean.Parse(parts[1]),
                Enrolled = DateTime.Parse(parts[2]),
                StartedDate = DateTimeNullIfEmpty(parts[3]),
                LastVisited = DateTimeNullIfEmpty(parts[4]),
                LectureLastViewed = parts[5],
                Progress = Int32.Parse(parts[6]),
                QuestionsAsked = Int32.Parse(parts[7]),
                QuestionsAnswered = Int32.Parse(parts[8]),
                LastMessaged = DateTimeNullIfEmpty(parts[9])
            };
        }

        private static DateTime? DateTimeNullIfEmpty(string str)
        {
            //return DateTime.TryParse(str, out DateTime? dt) ? dt : null;
            if (DateTime.TryParse(str, out DateTime dt))
            {
                return dt;
            }
            return null;
        }


        public static List<Student> GetStudents(string file)
        {
            var fileRecords = File.ReadAllLines(file);
            var result = fileRecords.Where(x => !x.StartsWith("\""));
            File.WriteAllLines(file, result);

            return fileRecords.Skip(1)
                .Select(ParseCsv)
                .ToList();
        }
    }
}
