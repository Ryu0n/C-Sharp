using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _040_IsAs
{
    class Program
    {
        /*
         * 
        is 키워드 : 객체의 형식 검사, bool 리턴, 상자 안에 든 실제 객체의 타입 검사
        as 키워드 : 형식 변환, null 리턴

         */

        public static int a;


        static void Main(string[] args)
        {
            //if (a is int)
            //    Console.WriteLine('T');
            //else
            //    Console.WriteLine('F');


            //Base _base = new Base();
            //_base.Print();

            //Base _object = new AA(); // AA 객체로 생성했지만 Base라는 상자에 강제로 쳐넣어서 Base다.
            //_object.Print(); // 그래서 AA 클래스의 멤버에 접근할 수 없다.

            //if (_object is Base)
            //    Console.WriteLine("Base");

            //if (_object is AA) // 하지만 상자안에 든 것은 실제 AA 객체이기 때문에 이 부분은 True
            //    Console.WriteLine("AA");

            //if (_object is BB)
            //    Console.WriteLine("BB");


            //AA _objectA = new AA();
            //_objectA.Print();
            //_objectA.PrintA();

            //if (_objectA is Base) // _objectA는 AA 객체로써 Base 클래스도 상속받기 때문에 True
            //    Console.WriteLine("Base");

            //if (_objectA is AA)
            //    Console.WriteLine("AA");

            //if (_objectA is BB)
            //    Console.WriteLine("BB");

            //Base _objectB = new BB();
            //BB copyB = _objectB as BB; // as키워드는 깊은 복사가 아님.
            ////BB copyB = (BB)_objectB; // 작동은 하나.. 잘못된 캐스팅을 했을 때가 문제다!
            //// 언제일까? BB copyB = (BB)_objectA; : 잘못된 캐스팅을 할 경우.. (AA 클래스를 BB로 캐스팅 하려할 때) 바로 시스템이 멈춰버린다. 
            //// 그래서 잘못된 캐스팅을 하는 경우에도 이를 방지하기 위해 as 키워드를 사용한다.

            ////AA copyA = _objectB as AA;
            ////if (copyA == null)
            ////{
            ////    Console.WriteLine("copyA는 AA객체가 아니므로 null");
            ////    // copyA.PrintA(); // System.NullReferenceException: '개체 참조가 개체의 인스턴스로 설정되지 않았습니다.'
            ////}

            //Base copyA = _objectB as AA;
            //if (copyA != null)
            //{
            //    AA asAA = copyA as AA;
            //    asAA.PrintA();
            //}


            //copyB.num = 10; // _objectB에도 영향을 끼침.

            //if (copyB != null)
            //{
            //    _objectB.Print();
            //    copyB.Print();
            //    copyB.PrintB();
            //}





            // 자식 >> 부모
            Base AA = new AA();
            Base BB = new BB();


            if (AA is Base)
                Console.WriteLine("AA is Base");
            if (AA is AA)
                Console.WriteLine("AA is AA");

            if (BB is Base)
                Console.WriteLine("BB is Base");
            if (BB is BB)
                Console.WriteLine("BB is BB");

            AA.Print();
            //AA.PrintA();

            BB.Print();
            //BB.PrintB();



            // 부모 >> 자식
            AA copyAA = AA as AA;
            BB copyBB = BB as BB;

            copyAA.Print();
            copyAA.PrintA();

            copyBB.Print();
            copyBB.PrintB();

            if (copyAA is Base)
                Console.WriteLine("copyAA is Base");
            if (copyAA is AA)
                Console.WriteLine("copyAA is AA");

            if (copyBB is Base)
                Console.WriteLine("copyBB is Base");
            if (copyBB is BB)
                Console.WriteLine("copyBB is BB");





            // 자식1 <-> 자식2
            AA copyBA = BB as AA;
            BB copyAB = AA as BB;

            // this is null
            if (copyBA != null)
            {
                copyBA.Print();
                copyBA.PrintA();
            }
            
            // this is null
            if (copyAB != null)
            {
                copyAB.Print();
                copyAB.PrintB();
            }




            while (true) { }
        }
    }

    class Base
    {
        public int num;

        public void Print()
        {
            Console.WriteLine(num);
        }
    }

    class AA : Base
    {
        public int a;

        public void PrintA()
        {
            Console.WriteLine(num);
            Console.WriteLine(a);
        }
    }

    class BB : Base
    {
        public int b;

        public void PrintB()
        {
            Console.WriteLine(num);
            Console.WriteLine(b);
        }
    }
}
