using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3._3._2
{
    public enum MonthofAdmission { January, February, March, April, May, June, July, August, September, October, November, December };
    internal class Student
    {
        
        public string FirstName { get; set; }
        public int StudentId { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public char Grade { get; set; }
        public MonthofAdmission MonthOfAdmission { get; set; }

        public static List<Student> Students;

        public static void CreateData()
        {
            Students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", StudentId = 1, Address = "123 Main St", Grade = 'A', MonthOfAdmission = MonthofAdmission.January },
                new Student { FirstName = "Jane", LastName = "Smith", StudentId = 2, Address = "456 Elm St", Grade = 'B', MonthOfAdmission = MonthofAdmission.February },
                new Student { FirstName = "Alice", LastName = "Johnson", StudentId = 3, Address = "789 Oak St", Grade = 'C', MonthOfAdmission = MonthofAdmission.March },
                new Student { FirstName = "Bob", LastName = "Brown", StudentId = 4, Address = "321 Pine St", Grade = 'B', MonthOfAdmission = MonthofAdmission.April },
                new Student { FirstName = "Charlie", LastName = "Davis", StudentId = 5, Address = "654 Maple St", Grade = 'A', MonthOfAdmission = MonthofAdmission.May },
                new Student { FirstName = "Eve", LastName = "Wilson", StudentId = 6, Address = "987 Cedar St", Grade = 'C', MonthOfAdmission = MonthofAdmission.June },
                new Student { FirstName = "Frank", LastName = "Garcia", StudentId = 7, Address = "159 Spruce St", Grade = 'B', MonthOfAdmission = MonthofAdmission.July },
                new Student { FirstName = "Grace", LastName = "Martinez", StudentId = 8, Address = "753 Birch St", Grade = 'A', MonthOfAdmission = MonthofAdmission.August },
                new Student { FirstName = "Hank", LastName = "Lopez", StudentId = 9, Address = "951 Willow St", Grade = 'C', MonthOfAdmission = MonthofAdmission.September },
                new Student { FirstName = "Ivy", LastName = "Gonzalez", StudentId = 10, Address = "852 Fir St", Grade = 'B', MonthOfAdmission = MonthofAdmission.October },

            };
        }
        public static void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public static void DeleteLastStudent()
        {
                Students.RemoveAt(Students.Count - 1);
        }




    }
}
