using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASIC_OOPS
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
    public class Linque
    {
        public static void Examples()
        {
            List<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            //where
            List<Student> filteredStudents = studentList.Where(s => s.Age > 10).ToList();
            foreach(Student s in filteredStudents) 
            {
                Console.WriteLine(s.StudentName+" "+s.Age);   
            }

            //orderBy
            List<Student> orderedStudents = studentList.OrderBy(s => s.Age).ToList();
            foreach (Student s in filteredStudents)
            {
                Console.WriteLine(s.StudentName + " " + s.Age);
            }
            orderedStudents = studentList.OrderByDescending(s => s.Age).ToList();
            foreach (Student s in filteredStudents)
            {
                Console.WriteLine(s.StudentName + " " + s.Age);
            }

            //thenBy
            orderedStudents = studentList.OrderByDescending(s => s.Age).ThenBy(s => s.StudentID).ToList();
            foreach (Student s in filteredStudents)
            {
                Console.WriteLine(s.StudentName + " " + s.Age+" "+s.StudentID);
            }


            //group by
            var groupedResult = studentList.GroupBy(s => s.Age);

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key);

                foreach (Student s in ageGroup)  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
            //all
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(areAllStudentsTeenAger);

            //any
            bool areAnyStudentsTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(areAllStudentsTeenAger);

            //INNER JOIN
            List<string> strList1 = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four"
                                        };

            List<string> strList2 = new List<string>() {
                                            "One",
                                            "Two",
                                            "Five",
                                            "Six"
                                        };

            List<string> innerJoin = strList1.Join(strList2, str1 => str1, str2 => str2, (str1, str2) => str1).ToList();
            foreach(string s in innerJoin)
            {
                Console.WriteLine(s);
            }

            //Avg
            List<int> intList = new List<int> () { 10, 20, 30 };
            int avg = ((int)intList.Average());
            Console.WriteLine("Average: {0}", avg);

            //Count
            int count = intList.Count(i=>i>10);
            Console.WriteLine("Count: {0}", count); 

            //MAX
            int max = intList.Max();
            Console.WriteLine("Max: {0}", max);

            //take
            var arr = studentList.Where(s => s.Age > 0).Take(2).ToList();
            foreach(var i in arr)
            {
                Console.WriteLine(i.StudentName);
            }

            //skip
            var arr1 = studentList.Where(s => s.Age > 0).Skip(2).ToList();
            foreach (var i in arr1)
            {
                Console.WriteLine(i.StudentName);
            }
            
            //first
            var first = studentList.First();
            Console.WriteLine(first.StudentName);
            
            //firstORDefault
            var firstD = studentList.FirstOrDefault();
            Console.WriteLine(first.StudentName);

            
        }
    }
}
