import { Component } from '@angular/core';
import {DomSanitizer, SafeUrl} from "@angular/platform-browser";


@Component({
  selector: 'app-play-list-item',
  templateUrl: './play-list-item.component.html',
  styleUrls: ['./play-list-item.component.scss']
})
export class PlayListItemComponent {
  mode = 'side';
  push: any = 'push';
  hasBackdrop: any = true;
  id = 'WeOFimyghIA'
  dangerousVideoUrl = `https://www.youtube.com/embed/${this.id}`;
  videoUrl: SafeUrl = '';

  constructor(private sanitizer: DomSanitizer) {
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
}
