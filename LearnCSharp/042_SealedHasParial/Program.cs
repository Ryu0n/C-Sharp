using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _042_SealedHasParial
{
    /*
     
    - sealed 키워드 : 해당 클래스의 자식 클래스부터는 재정의 불가
    - Has-a 관계 : 종속성이 매우 큰 관계
    - partial 키워드 : 클래스를 나누어서 구현, 콘텐츠별 구분해서 코딩 가능

     */

    class Program
    {

        static void Main(string[] args)
        {
            BB bb = new BB();
            bb.SetNum(0, 0);
            bb.SetNum(1, 100);
            bb.SetNum(2, 200);
            bb.SetNum(3, 200);

            bb.Print();






            ObjectA aa = new ObjectA();
            aa.SetNum(10);
            aa.ADD();

            aa.SetNum(100);
            aa.MUL();



            while(true) { }
        }
    }



    // Sealed 키워드
    class AAA
    {
        public virtual void Func() { }
    }

    class BBB : AAA
    {
        public sealed override void Func()
        {
            base.Func();
        }
    }

    
    class CCC : BBB
    {
        //public override void Func() { }
    }





    // Has-A 관계
    class AA
    {
        private int num;

        public void SetNum(int num)
        {
            this.num = num;
        }

        public void Print()
        {
            Console.WriteLine("num:  " + num);
        }
    }

    class BB
    {
        AA[] aa; // AA클래스는 BB클래스에 종속되어 있다. (강한 연관성)

        public BB()
        {
            aa = new AA[5];
        }

        public void SetNum(int index, int num)
        {
            if (index < aa.Length)
            {
                aa[index] = new AA();
                aa[index].SetNum(num);
            }
        }

        public void Print()
        {
            for (int i = 0; i < aa.Length; i++)
            {

                if (null != aa[i])
                    aa[i].Print();
            }
        }
    }




    // partial 키워드




}
