import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Movement } from '../movement';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {
  movements: Movement[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movement[]>(baseUrl + 'api/movement').subscribe(result => {
      this.movements = result;
    }, error => console.error(error));
  }

  add(movement: Movement) {
    this.movements.push(movement);
  }
}
