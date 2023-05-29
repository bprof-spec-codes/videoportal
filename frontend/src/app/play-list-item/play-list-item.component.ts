import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {DomSanitizer, SafeUrl} from "@angular/platform-browser";
import { ActivatedRoute, Router } from '@angular/router';
import isUUID from 'validator/lib/isUUID';
import { PlaylistItem } from '../models/playlistItem';


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
    this.links = [];
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
  links: Array<PlaylistItem>

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

    this.http
    .get<Array<PlaylistItem>>('backend-api-url')
    .subscribe(response => {
      response.map(x =>{
        let p = new PlaylistItem()
        p.id = x.id
        p.text = x.text
        this.links.push(p)
      })
      console.log(this.links)
    })
  }
}
