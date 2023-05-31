import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {DomSanitizer, SafeUrl} from "@angular/platform-browser";
import { ActivatedRoute, Router } from '@angular/router';
import isUUID from 'validator/lib/isUUID';
import { PlaylistItem } from '../models/playlistItem';
import {Song} from "../models/song";


@Component({
  selector: 'app-play-list-item',
  templateUrl: './play-list-item.component.html',
  styleUrls: ['./play-list-item.component.scss']
})
export class PlayListItemComponent implements OnInit {
  mode = 'side';
  push: any = 'push';
  hasBackdrop: any = true;
  id = 'WeOFimyghIA'
  dangerousVideoUrl = `https://www.youtube.com/embed/${this.id}`;
  videoUrl: SafeUrl = '';

  constructor(private sanitizer: DomSanitizer, private route: ActivatedRoute, private router: Router, http: HttpClient) {
    this.videoUrl =
      this.sanitizer.bypassSecurityTrustResourceUrl(this.dangerousVideoUrl);
      this.http = http;
    this.songs = [];
  }

  demoLinks: any[] = [
    {
      text: 'pendulum',
      id: 'WeOFimyghIA'
    },
    {
      text: 'electric callboy',
      id: 'wobbf3lb2nk'
    },
    {
      text: 'bring me the horizon',
      id: 'jN0aELsVQFA'
    }
  ];
  http:HttpClient
  songs: Array<Song>

  updateUrl(id: string) {
    this.dangerousVideoUrl = 'https://www.youtube.com/embed/' + id;
    this.videoUrl =
      this.sanitizer.bypassSecurityTrustResourceUrl(this.dangerousVideoUrl);
  }

  ngOnInit(): void {
    const playlistId = this.route.snapshot.paramMap.get('playlistSlug')!;
    if (!isUUID(playlistId)) {
      this.router.navigate(['/pagenotfound'], { skipLocationChange: true });
      return;
    }

    const token = localStorage.getItem('token');

    this.http
    .get<Array<PlaylistItem>>(`https://localhost:5001/api/Playlist`, {
      headers: {
        "authorization": `bearer ${token}`
      }
    })
    .subscribe(response => {
      const result = response.find((oneItem) => oneItem.id === playlistId) as any;
      this.songs = result.songs;
      console.log(this.songs);
    })
  }
}
