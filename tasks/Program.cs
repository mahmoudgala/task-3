using System.Xml.Linq;

namespace tasks
{
    class Student
    {
        public string id;
        public string name;
        public int age;
        public List<Course> enroll;
        public Student( string id,string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.enroll = new List<Course>();
        }


    }
    class Instractor
    {
        public string id;
        public string name;
        public string department;
        public Instractor(string id, string name, string department)
        {
            this.id = id;
            this.name = name;
            this.department = department;
        }
    }
    class Course
    {
        public string code;
        public string name;
        public Instractor instractor;
        public Course(string code, string name, Instractor instractor)
        {
            this.code = code;
            this.name = name;
            this.instractor = instractor;
        }
    }

    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Instractor> instractors = new List<Instractor>();
        static List<Course> courses = new List<Course>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Add Student 2.View Student 3.Search Student 4.Update Student 5.Delete Student");
                Console.WriteLine("6.Add Course 7.Add Instractor 8.Enroll Student 9.View All Courses 10.View All Instractors");
                Console.WriteLine("please choose option");
                string choise = Console.ReadLine();
                switch (choise) {
                    case "1":
                        Console.WriteLine("Enter Student ID: ");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter Student Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Student Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        students.Add(new Student(id, name, age));
                        Console.WriteLine("student added successfully");
                        break;
                    case "2":
                        for (int i = 0; i < students.Count; i++) {
                            Console.WriteLine($"Id: {students[i].id}  , Name: {students[i].name} , Age: {students[i].age} ");
                            if (students[i].enroll.Count > 0)
                            {
                                Console.WriteLine("Enrolled Courses:");
                                for (int j = 0; j < students[i].enroll.Count; j++) {
                                    Console.WriteLine(" - " + students[i].enroll[j].name);
                                        }
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter Student ID: ");
                        string search = Console.ReadLine();
                        Student found = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].id == search)
                            {
                                found = students[i];
                                break;
                            }
                        }
                        if (found != null)
                        {
                            Console.WriteLine($"ID {found.id}, Name {found.name}");
                        }
                        else
                        {
                            Console.WriteLine("Not Found");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter Student ID:");
                        string update = Console.ReadLine();
                        Student toupdate = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].id == update)
                            {
                                toupdate = students[i];
                                break;
                            }
                        }
                        if (toupdate != null)
                        {
                            Console.WriteLine("New Name:");
                            toupdate.name = Console.ReadLine();
                            Console.WriteLine("Updated");
                        } else {
                            Console.WriteLine("Not Found");
                                }
                        break;
                    case "5":
                        Console.WriteLine("Enter Student ID: ");
                        string delete = Console.ReadLine();
                        bool Found = false;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].id == delete)
                            {
                                students.RemoveAt(i);
                                Console.WriteLine("Deleted.");
                                Found = true;
                                break;
                            }
                        }
                        if (!Found)
                        {
                            Console.WriteLine("Not Found");
                        }
                        break;
                    case "6":
                        if (instractors.Count == 0)
                        {
                            Console.WriteLine("NOT Available");
                            break ;
                        }
                        Console.WriteLine("Enter Course Code: ");
                        string code = Console.ReadLine();
                        Console.WriteLine("Enter Course Name: ");
                        string cname = Console.ReadLine();
                        Console.WriteLine("Enter Course Instractor: ");
                        int cinstractor = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (cinstractor >= 0 && cinstractor < instractors.Count)
                        {
                            Course newCourses = new Course(code, cname, instractors[cinstractor]);
                            courses.Add(newCourses);
                            Console.WriteLine("Course Added");
                        }
                        else {
                            Console.WriteLine("inavilable Instructor");
                        }
                        break ;
                    case "7":
                        Console.WriteLine("Instructor ID: ");
                        string instid= Console.ReadLine();
                        Console.WriteLine("Instructor Name: ");
                        string instname = Console.ReadLine();
                        Console.WriteLine("Instructor Department: ");
                        string instdept = Console.ReadLine();
                        instractors.Add(new Instractor(instid, instname, instdept));
                        break;
                    case "8":
                        Console.WriteLine("Enter Student ID: ");
                        string enrolled= Console.ReadLine();
                        Student enrollingstudent = null;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].id == enrolled)
                            {
                                enrollingstudent = students[i];
                                break;
                            }
                        }
                        if (enrollingstudent == null)
                        {
                            Console.WriteLine("Student Not Found");
                            break;
                        }
                        if (courses.Count == 0)
                        {
                            Console.WriteLine("No Courses Available");
                            break;
                        }
                        Console.WriteLine("Available Courses:");
                        for (int i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {courses[i].name} - Instructor: {courses[i].instractor.name}");
                        }
                        Console.WriteLine("Course #:");
                        int courseshow=Convert.ToInt32(Console.ReadLine()) -1;
                        if (courseshow >= 0 && courseshow < courses.Count)
                        {
                            enrollingstudent.enroll.Add(courses[courseshow]);
                            Console.WriteLine("student Enrolled");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Selection");
                        }
                            break;
 

                }
            }
        }
    }
}
