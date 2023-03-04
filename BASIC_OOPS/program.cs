using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BASIC_OOPS
{
    public class program
    {
        public static void Main(string[] args)
        {

            //Delegates
            BasicExamples.add a = new BasicExamples.add(BasicExamples.addition);
            Console.WriteLine(a(2, 3));

            //Enums
            //BasicExamples.Level l = BasicExamples.Level.Low;
            Console.WriteLine(BasicExamples.Level.Low);

            //File handling
            StreamWriter sw = new StreamWriter("C://Users/shivaprasad.b/source/repos/BASIC_OOPS/BASIC_OOPS/temp.txt");
            sw.WriteLine("This is file Handling");
            sw.Flush();
            sw.Close();

            //Exception Handling
            try
            {
                throw new Exception("This is exception Handling");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Finally statement");
            }


            //Abstraction
            Rectangle rect = new Rectangle(5, 10);
            rect.Display();

            //Encapsulation
            Employee employee = new Employee();
            employee.Name = "John Doe";
            employee.Age = 30;

            Console.WriteLine("Employee Information:");
            Console.WriteLine("Name: {0}", employee.Name);
            Console.WriteLine("Age: {0}", employee.Age);

            //Inheritance
            Circle c1 = new Circle();
            c1.Radius = 6;
            Console.WriteLine(c1.Area());

            Dog d = new Dog();
            d.Name = "Woofy";
            d.Age = 2;
            d.Eat();
            d.Nurse();
            d.Bark();

            Tesla t = new Tesla("model123", 2022, "india", true, true);

            //Polimorphism
            AdvanceCalculator c = new AdvanceCalculator();
            c.Add(9, 8);
            Console.WriteLine(c.Add(9, 8, 7));
            Console.WriteLine(c.Add("shiva", "prasad"));

            Linque.Examples();
            
        }
    }
}
