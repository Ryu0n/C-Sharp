using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _055_DelegateEvent
{

    /*
     
    델리게이트 & 이벤트

    델리게이트 (delegate) : 특정 함수를 참조 & 콜백이라고도 함
    - 대리자 (메소드 참조형)
    - 메소드의 틀을 만들어 소통
    - 클래스간 통신에 활용 >> 클래스마다 매번 객체를 생성해서 참조하면 비효율적이므로
    
    * 형태
    delegate 리턴형 식별자(파라미터);
    delegate int DelegateFunc(int a);





    델리게이트 선언 방법

    public void Sum(int a, int b) { Console.WriteLine(a + b); }

    delegate void DelegateTest(int a, int b);

    1. 기본 선언
    DelegateTest dt = new DelegateTest(Sum);

    2. 간략한 선언
    DelegateTest dt = Sum;

    3. 익명함수 선언
    DelegateTest dt = delegate (int a, int b) { Console.WriteLine(a + b); }

    4. 람다식 선언
    DelegateTest dt = (a + b) => { Console.WriteLine(a + b); };
     





    
    델리게이트 : 함수 파라미터로써 활용
    - 재사용성 극대화를 위해
    ex) 로그인 시 맞는 정보를 넣으면 OK, 틀린 정보를 넣으면 Cancel

    delegate void delegateFunc();

    delegateFunc CallOkFunc;
    delegateFunc CallCancelFunc;

    public void Message(string msg, delegateFunc okFunc, delegateFunc cancelFunc)





    이벤트
    - delegate 와 차이점
    할당 연산자 사용 불가 (+=, -= 연산자 사용 : 이벤트 변수에 델리게이트 추가 및 삭제)
    클래스 외부 호출 불가 >> 클래스 내부에서 사용 (*제일 중요) : 안정성이 높아짐
    클래스 멤버 필드에서 사용

    public delegate void delegateFunc(string msg);

    public event delegateFunc myEvent;

     */



    delegate void delegateFunc();


    class MessageProcess
    {
        delegateFunc CallOkFunc;
        delegateFunc CallCancelFunc;

        public void Message(string msg, delegateFunc okFunc, delegateFunc cancelFunc)
        {
            CallOkFunc = okFunc;
            CallCancelFunc = cancelFunc;

            Console.WriteLine("Message: " + msg + " (0: ok,  1: cancel)");

            string inputStr = Console.ReadLine();

            if (inputStr.Equals("0"))
            {
                CallOkFunc();
            }
            else
            {
                CallCancelFunc();
            }
        }
    }






    public delegate void delegateEvent(string msg);

    class InDelegate
    {
        public delegateEvent myDelegate;
        public event delegateEvent myEvent;

        public void DoEvent(int a, int b)
        {
            if (null != myEvent)
                myEvent("DoEvent: " + (a + b)); //== ConsoleFunc("DoEvent: " + (a + b));
        }
    }








    delegate void DelegateFunc(int a, int b);

    class Program
    {
        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }








        static void CallOK()
        {
            Console.WriteLine("CallOK");
        }

        static void CallCancel()
        {
            Console.WriteLine("CallCancel");
        }







        static public void ConsoleFunc(string msg)
        {
            Console.WriteLine("ConsoleFunc : " + msg);
        }








        static void Main(string[] args)
        {
            DelegateFunc delegateFunc = Add;
            delegateFunc(10, 20);

            delegateFunc = delegate (int a, int b)
            {
                Console.WriteLine(a - b);
            };
            delegateFunc(30, 10);







            // 델리게이트 : 함수 파라미터로써 활용
            MessageProcess msg = new MessageProcess();
            msg.Message("Test Msg", CallOK, CallCancel);


            msg.Message("Test Msg", 
                delegate ()
                {
                    Console.WriteLine("InDeleagte");
                }
                , CallCancel);







            // 이벤트
            InDelegate id = new InDelegate();

            // 메소드를 참조하고 있는 델리게이트를 추가해도 되고..
            id.myEvent += new delegateEvent(ConsoleFunc);
            // 직접 그 메소드를 추가해도 된다.
            id.myEvent += ConsoleFunc;


            


            // 델리게이트는 외부 클래스로부터 호출할 수 있지만..
            id.myDelegate = ConsoleFunc;
            id.myDelegate("Test");    

            // 이벤트는 외부 클래스로부터 직접 호출할 수 없다.
            // id.myEvent("Test");

            // 그래서 이벤트는 해당 이벤트를 포함하고 있는 클래스의 메소드를 통해 호출해야 한다.
            for (int i = 0; i < 10; i++)
            {
                if (i == 9) id.myEvent -= ConsoleFunc;
                id.DoEvent(i + 1, i + 2);
            }







            while (true) { }
        }
    }
}
