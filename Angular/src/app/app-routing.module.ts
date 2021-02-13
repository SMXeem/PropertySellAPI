import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OwnerComponent } from './owner/owner.component';
import { PropertyComponent } from './property/property.component';

const routes: Routes = [
  { path: 'property', component: PropertyComponent },
  { path: 'owner', component: OwnerComponent }
  // { path: 'my-profile', component: MyProfileComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
