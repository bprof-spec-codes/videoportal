import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {RegisterData} from "../signup/signup.type";
import {HttpClient} from "@angular/common/http";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Router} from "@angular/router";

export interface DialogData {

}
/*"songs": [
  {
    "title": "test 2",
    "link": "tester.com"
  }
]*/

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  ngOnInit(): void {
  }

  router: Router
  http: HttpClient;
  snackBar: MatSnackBar;

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData, snackBar: MatSnackBar, public dialogRef: MatDialogRef<DialogComponent>, http:HttpClient, router: Router) {
    this.snackBar = snackBar;
    this.http = http;
    this.router = router
  }


  playlistData = {
    title: '',
    img: '',
    playTime: '',
    song: '',
  }

  addPlaylist() {
    console.log('data: ', this.playlistData);
    const token = localStorage.getItem('token');
    this.http.post("https://localhost:5001/api/Playlist", {
      ...this.playlistData,
      song: JSON.stringify(this.playlistData.song),
    }, {
      headers: {
        "authorization": `bearer ${token}`
      }
    }).subscribe(
      (success) => {
        console.log(success)
        // @ts-ignore
        this.router.navigate([`/playlist/${success.id}`])
      }, (error) => {
        this.snackBar
          .open("An error has occurred, please try again..", "Close", {duration: 5000})
      })
    this.dialogRef.close();
  }
}
