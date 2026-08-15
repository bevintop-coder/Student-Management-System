CREATE DATABASE student_management;

USE student_management;

CREATE TABLE students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    department VARCHAR(100) NOT NULL
);

INSERT INTO students
(student_id, student_name, age, department)
VALUES
(101, 'Bevinto Paul', 21, 'Computer Science'),
(102, 'John Mathew', 20, 'Information Technology'),
(103, 'Rahul Kumar', 22, 'Computer Science');

SELECT * FROM students;

SELECT *
FROM students
WHERE student_id = 101;

DELETE FROM students
WHERE student_id = 103;

UPDATE students
SET department = 'Artificial Intelligence'
WHERE student_id = 102;