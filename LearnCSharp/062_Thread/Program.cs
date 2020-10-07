using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _062_Thread
{
    // 하나의 프로세스에 대해 멀티 쓰레드

    /*
     
    단일 프로세스에서 다양한 쓰레드를 사용해야 한다는 필요성이 느껴지면..
    쓰레드는 내부적으로 복잡하고 주의해야므로 테스트 해야함.
    
    
    프로세스 : 하나의 실행중인 프로그램
    스케줄링 : 생성 > 준비 > 실행 > 대기 > .. > 종료
    멀티테스킹

    쓰레드
    OS가 CPU시간을 할당하는 기본 단위
    하나 이상의 스레드로 구성

    하나의 프로세스에 대해 여러 쓰레드가 존재한다.
    메인 함수가 실행되는 순간 하나의 쓰레드가 ..
    
    하나 이상의 쓰레드일 경우..
    프로그램이 하나만 실행해도 여러가지 일들을 Concurrently하게 수행된다.



     */




    class Program
    {



        static void RunThread(int index)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: {0} Start", index));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThread index: {0} sec: {1:N2}", index, sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }

            Console.WriteLine(string.Format("RunThread index: {0} End", index));
            Console.WriteLine();
        }

        static void RunThread()
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: 0 Start"));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThread index: {0} sec: {1:N2}", "0", sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }

            Console.WriteLine(string.Format("RunThread index: 0 End"));
            Console.WriteLine();
        }

























        static void Main(string[] args)
        {

        }
    }
}
