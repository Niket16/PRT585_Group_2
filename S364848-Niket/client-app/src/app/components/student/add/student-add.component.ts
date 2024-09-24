/**
 */
import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

// Services
import { ValidationService } from '../../../services/config/config.service';
import { StudentService } from '../../../services/student/student.service';
import { routerTransition } from '../../../services/config/config.service';

import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-student-add',
	templateUrl: './student-add.component.html',
	styleUrls: ['./student-add.component.css'],
	animations: [routerTransition()],
	host: { '[@routerTransition]': '' }
})

export class StudentAddComponent implements OnInit {
	// create studentAddForm of type FormGroup
	studentAddForm: FormGroup;
	index: any;

	constructor(private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute, private studentService: StudentService, private toastr: ToastrService) {

		// Check for route params
		this.route.params.subscribe(params => {
			this.index = params['id'];
			// check if ID exists in route & call update or add methods accordingly
			if (this.index && this.index != null && this.index != undefined) {
				this.getStudentDetails(this.index);
			} else {
				this.createForm(null);
			}
		});
	}

	ngOnInit() {
	}

	// Submit student details form
	doRegister() {
		if (this.index && this.index != null && this.index != undefined) {
			this.studentAddForm.value.id = this.index
		} else {
			this.index = null;
		}
		this.studentService.createStudent(this.studentAddForm.value).subscribe((response):any=>{
			this.toastr.success("Success", "Student Created");
			this.router.navigate(['/']);
		}, (error) => {
			this.toastr.error("Error", "Failed to Create Student");
		});
			
			

		// if (studentRegister) {
		// 	if (studentRegister.code == 200) {
		// 		this.toastr.success(studentRegister.message, "Success");
		// 		this.router.navigate(['/']);
		// 	} else {
		// 		this.toastr.error(studentRegister.message, "Failed");
		// 	}
		// }
	}

	// If this is update form, get user details and update form
	getStudentDetails(index: number) {
		let studentDetail = this.studentService.getStudentById(index);
		this.createForm(studentDetail);
	}

	// If this is update request then auto fill form
	createForm(data: any) {
		if (data == null) {
			this.studentAddForm = this.formBuilder.group({
				StudentFirstName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
				StudentLastName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
				StudentDepartment: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
				StudentEmail: ['', [Validators.required, ValidationService.emailValidator]]
			});
		} else {
			this.studentAddForm = this.formBuilder.group({
				StudentFirstName: [data.studentData.StudentFirstName, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
				StudentLastName: [data.studentData.StudentLastName, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
				StudentDepartment: [data.studentData.StudentDepartment, [Validators.required, ValidationService.checkLimit(1000000000, 9999999999)]],
				StudentEmail: [data.studentData.StudentEmail, [Validators.required, ValidationService.emailValidator]]
			});
		}
	}

}

/**
 */
