let students = [];


class Student {

    constructor(id,name,age,department){

        this.id=id;
        this.name=name;
        this.age=age;
        this.department=department;

    }


    display(){

        console.log("ID:",this.id);
        console.log("Name:",this.name);
        console.log("Age:",this.age);
        console.log("Department:",this.department);
        console.log("----------------------");

    }

}


function addStudent(){

    let id=10;
    let name="John";
    let age=20;
    let dept="CSE";


    students.push(new Student(id,name,age,dept));

    console.log("Student added successfully");

}



function viewStudents(){

    students.forEach(s=>s.display());

}



function searchStudent(id){

    let s=students.find(x=>x.id===id);


    if(s){

        console.log("Student found");
        s.display();

    }

    else{

        console.log("Student not found");

    }

}



function deleteStudent(id){

    students=students.filter(x=>x.id!==id);

    console.log("Student deleted successfully");

}



addStudent();

viewStudents();

searchStudent(10);

deleteStudent(10);