import { Component, OnInit } from '@angular/core';
import { UnitService, Unit } from '../../services/unit.service';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit {
  units: Unit[] = [];

  constructor(private unitService: UnitService) {}

  ngOnInit(): void {
    this.getUnits();
  }

  getUnits(): void {
    this.unitService.getUnits().subscribe(
      (data: Unit[] | null) => {
        if (data) {
          this.units = data;
        } else {
          console.error('No data received from API');
          this.units = [];
        }
      },
      (error) => {
        console.error('Error fetching units', error);
        this.units = []; // Prevent undefined errors
      }
    );
  }
}
