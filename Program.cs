using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }

    public void Display()
    {
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Department: " + Department);
        Console.WriteLine("----------------------");
    }
}

class StudentManagementSystem
{
    static List<Student> students = new List<Student>();

    static string jsonFile = "students.json";
    static string xmlFile = "students.xml";


    static void AddStudent()
    {
        Student s = new Student();

        Console.Write("Enter ID: ");
        s.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();

        Console.Write("Enter Age: ");
        s.Age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Department: ");
        s.Department = Console.ReadLine();


        students.Add(s);

        SaveJSON();
        SaveXML();

        Console.WriteLine("Student Added Successfully\n");
    }


    static void ViewStudents()
    {
        if(students.Count == 0)
        {
            Console.WriteLine("No Students Found\n");
            return;
        }


        foreach(Student s in students)
        {
            s.Display();
        }
    }


    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());


        foreach(Student s in students)
        {
            if(s.Id == id)
            {
                Console.WriteLine("Student Found");
                s.Display();
                return;
            }
        }


        Console.WriteLine("Student Not Found\n");
    }



    static void DeleteStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());


        Student remove = null;


        foreach(Student s in students)
        {
            if(s.Id == id)
            {
                remove = s;
                break;
            }
        }


        if(remove != null)
        {
            students.Remove(remove);

            SaveJSON();
            SaveXML();

            Console.WriteLine("Deleted Successfully\n");
        }

        else
        {
            Console.WriteLine("Student Not Found\n");
        }
    }



    static void SaveJSON()
    {
        string json = JsonSerializer.Serialize(students);

        File.WriteAllText(jsonFile,json);
    }



    static void SaveXML()
    {
        XmlSerializer serializer =
            new XmlSerializer(typeof(List<Student>));


        using(FileStream fs = new FileStream(xmlFile,FileMode.Create))
        {
            serializer.Serialize(fs,students);
        }
    }



    static void Main()
    {

        while(true)
        {

            Console.WriteLine("===== Student Management System =====");

            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");


            Console.Write("Enter Choice: ");

            int choice =
            Convert.ToInt32(Console.ReadLine());



            switch(choice)
            {

                case 1:
                    AddStudent();
                    break;


                case 2:
                    ViewStudents();
                    break;


                case 3:
                    SearchStudent();
                    break;


                case 4:
                    DeleteStudent();
                    break;


                case 5:
                    Environment.Exit(0);
                    break;


                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }

        }

    }

}