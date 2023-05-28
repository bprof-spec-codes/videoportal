import { Component, OnInit } from '@angular/core';
import {DomSanitizer, SafeUrl} from "@angular/platform-browser";
import { ActivatedRoute, Router } from '@angular/router';
import isUUID from 'validator/lib/isUUID';


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

  constructor(private sanitizer: DomSanitizer, private route: ActivatedRoute, private router: Router) {
    this.videoUrl =
      this.sanitizer.bypassSecurityTrustResourceUrl(this.dangerousVideoUrl);
  }

  links: any[] = [
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
  }
}
