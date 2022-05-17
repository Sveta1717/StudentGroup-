using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup
{
    internal class Date
    {
        private int day;
        private int month;
        private int year;

        public Date(int d, int m, int y)
        {
            int leapYear = year % 4;
            if (d < 1 || d > 31 || m < 1 || m > 12
                || (m == 2 && d > 29 - leapYear) || d > 30 + m % 2)
            {
                Console.WriteLine("Помилка, введiть коректну дату");
            }
            else
            {
                day = d;
                month = m;
                year = y;
            }
        }

        public void SetDay(int day)
        {
            this.day = day;
        }
        public void SetMonth(int month)
        { this.month = month; }
        public void SetYear(int year)
        { this.year = year; }
        public int GetDay()
        {
            return day;
        }
        public int GetMonth()
        {
            return month;
        }
        public int GetYear()
        {
            return year;
        }
    }

    internal class Student : IComparable<Student>
    {
        private string surname;
        private string name;
        private string patronymic;
        private Date birthday;
        private string adress;
        private int phone;
        public int[] courseWork;
        public int[] credit;
        public int[] exam;

        public Student() : this("", "", "") { } //base(){}

        public Student(string s, string n, string p)
        {
            surname = s;
            name = n;
            patronymic = p;
        }

        public Student(string s, string n, string p, Date b, string a)
        {
            surname = s;
            name = n;
            patronymic = p;
            birthday = b;
            adress = a;
        }

        public Student(string s, string n, string p, Date b, string a, int ph)
        {
            surname = s;
            name = n;
            patronymic = p;
            birthday = b;
            adress = a;
            phone = ph;
        }
        public Student(string s, string n, string p, Date b, string a, int ph, int[] courseMark, int[] creditMark, int[] examMark)
        {
            surname = s;
            name = n;
            patronymic = p;
            birthday = b;
            adress = a;
            phone = ph;
            courseWork = new int[courseMark.Length];
            for (int i = 0; i < courseMark.Length; i++)
            {
                courseWork[i] = courseMark[i];
            }
            credit = new int[creditMark.Length];
            for (int i = 0; i < creditMark.Length; i++)
            {
                credit[i] = creditMark[i];
            }
            exam = new int[examMark.Length];
            for (int i = 0; i < examMark.Length; i++)
            {
                exam[i] = examMark[i];
            }
        }

        public void SetSurname(string s)
        { surname = s; }
        public string GetSurname()
        { return surname; }
        public void Setname(string n)
        { name = n; }
        public string Getname()
        { return name; }
        public void Setpatronymic(string p)
        { patronymic = p; }
        public string Getpatronymic()
        { return patronymic; }

        public void SetBirthday(int day, int month, int year)
        {
            birthday.SetDay(day);
            birthday.SetMonth(month);
            birthday.SetYear(year);
        }
        public string Adress { set; get; }
        public int Phone { set; get; }
        public void setCourseWork(int courseMark, int index)
        {
            courseWork = new int[index];
            courseWork[0] = courseMark;
            if ((index > courseWork.Length - 1) || (index < 0))
            {
                return;
            }
            courseWork[index] = courseMark;
        }
        public int getCourseWork(int index)
        {
            if ((index > courseWork.Length - 1) || (index < 0))
            {
                return 0;
            }

            return courseWork[index];
        }

        public void setCredit(int creditMark, int index)
        {
            credit[0] = creditMark;
            if ((index > credit.Length - 1) || (index < 0))
            {
                return;
            }
            credit[index] = creditMark;
        }
        public int getCredit(int index)
        {
            if ((index > credit.Length - 1) || (index < 0))
            {
                return 0;
            }

            return credit[index];
        }

        public void setExam(int examMark, int index)
        {
            exam = new int[index];
            exam[0] = examMark;
            if ((index > exam.Length - 1) || (index < 0))
            {
                return;
            }
            exam[index] = examMark;
        }
        public int getExam(int index)
        {
            if ((index > exam.Length - 1) || (index < 0))
            {
                return 0;
            }

            return exam[index];
        }

        public void EditingStudent(Student student, string name, string surname, string patronymic) // редагування даних про студента
        {
            if (student != null)
            {
                student.name = name;
                student.surname = surname;
                student.patronymic = patronymic;
            }
        }

        public void showMarks(params int[] coursWork)
        {
            Console.Write("Курсова: ");
            for (int i = 0; i < courseWork.Length; i++)
            {
                Console.Write($"{courseWork[i]}" + ";");
            }
            Console.WriteLine();

            Console.Write("Залiк: ");
            for (int i = 0; i < credit.Length; i++)
            {
                Console.Write($"{credit[i]}" + ";");
            }
            Console.WriteLine();

            Console.Write("Iспит: ");
            for (int i = 0; i < exam.Length; i++)
            {
                Console.Write($"{exam[i]}" + ";");
            }

            Console.WriteLine();
        }

        public void showStudent()
        {
            Console.WriteLine("Прiзвище: " + surname);
            Console.WriteLine("Iм'я: " + name);
            Console.WriteLine("По батьковi: " + patronymic);
            Console.WriteLine("Дата народження: " + birthday.GetDay() + "." + birthday.GetMonth() + "." + birthday.GetYear());
            Console.WriteLine("Адреса: " + adress);
            Console.WriteLine("Телефон: " + phone);

            showMarks();
        }

        public int CompareTo(Student other)
        {
            double avg1 = this.exam.Average();
            double avg2 = other.exam.Average();

            if (avg1 == avg2) return 0;
            else if (avg1 > avg2) return 1;
            else return -1;
        }

        public class Surname : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == y)
                { return 0; }
                if (x == null || y == null)
                { return -1; }
                if (x.GetSurname() == y.GetSurname())
                { return -1; }
                return x.GetSurname().CompareTo(y.GetSurname());
            }
        }
        public class Exam : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                int avg1 = x.CompareTo(y);
                int avg2 = y.CompareTo(x);
                if (avg1 == avg2) return 0;
                if (avg1 > avg2) return 1;
                return -1;
            }
        }
    }

    internal class Group : IEnumerable
    {
        private Student[] student;
        private string Name;
        private int GroupSize;
        private string Specialization;
        private int course;
        private readonly Random r = new Random();

        public Group() : this("СПУ 121", 10, "Програмування", 1)
        {
            showGroup();
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + ".");
                showStudent();
            }

        }

        public Group(int G) : this("СБУ 121", G, "Базовий", 1)
        {
            showGroup();
            for (int i = 0; i < G; i++)
            {
                Console.Write((i + 1) + ".");
                showStudent();
            }
            //Array.Sort();
        }

        public Group(string N, int G, string S, int c)
        {
            Name = N;
            GroupSize = G;
            Specialization = S;
            course = c;
        }
        public Group(string name, string specalization, int course, params Student[] s)
        {
            this.Name = name;
            this.Specialization = specalization;
            this.course = course;
            student = new Student[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                student[i] = s[i];
            }
        }
        public Group(params Student[] s)
        {

            student = new Student[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                student[i] = s[i];
            }
        }
        public Group(Student s, string N, int G, string S, int c)
        {
            Name = N;
            GroupSize = G;
            Specialization = S;
            course = c;
        }

        public Group(Group group)
        {
            for (int i = 0; i < group.GroupSize; i++)
            {
                this.student[i] = group.student[i];
            }
        }

        public void setName(string Name)
        {
            this.Name = Name;
        }

        public string getName()
        {
            return Name;
        }

        public void setSpecialization(string Specialization)
        {
            this.Specialization = Specialization;
        }

        public string getSpecialization()
        {
            return Specialization;
        }

        public void setCourse(int course)
        {
            this.course = course;
        }

        public int getCourse()
        {
            return course;
        }

        public int StudentSize
        {
            get
            {
                return student.Length;
            }
        }
        public Student getStudent(int n)
        {

            if (n >= 0 || n < student.Length)
            {
                return student[n];
            }
            else
            {
                return student[0];
            }
        }

        public void addStudent(Student new_student) // додавання студента
        {
            Student[] s = this.student;
            student = new Student[GroupSize + 1];

            for (int i = 0; i < s.Length; i++)
            {
                student[i] = s[i];
            }

            student[GroupSize] = new_student;

            GroupSize++;
        }

        public void deleteStudent(int n)
        {
            if (n < 0 || n > student.Length - 1)
                return;

            Student[] s = this.student;
            student = new Student[GroupSize - 1];
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == n)
                {
                    count++;
                }
                student[i - count] = s[i];
            }
            GroupSize--;
        }

        public void RelocationStudent(int n, Group add)
        {
            deleteStudent(n);
            addStudent(getStudent(n));
        }

        public Group DeepCopy(Group g)
        {
            Group other = (Group)this.MemberwiseClone();
            other.Name = this.Name;
            other.Specialization = this.Specialization;
            other.GroupSize = this.GroupSize;
            other.course = this.course;
            other.student = this.student;

            return other;
        }
        public void showStudent()
        {
            string[] names = { "Максим", "Володимир", "Андрiй", "Вiктор", "Олександр",
                "Павло", "Дмитро", "Iгор", "Сергiй", "Олег" };

            string[] patronymics = { "Максимович", "Володимирович", "Андрiйович", "Вiкторович", "Олександрович",
                "Павлович", "Дмитрiйович", "Iгорович", "Сергiйович", "Олегович" };

            string[] surnames = { "Максименко", "Волошин", "Андрiєнко", "Вiкторенко", "Олександров",
                "Павленко", "Дмитренко", "Iвченко", "Сергiєнко", "Олешко" };

            int index_names = r.Next(0, names.Length);
            int index_surnames = r.Next(0, surnames.Length);
            int index_patronymics = r.Next(0, patronymics.Length);
            int age = r.Next(25, 39);

            Console.WriteLine(surnames[index_surnames] + " " + names[index_names] + " " + patronymics[index_patronymics] + " " + age + " рокiв");
        }

        public void showGroup()
        {
            Console.WriteLine("Група: " + getName());
            Console.WriteLine("Спецiалiзацiя: " + getSpecialization());
            Console.WriteLine("Курс: " + getCourse());
            Console.WriteLine("___________________");
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + student[i].GetSurname() + " " + student[i].Getname() +
                                   " " + student[i].Getpatronymic());
            }
        }
        public void EditingGroup(Group group, string Name, string specalization, int course) // редагування даних про групу
        {
            group.Name = Name;
            group.Specialization = specalization;
            group.course = course;
        }

        public IEnumerator GetEnumerator()
        {
            return student.GetEnumerator();
        }

        public void Print()
        {
            Student[] st = new Student[GroupSize];
            Group student_list = new Group();
            foreach (Student s in student_list)
                Console.WriteLine(s.GetSurname() + " " + s.Getname() + " " + s.Getpatronymic());
        }

        class Solution
        {
            static void Main(string[] args)
            {
                //Console.Write("Введiть iм'я: ");
                //string name = Console.ReadLine();

                //Console.Write("Введiть прiзвище: ");
                //string surname = Console.ReadLine();

                //Console.Write("Введiть по батьковi: ");
                //string patronymic = Console.ReadLine();

                //Console.Write("Введiть день народження: ");
                //int day = Convert.ToInt32(Console.ReadLine());

                //Console.Write("Введiть мiсяць народження: ");
                //int month = Convert.ToInt32(Console.ReadLine());

                //Console.Write("Введiть рiк народження: ");
                //int year = Convert.ToInt32(Console.ReadLine());

                //Console.Write("Введiть адресу: ");
                //string adress = Console.ReadLine();

                //Console.Write("Введiть номер телефону: ");
                //int phone = Convert.ToInt32(Console.ReadLine());

                //int[] courseWork = { 10, 8, 11 };
                //int[] credit = { 9, 12, 10, 10 };
                //int[] exam = { 10, 11 };

                //Date d = new Date(day, month, year);
                //Student st = new Student(surname, name, patronymic, d, adress, phone, courseWork, credit, exam);
                //Console.WriteLine();
                //st.showStudent();
                //Console.WriteLine();

                Student st = new Student("Василь", "Васильович", "Василенко");
                //st1.showStudent();
                Student st2 = new Student("Михайло", "Михайлович", "Михай");
                //st2.showStudent();
                Student st3 = new Student("Павло", "Павлович", "Павленко");
                st3.EditingStudent(st, "Максим", "Максимович", "Максименко");
                //st3.showStudent();
                //Student st4 = new Student("Максим", "Максимович", "Максименко");
                //st4.showStudent();

                Group g2 = new Group(st);
                Group g3 = new Group(st2);
                //Student st = new Student();
                //Group g = new Group("СПУ- 121", 2, "Програмування", 3);           
                //Console.WriteLine();
                //Group g1 = new Group(12);
                //Console.WriteLine();
                g2.addStudent(st2);
                g2.addStudent(st);
                g2.addStudent(st3);
                g2.showGroup();
                g3.EditingGroup(g2, "ВПУ - 121", "Базовий", 3);
                g2.showGroup();
                g2.deleteStudent(2);
                g2.showGroup();
                //g.Print();
                Console.WriteLine();
            }
        }
    }
}
