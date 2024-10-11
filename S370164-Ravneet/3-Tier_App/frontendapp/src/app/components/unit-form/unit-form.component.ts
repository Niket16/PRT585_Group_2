import { Component, OnInit } from '@angular/core';
import { UnitService, Unit } from '../../services/unit.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-unit-form',
  templateUrl: './unit-form.component.html',
  styleUrls: ['./unit-form.component.css']
})
export class UnitFormComponent implements OnInit {
  unit: Unit = { unitId: 0, unitCode: '', unitName: '' };
  isEdit: boolean = false;

  constructor(
    private unitService: UnitService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const unitId = this.route.snapshot.paramMap.get('id');
    if (unitId) {
      this.isEdit = true;
      this.unitService.getUnitById(+unitId).subscribe(unit => {
        this.unit = unit;
      });
    }
  }

  saveUnit(): void {
    if (this.isEdit) {
      this.unitService.updateUnit(this.unit).subscribe(() => {
        this.router.navigate(['/units']);
      });
    } else {
      this.unitService.addUnit(this.unit).subscribe(() => {
        this.router.navigate(['/units']);
      });
    }
  }
}
