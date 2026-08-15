using System;
using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void ViewStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (Student student in students)
            {
                student.Display();
            }
        }

        public Student SearchStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                    return student;
            }

            return null;
        }

        public bool DeleteStudent(int id)
        {
            Student student = SearchStudent(id);

            if (student != null)
            {
                students.Remove(student);
                return true;
            }

            return false;
        }
    }
}