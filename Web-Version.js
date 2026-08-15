let students = JSON.parse(localStorage.getItem("students")) || [];

const form = document.getElementById("studentForm");
const table = document.getElementById("studentTable");
const search = document.getElementById("search");

form.addEventListener("submit", function(event) {

    event.preventDefault();

    const id = Number(document.getElementById("studentId").value);
    const name = document.getElementById("studentName").value;
    const age = Number(document.getElementById("studentAge").value);
    const department = document.getElementById("department").value;

    const existingStudent = students.find(student => student.id === id);

    if (existingStudent) {
        alert("Student ID already exists!");
        return;
    }

    const student = {
        id: id,
        name: name,
        age: age,
        department: department
    };

    students.push(student);

    saveStudents();

    form.reset();

    displayStudents();

    alert("Student added successfully!");
});


function displayStudents(list = students) {

    table.innerHTML = "";

    list.forEach(student => {

        const row = document.createElement("tr");

        row.innerHTML = `
            <td>${student.id}</td>
            <td>${student.name}</td>
            <td>${student.age}</td>
            <td>${student.department}</td>
            <td>
                <button
                    class="delete-btn"
                    onclick="deleteStudent(${student.id})">
                    Delete
                </button>
            </td>
        `;

        table.appendChild(row);
    });

    updateDashboard();
}


function deleteStudent(id) {

    const confirmation = confirm(
        "Are you sure you want to delete this student?"
    );

    if (!confirmation)
        return;

    students = students.filter(student => student.id !== id);

    saveStudents();

    displayStudents();
}


search.addEventListener("input", function() {

    const keyword = search.value.toLowerCase();

    const filteredStudents = students.filter(student =>
        student.name.toLowerCase().includes(keyword) ||
        student.id.toString().includes(keyword) ||
        student.department.toLowerCase().includes(keyword)
    );

    displayStudents(filteredStudents);
});


function updateDashboard() {

    document.getElementById("totalStudents").textContent =
        students.length;

    const departments = new Set(
        students.map(student => student.department)
    );

    document.getElementById("totalDepartments").textContent =
        departments.size;

    if (students.length === 0) {
        document.getElementById("averageAge").textContent = "0";
        return;
    }

    const totalAge = students.reduce(
        (sum, student) => sum + student.age,
        0
    );

    const average = totalAge / students.length;

    document.getElementById("averageAge").textContent =
        average.toFixed(1);
}


function saveStudents() {

    localStorage.setItem(
        "students",
        JSON.stringify(students)
    );
}


displayStudents();