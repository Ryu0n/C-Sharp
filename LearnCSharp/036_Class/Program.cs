using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _036_Class
{
    /*
    
    클래스 : 변수(필드)와 함수(메소드)를 하나의 단위로 결합
    이 변수와 함수들을 통틀어 멤버라고 한다. ex) 멤버 필드, 멤버 메소드 ..

    사용자 정의 자료형이라고도 한다.
    
    상속, 다형성, 파생 클래스

    <접근한정자>
    - public : 액세스가 제한되지 않음
    - protected : 해당 클래스 혹은 해당 클래스에서 파생된 클래스로만 액세스가 제한됨
    - internal : 현재 어셈블리 (.exe, .dll)로만 액세스가 제한됨
    - protected internal : protected + internal
    - private : 해당 클래스만 액세스가 제한됨
    - private protected (?) : 해당 클래스 또는 동일한 어셈블리 내의 포함하는 유형으로부터 파생된 클래스로만 액세스가 제한됨

     */

    class AA
    {
        // 멤버 변수
        int num1; // private
        public int num2, num3;

        // 멤버 메소드
        public void Print()
        {
            Console.WriteLine("a : {0}, b : {1}, c : {2}", num1, num2, num3);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AA aa = new AA();
            //aa.num1 = 10;
            aa.num2 = 100;
            aa.num3 = 1000;

            aa.Print();

            while (true) { }
        }
    }
}
