using BT2;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BT2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int choice = -1;
            do
            {
                Console.WriteLine("\n\t\t----Chon chuc nang----");
                Console.WriteLine(" ---------------------------------------------------------------");
                Console.WriteLine("|\t1. Them sinh vien                                      |");
                Console.WriteLine("|\t2. Xuat danh sach sinh vien                            |");
                Console.WriteLine("|\t3. Xuat sinh vien thuoc khoa 'CNTT'                    |");
                Console.WriteLine("|\t|4. Xuat sin vien co DTB >= 5                          |");
                Console.WriteLine("|\t5. Xuat sinh vien diem tang dan                        |");
                Console.WriteLine("|\t6. Xuat sinh vien thuoc khoa 'CNTT' && DTB >= 5        |");
                Console.WriteLine("|\t7. Xuat sinh vien co diem cao nhat && thuoc khoa'CNTT' |");
                Console.WriteLine("|\t8. Xep loai sinh vien                                  |");
                Console.WriteLine("|\t0. Thoat                                               |");
                Console.WriteLine(" ---------------------------------------------------------------\n");
                Console.Write("Chon: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent(students);
                        break;
                    case 2:
                        Console.WriteLine("\n\t====Danh sach sinh vien====");
                        DisplayListStudents(students);
                        break;
                    case 3:
                        DisplayStudentsByFaculty(students);
                        break;
                    case 4:
                        DisplayStudentsWithHighAverageScore(students);
                        break;
                    case 5:
                        DisplaySortStudentsByAverageScore(students);
                        break;
                    case 6:
                        DisplayStudentsByFacultyAndScore(students);
                        break;
                    case 7:
                        DisplayStudentsWithHighestScoreAndFaculty(students);
                        break;
                    case 8:
                        CountClassification(students);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Nhap sai yeu cau");
                        break;
                }
            } while (choice != 0);
        }
        public static void AddStudent(List<Student> students)
        {
            Console.WriteLine("\t\t---Nhap thong tin---\n");
            Student st = new Student();
            st.Input();
            students.Add(st);
            Console.WriteLine("\t\n---Them thanh cong---");
        }
        public static void DisplayListStudents(List<Student> students)
        {
            foreach (Student listSt in students)
                listSt.Output();
        }
        public static void DisplayStudentsByFaculty(List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.faculty.ToUpper() == "CNTT")
                {
                    student.Output();
                }
            }
        }
        public static void DisplayStudentsWithHighAverageScore(List<Student> students)
        {
            var student = students.Where(s => s.averageScore >= 5).ToList();
            Console.WriteLine("\n\t====Sinh vien co DTB >= 5====");
            DisplayListStudents(student);
        }

        public static void DisplaySortStudentsByAverageScore(List<Student> students)
        {
            var sortStudents = students.OrderBy(s => s.averageScore).ToList();
            Console.WriteLine("\n\t====Danh sach sinh vien sap xep diem tang dan====");
            DisplayListStudents(sortStudents);
        }
        public static void DisplayStudentsByFacultyAndScore(List<Student> students)
        {
            Console.WriteLine("\n\t====Danh sach sinh vien sap xep theo khoa'CNTT' va Diem >= 5====");
            var student = students.Where(s => s.faculty.ToUpper() == "CNTT" && s.averageScore >= 5).ToList();
            DisplayListStudents(student);
        }
        public static void DisplayStudentsWithHighestScoreAndFaculty(List<Student> students)
        {
            Console.WriteLine("\n\t====Danh sach sinh vien co diem cao nhat va thuoc khoa 'CNTT'====");
            var score = students.Max(s => s.averageScore);
            var result = students.Where(s => s.averageScore == score && s.faculty.ToUpper() == "CNTT").ToList();
            DisplayListStudents(result);
        }
        public static void CountClassification(List<Student> students)
        {
            int xs = 0, g = 0, kha = 0, tb = 0, y = 0, kem = 0;
            foreach (Student st in students)
            {
                if (st.averageScore >= 9)
                    xs++;
                else if (st.averageScore >= 8)
                    g++;
                else if (st.averageScore >= 7)
                    kha++;
                else if (st.averageScore >= 5)
                    tb++;
                else if (st.averageScore >= 4)
                    y++;
                else
                    kem++;
            }
            Console.WriteLine($"Xuat sac: {xs} sinh vien, Gioi: {g} sinh vien, Kha: {kha} sinh vien, " +
                $"Trung binh: {tb} sinh vien, Kem: {kem} sinh vien");
        }
    }
}