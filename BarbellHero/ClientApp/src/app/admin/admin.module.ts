import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MovementsModule } from './movements/movements.module';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    MovementsModule
  ],
  declarations: [AdminComponent, DashboardComponent]
})
export class AdminModule { }
