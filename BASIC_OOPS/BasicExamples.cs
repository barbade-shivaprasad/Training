using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BASIC_OOPS
{
    public class BasicExamples
    {   

        //ENUM Declaration
        public enum Level
        {
            Low = 0,
            Medium,
            High
        }




        //Delegate Declation
        public delegate int add(int a, int b);
        public static int addition(int a, int b)
        {
            return a + b;
        }


    }
}
