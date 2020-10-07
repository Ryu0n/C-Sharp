using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETC_GetterSetter
{
    class Program
    {
        public int variable { get; set; }
        public int Variable { get { return variable + 3; } set { Console.WriteLine("set : " + value); variable -= value; } }


        static void Main(string[] args)
        {
            Program p = new Program();

            p.variable = 1;
            p.Variable = 2; // setter의 value

            Console.WriteLine("{0}, {1}", p.variable, p.Variable);

            while (true)
            {

            }
        }
    }
}
