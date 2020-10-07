using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _043_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            AA aa = new AA();

            Util.Print(aa, "Hello");
            aa.Print("Hello"); // AA클래스에 확장됨

            Util.Sum(10);
            10.Sum(); // int클래스에 확장됨


            BB bb = new BB(10, 20);
            bb.x = 100;
            bb.Print();

            BB bbb;
            bbb.x = 100;
            bbb.y = 200;
            bbb.Print();

            BB copyBB = bb; // Value Type이기 때문에 복사
            copyBB.x = 1000; // Reference가 아닌 Value에 의한 복사이기 때문에 bb에 영향을 끼치지 않다.
            bb.Print();
            copyBB.Print();

            CC cc = new CC(10, 20); // Reference Type이기 때문에 참조
            CC copyCC = cc;
            copyCC.x = 1000; // copyCC의 값을 바꿔도 cc에 영향을 끼친다.
            cc.Print();
            copyCC.Print();

            while (true) { }
        }
    }




    /* 
     
    확장 메소드는 반드시 static class에 정의해야 한다.

    확장 메소드는 파라미터에 this 키워드를 사용한다.
    this 키워드가 붙은 파라미터의 클래스에는 해당 메소드가 확장되게 된다.

    밑의 예시를 보면 AA클래스에는 PrintAA() 메소드밖에 없다.
    Util 클래스에는 Print(this AA) 메소드를 통해 AA클래스에 Print() 메소드를 확장시키고 있다.
    AA클래스의 인스턴스는 PrintAA() 메소드밖에 존재하지 않음에도 불구하고, 확장된 Print() 메소드를 사용할 수 있게 된다.

     */
    class AA
    {
        public void PrintAA(string str)
        {
            Console.WriteLine("PrintAA {0}", str);
        }
    }

    static class Util
    {
        public static void Print(this AA aa, string str)
        {
            aa.PrintAA(str);
        }

        public static void Sum(this int a)
        {
            Console.WriteLine("{0} + {1} = {0}", a, a, a + a);
        }
    }






    /*
     
    빈번하게, 복잡하지 않고 작은 것이라면 Structure를 사용하는게 좋다. (메모리 측면에서도)

    class : 참조(Reference)가 힙에 의해 생성, new 연산자 사용, 파라미터 없는 생성자 가능
    structure : 값(Value)가 스택에 의해 생성, new 연산자 없는 생성 가능, 생성자에 반드시 파라미터가 있어야 함

     */
    struct BB
    {
        public int x;
        public int y;

        public BB(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine("x : {0}, y : {1}", x, y);
        }
    }

    class CC
    {
        public int x;
        public int y;

        public CC(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine("x : {0}, y : {1}", x, y);
        }
    }

}
