using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class Student
    {
        public String studentId;
        public String name;
        public String faculty;
        public float averageScore;


        public Student() { }

        public Student(string studentId, string name, string faculty, float averageScore)
        {
            this.studentId = studentId;
            this.name = name;
            this.faculty = faculty;
            this.averageScore = averageScore;
        }

        public void Input()
        {
            Console.Write("Nhap mssv: ");
            studentId = Console.ReadLine();
            Console.Write("Nhap ho ten sinh vien: ");
            name = Console.ReadLine();
            Console.Write("Nhap khoa: ");
            faculty = Console.ReadLine();
            Console.Write("Nhap DTB: ");
            averageScore = float.Parse(Console.ReadLine());
        }
        public void Output()
        {
            Console.WriteLine("MSSV: " + studentId);
            Console.WriteLine("Ten SV: " + name);
            Console.WriteLine("Khoa: " + faculty);
            Console.WriteLine("DTB: " + averageScore);
        }
    }
}
