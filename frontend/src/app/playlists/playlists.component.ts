import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Playlist } from '../models/playlist';

// export type Playlist = {
//   id: string;
//   img: string;
//   name: string;
// };

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.scss']
})
export class PlaylistsComponent implements OnInit {
  demoPlaylists: Playlist[] = [
    {
      id: '739b3185-432e-4fcb-bfc2-5ba16d1744d2',
      img: 'https://dt7v1i9vyp3mf.cloudfront.net/styles/news_large/s3/imagelibrary/P/Pendulum_09-s8A0TXPBLlD5Ez3weh6wp_W0YQONuJ.t.jpg',
      name: 'Pendulum playlist',
    },
    {
      id: 'b563ac8d-4f61-449c-83ec-759c1924b866',
      img: 'https://yt3.googleusercontent.com/chfIr2anfnZsog-ITiyof_jogxThWTFVbd5XY9IQyujOGvxm81xPaf1_rqZMc2g_sLcuMUXZcw4=s900-c-k-c0x00ffffff-no-rj',
      name: 'Electric callboy playlist',
    },
    {
      id: 'a5b0dfc0-340f-4ee8-a669-e1894ba93b19',
      img: 'https://sharknroll.hu/img/68017/765741/400x400,r/765741.jpg',
      name: 'Bring me the horizon playlist',
    }
  ];

  http:HttpClient
  playlists: Array<Playlist>

  constructor(http: HttpClient) {
    this.http = http
    this.playlists = []
  }

  ngOnInit(): void {
    this.http
    .get<Array<Playlist>>('backend-api-url')
    .subscribe(response => {
      response.map(x =>{
        let p = new Playlist()
        p.id = x.id
        p.img = x.img
        p.name = x.name
        this.playlists.push(p)
      })
      console.log(this.playlists)
    })
  }
}
