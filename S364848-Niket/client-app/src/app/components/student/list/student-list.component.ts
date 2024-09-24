/**
 */

import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DataStateChangeEventArgs, EditSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { SortService, GridModule, FilterService, ToolbarService, EditService } from '@syncfusion/ej2-angular-grids';
import { orderDetails } from './data'
// Services
import { StudentService } from '../../../services/student/student.service';
import { routerTransition } from '../../../services/config/config.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
	selector: 'app-student-list',
	templateUrl: './student-list.component.html',
	styleUrls: ['./student-list.component.css'],

	// providers: [SortService, FilterService, ToolbarService, EditService],
	animations: [routerTransition()],
	host: { '[@routerTransition]': '' }
})

export class StudentListComponent implements OnInit {
	studentList: any;
	studentListData: any = [];
	filterData: string = '';
	// public pageSettings: Object;

	constructor(private StudentService: StudentService, private toastr: ToastrService) { }
	
	// public filterSettings: Object = { type: 'Menu' };
	public pageSettings = { pageSize: 10 };

	public data: Object[] = [];
    public filterSettings: Object;
    public toolbar: string[];
    public editSettings: Object;
    public orderidrules: Object;
    public customeridrules: Object;
    public freightrules: Object;

	
	// Call student list function on page load
	ngOnInit() {


		// this.data = orderDetails;
        this.filterSettings = { type: 'Excel' };
        this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
        this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
        this.orderidrules = { required: true, number: true };
        this.customeridrules = { required: true, minLength: 5 };
        this.freightrules = { required: true, min: 0 };
		this.getStudentList();
	}

	// Get student list from services
	getStudentList() {
		this.StudentService.getAllStudents().subscribe((response) => {
			console.log(response);
			this.studentListData = response;
		},(error: HttpErrorResponse) => {
			if (error.status === 0) {
			console.log('Request not sent to the server');
			} else {
			console.log('Error occurred: ', error);
			}});
	}

	// // Get student list success
	// success(data: any) {
	// 	this.studentListData = data.data;
	// 	for (var i = 0; i < this.studentListData.length; i++) {
	// 		this.studentListData[i].name = this.studentListData[i].first_name + ' ' + this.studentListData[i].last_name;
	// 	}
	// }

	// Delete a student with its index
	deleteStudent(index: number) {
		// get confirm box for confirmation
		let r = confirm("Are you sure?");
		if (r == true) {
			let studentDelete = this.StudentService.deleteStudent(index);
			if (studentDelete) {
				this.toastr.success("Success", "Student Deleted");
			}
			this.getStudentList();
		}
	}

	actionComplete(args: any) {
		console.log(args)
		if (args.requestType === 'save') {
		  if (args.action === 'add') {
			// New student added, create a new student in the database
			const newStudent = {
				StudentFirstName: args.data.StudentFirstName,
				StudentLastName: args.data.StudentLastName,
				StudentEmail: args.data.StudentEmail,
				StudentDepartment: args.data.StudentDepartment
			  };
			this.StudentService.createStudent(newStudent).subscribe((response) => {
			  this.toastr.success("Success", "Student Created");
			  this.getStudentList();
			}, (error: HttpErrorResponse) => {
			  console.error(error);
			  this.toastr.error("Error", "Failed to create student");
			});
		} else if (args.action === 'edit') {
			const originalData = args.previousData;
			const updatedData = args.data;
			if (this.hasChanges(originalData, updatedData)) {
				this.StudentService.updateStudent(updatedData).subscribe((response) => {
				  this.toastr.success("Success", "Student Updated");
				}, (error: HttpErrorResponse) => {
				  console.error(error);
				  this.toastr.error("Error", "Failed to update student");
				});
			  } else {
				console.log("No changes made, skipping update request.");
			  }
			}
		}  else if (args.requestType === 'delete') {
			const deletedStudentId = args.data[0].StudentId;
			this.StudentService.deleteStudent(deletedStudentId).subscribe((response) => {
			  this.toastr.success("Success", "Student Deleted");
			  this.getStudentList(); // Refresh the student list
			}, (error: HttpErrorResponse) => {
			  console.error(error);
			  this.toastr.error("Error", "Failed to delete student");
			});
		}
	  }

	  onRowRemoved(args: any) {
		console.log(args)
		if (args.data.length === 0) {
			const deletedStudentId = args.data[0].StudentId;
			this.StudentService.deleteStudent(deletedStudentId).subscribe((response) => {
			  this.toastr.success("Success", "Student Deleted");
			  this.getStudentList(); // Refresh the student list
			}, (error: HttpErrorResponse) => {
			  console.error(error);
			  this.toastr.error("Error", "Failed to delete student");
			});
		}
	  }

	dataStateChange(state: DataStateChangeEventArgs) {
		// Handle data state changes (sorting, filtering, etc.)
		console.log(state)
	  }

	  hasChanges(originalData: any, updatedData: any): boolean {
		for (const key in originalData) {
		  if (originalData[key] !== updatedData[key]) {
			return true;
		  }
		}
		return false;
	  }
}
/**
 */
