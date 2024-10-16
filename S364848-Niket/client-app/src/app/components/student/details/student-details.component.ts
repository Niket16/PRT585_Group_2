/**
 */
 import { Component, OnInit } from '@angular/core';
 import {Validators, FormBuilder, FormGroup} from '@angular/forms';
 import { RouterModule, Routes ,Router,ActivatedRoute} from '@angular/router';
 import { ToastrService } from 'ngx-toastr';

 // Services
 import { StudentService } from '../../../services/student/student.service';
 import { routerTransition } from '../../../services/config/config.service';

 @Component({
 	selector: 'app-student-details',
 	templateUrl: './student-details.component.html',
 	styleUrls: ['./student-details.component.css'],
 	animations: [routerTransition()],
 	host: {'[@routerTransition]': ''}
 })

 export class StudentDetailsComponent implements OnInit {
 	index:any;
 	studentDetail:any;
 	constructor(private router: Router, private route: ActivatedRoute, private studentService:StudentService,private toastr: ToastrService) {
 		// Get user detail index number sent in params
 		this.route.params.subscribe(params => {
 			this.index = params['id'];
 			if (this.index && this.index != null && this.index != undefined) {
 				this.getStudentDetails(this.index);
 			}
 		});
 	}

 	ngOnInit() {
 	}

 	// Get student details
 	// getStudentDetails(index:number){
 	// 	let getStudentDetail = this.studentService.getStudentById(index).subscribe();
 	// 	if(getStudentDetail) {
 	// 		this.studentDetail = getStudentDetail.studentData;
 	// 		this.toastr.success(getStudentDetail.message,"Success");
 	// 	}
 	// }

	 getStudentDetails(id: number) {
		this.studentDetail.getStudentById(id).subscribe((response : any) => {
		  console.log(response);
		});
	  }

 }

/**
 */
