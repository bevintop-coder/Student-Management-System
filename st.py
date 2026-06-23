students = []

class Student:
    def __init__(self, id, name, age, department):
        self.id = id
        self.name = name
        self.age = age
        self.department = department

    def display(self):
        print("ID:", self.id)
        print("Name:", self.name)
        print("Age:", self.age)
        print("Department:", self.department)
        print("----------------------")


def add_student():
    id = int(input("Enter ID: "))
    name = input("Enter Name: ")
    age = int(input("Enter Age: "))
    dept = input("Enter Department: ")

    students.append(Student(id, name, age, dept))
    print("Student added successfully!\n")


def view_students():
    if len(students) == 0:
        print("No students found!\n")
        return

    for s in students:
        s.display()


def search_student():
    id = int(input("Enter ID to search: "))

    for s in students:
        if s.id == id:
            print("Student found:")
            s.display()
            return

    print("Student not found!\n")


def delete_student():
    id = int(input("Enter ID to delete: "))

    for s in students:
        if s.id == id:
            students.remove(s)
            print("Student deleted successfully!\n")
            return

    print("Student not found!\n")


while True:
    print("===== Student Management System =====")
    print("1. Add Student")
    print("2. View Students")
    print("3. Search Student")
    print("4. Delete Student")
    print("5. Exit")

    choice = int(input("Enter choice: "))

    if choice == 1:
        add_student()

    elif choice == 2:
        view_students()

    elif choice == 3:
        search_student()

    elif choice == 4:
        delete_student()

    elif choice == 5:
        print("Exiting...")
        break

    else:
        print("Invalid choice")