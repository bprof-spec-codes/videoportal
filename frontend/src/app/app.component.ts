import { Component } from '@angular/core';
import { ApiService } from './api.service';
import {MatDialog} from "@angular/material/dialog";
import {DialogComponent} from "./dialog/dialog.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'frontend';

  api: ApiService
  constructor(api: ApiService, private dialog: MatDialog){
    this.api = api
  }

  openCreateDialog() {
    this.dialog.open(DialogComponent, {
      width: '75%',
    });
  }
}
