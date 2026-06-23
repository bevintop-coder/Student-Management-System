#include <iostream>
#include <vector>
using namespace std;

class Student {

public:

    int id;
    string name;
    int age;
    string department;


    Student(int id,string name,int age,string department){

        this->id=id;
        this->name=name;
        this->age=age;
        this->department=department;

    }


    void display(){

        cout<<"ID: "<<id<<endl;
        cout<<"Name: "<<name<<endl;
        cout<<"Age: "<<age<<endl;
        cout<<"Department: "<<department<<endl;
        cout<<"----------------------"<<endl;

    }

};


vector<Student> students;


void addStudent(){

    int id,age;
    string name,dept;


    cout<<"Enter ID: ";
    cin>>id;

    cout<<"Enter Name: ";
    cin>>name;

    cout<<"Enter Age: ";
    cin>>age;

    cout<<"Enter Department: ";
    cin>>dept;


    students.push_back(Student(id,name,age,dept));

    cout<<"Student added successfully!\n";

}


void viewStudents(){

    if(students.empty()){

        cout<<"No students found!\n";
        return;

    }


    for(auto s:students){

        s.display();

    }

}


void searchStudent(){

    int id;

    cout<<"Enter ID to search: ";
    cin>>id;


    for(auto s:students){

        if(s.id==id){

            cout<<"Student found:"<<endl;
            s.display();
            return;

        }

    }

    cout<<"Student not found!\n";

}


void deleteStudent(){

    int id;

    cout<<"Enter ID to delete: ";
    cin>>id;


    for(int i=0;i<students.size();i++){

        if(students[i].id==id){

            students.erase(students.begin()+i);

            cout<<"Student deleted successfully!\n";

            return;

        }

    }


    cout<<"Student not found!\n";

}



int main(){


    while(true){


        cout<<"\n===== Student Management System =====\n";

        cout<<"1. Add Student\n";
        cout<<"2. View Students\n";
        cout<<"3. Search Student\n";
        cout<<"4. Delete Student\n";
        cout<<"5. Exit\n";


        int choice;

        cout<<"Enter choice: ";
        cin>>choice;


        switch(choice){


            case 1:
                addStudent();
                break;


            case 2:
                viewStudents();
                break;


            case 3:
                searchStudent();
                break;


            case 4:
                deleteStudent();
                break;


            case 5:
                return 0;


            default:
                cout<<"Invalid choice";

        }


    }


}