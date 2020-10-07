using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _046_Property
{
    /*
     
    프로퍼티
    - get, set 키워드
    - 정보은닉
     
     */

    class AA
    {
        private int num;
        private string name;

        public int NUM 
        {
            get { return num; }
            set { num = value; }
        }

        // 자동 구현 프로퍼티
        public string NAME { get; set; } = "NoName"; // 초기값을 설정할 수 있다.

    }

    class Program
    {
        static void Main(string[] args)
        {
            AA aa = new AA() { NAME = "JACK" };
            aa.NUM = 100;

            Console.WriteLine("aa.NUM : {0}", aa.NUM);
            Console.WriteLine("aa.NAME : {0}", aa.NAME);

            while (true) { }
        }
    }
}
