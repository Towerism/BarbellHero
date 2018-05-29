import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Movement } from '../movement';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.scss']
})
export class AddNewComponent {
  movement: Movement;

  @Output() added = new EventEmitter<Movement>();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.movement = { name: '' };
  }

  add() {
    this.http.post<Movement>(this.baseUrl + 'api/movement', this.movement)
      .subscribe(movement => {
        this.movement.name = '';
        this.added.emit(movement);
      });
  }
}
