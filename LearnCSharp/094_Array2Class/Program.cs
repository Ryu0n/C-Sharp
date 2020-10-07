using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _094_Array2Class
{
    class Student
    {
        #region Field
        private int id = 0;
        private List<Subject> infos = null;
        #endregion


        #region Property
        public int ID { get { return id; } }
        public List<Subject> INFOS { get { return infos; } }
        #endregion


        #region InputData
        public void AskID()
        {
            Console.Write("학생의 ID를 입력하세요 : ");
            this.id = int.Parse(Console.ReadLine());
        }

        public void AskSubjectInfo()
        {
            if (INFOS == null)
                this.infos = new List<Subject>();

            SubjectMath math = new SubjectMath();
            SubjectKor korean = new SubjectKor();
            SubjectEng english = new SubjectEng();

            this.infos.Add(math);
            this.infos.Add(korean);
            this.infos.Add(english);
        }
        #endregion


        #region OutputData
        public void ShowStudentInfo()
        {
            Console.WriteLine("ID : {0}", ID);
            
            foreach(Subject subject in INFOS)
            {
                Console.WriteLine("{0} : {1}", subject.NAME, subject.SCORE);
            }
        }
        #endregion


        #region Constructor
        public Student()
        {
            AskID();
            AskSubjectInfo();
        }
        #endregion
    }

    class Subject
    {
        #region Field
        private string name = "NULL";
        private int score = 0;
        #endregion


        #region Property
        public string NAME { get { return name; } }
        public int SCORE { get { return score; } }
        #endregion


        #region InputData
        public virtual void AskSubjectScore()
        {
            Console.Write("{0} 점수를 입력하세요 : ", this.name);
            this.score = int.Parse(Console.ReadLine());
        }

        #endregion

        

        #region Constructor
        protected Subject(string name)
        {
            this.name = name;
        }
        #endregion
    }

    class SubjectMath : Subject
    {
        public SubjectMath() : base("수학") { this.AskSubjectScore(); }
    }

    class SubjectKor : Subject
    {
        public SubjectKor() : base("국어") { this.AskSubjectScore(); }
    }

    class SubjectEng : Subject
    {
        public SubjectEng() : base("영어") { this.AskSubjectScore(); }
    }



    class Program
    {
        static List<Student> students;

        static void Main(string[] args)
        {
            const int TOTAL = 3;

            students = new List<Student>();

            for (int i = 0; i < TOTAL; i++)
            {
                Console.Clear();
                Student student = new Student();
                students.Add(student);
            }

            while(true) 
            {
                Console.Clear();
                Console.WriteLine("조회를 원하는 학생의 아이디를 입력해주세요, (0) 나가기 : ");
                int findID = int.Parse(Console.ReadLine());

                if (findID == 0)
                    break;

                Student student = Search(findID);

                if (student != null && student is Student)
                    student.ShowStudentInfo();
                else
                    Console.WriteLine("존재하지 않는 ID 입니다.");

                Console.ReadLine();
            }
        }

        static Student Search(int findID)
        {
            foreach(Student student in students)
            {
                if (student.ID == findID)
                    return student;
            }

            return null;
        }
    }
}
