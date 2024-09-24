

import { Component } from '@angular/core';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})


export class AppComponent {
	title = 'Student Management By Sangwin Gawande';

	// Add few students for initial listing
	studentsList = [
	{
		id : 1,
		first_name : "Muhammad",
		last_name : "Essa",
		email : "niket@cdu.edu.com",
		phone : 3472959126,
		department : "IGIS"
	},
	{
		id : 2,
		first_name : "umar",
		last_name : "khan",
		email : "umar@gmail.com",
		phone : 3062939726,
		department : "Commerce"
	},
	{
		id : 3,
		first_name : "Talha",
		last_name : "waheed",
		email : "talha@gmail.com",
		phone : 3172999126,
		department : "NICE"
	},
	{
		id : 4,
		first_name : "wajid",
		last_name : "shah",
		email : "wajid@gmail.com",
		phone : 3422959132,
		department : "NBS"
	},
	{
		id : 5,
		first_name : "Hayat",
		last_name : "khan",
		email : "hayat@gmail.com",
		phone : 3472933126,
		department : "Engineering"
	}
	];

	constructor() {
		// Save students to localStorage
		localStorage.setItem('students', JSON.stringify(this.studentsList));
	}
}

