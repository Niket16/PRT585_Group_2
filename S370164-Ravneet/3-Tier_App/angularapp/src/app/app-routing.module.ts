import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnitListComponent } from './components/unit-list/unit-list.component';
import { UnitCreateComponent } from './components/unit-create/unit-create.component';
import { UnitEditComponent } from './components/unit-edit/unit-edit.component';
import { UnitDeleteComponent } from './components/unit-delete/unit-delete.component';

const routes: Routes = [
  { path: '', component: UnitListComponent },
  { path: 'create', component: UnitCreateComponent },
  { path: 'edit/:id', component: UnitEditComponent },
  { path: 'delete/:id', component: UnitDeleteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
