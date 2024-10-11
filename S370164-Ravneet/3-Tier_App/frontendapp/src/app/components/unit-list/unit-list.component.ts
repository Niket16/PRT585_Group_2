import { Component, OnInit } from '@angular/core';
import { UnitService, Unit } from '../../services/unit.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit {
  units: Unit[] = [];

  constructor(private unitService: UnitService, private router: Router) { }

  ngOnInit(): void {
    this.unitService.getUnits().subscribe(data => {
      this.units = data;
    });
  }

  deleteUnit(id: number): void {
    this.unitService.deleteUnit(id).subscribe(() => {
      this.units = this.units.filter(unit => unit.unitId !== id);
    });
  }

  editUnit(unit: Unit): void {
    // Navigate to the edit form with the selected unit
    this.router.navigate(['/edit', unit.unitId]);
  }

  addUnit(): void {
    // Navigate to the add form
    this.router.navigate(['/add']);
  }
}
