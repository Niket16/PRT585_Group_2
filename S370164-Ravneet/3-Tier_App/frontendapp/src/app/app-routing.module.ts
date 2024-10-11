import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnitListComponent } from './components/unit-list/unit-list.component';
import { UnitAddComponent } from './components/unit-add/unit-add.component';
import { UnitEditComponent } from './components/unit-edit/unit-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/units', pathMatch: 'full' },
  { path: 'units', component: UnitListComponent },
  { path: 'units/add', component: UnitAddComponent },
  { path: 'units/edit/:id', component: UnitEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
