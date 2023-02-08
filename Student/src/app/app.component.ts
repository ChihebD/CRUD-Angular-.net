import { Component } from '@angular/core';
import { Student } from './Models/Student';
import { StudentService } from './Services/student.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Student';
  students: Student[] = [];
  studentToEdit?: Student;
  constructor(private studentService: StudentService) {

  }
  ngOnInit(): void {
    this.studentService.getStudents().subscribe((res: Student[]) => (this.students = res))


  }
  updatedStudentList(students : Student[]){
    this.students = students;
  }
  initNewStudent(){
    this.studentToEdit = new Student;
  }
  editStudent(student : Student){
    this.studentToEdit = student;
  }
}
