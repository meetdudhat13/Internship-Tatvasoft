import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { delay } from 'rxjs';

@Component({
  selector: 'app-student-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './student-form.component.html',
  styleUrl: './student-form.component.css',
})
export class StudentFormComponent {
  studentName: string = '';
  studentEmail: string = '';
  submitted: boolean = false;
  students: string[] = [];
  ifStudentAvailable = this.students.length>0;

  submitForm(){
    if(this.studentName.length>3 && this.studentEmail.endsWith('@gmail.com')){
      this.students.push("Name: "+this.studentName+" || "+"Email: "+this.studentEmail);
      this.ifStudentAvailable = this.students.length>0;
      this.submitted = true;
      this.studentName='';
      this.studentEmail='';
    }
  }
}
