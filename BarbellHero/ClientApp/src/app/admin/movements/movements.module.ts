import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MovementsComponent } from './movements.component';
import { MovementsRoutingModule } from './movements-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { ListComponent } from './list/list.component';
import { AddNewComponent } from './add-new/add-new.component';

@NgModule({
  imports: [CommonModule, FormsModule, MovementsRoutingModule, SharedModule],
  declarations: [MovementsComponent, ListComponent, AddNewComponent]
})
export class MovementsModule {
}
