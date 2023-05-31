import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SignupComponent} from "./signup/signup.component";
import {LoginComponent} from "./login/login.component";
import {HomeComponent} from "./home/home.component";
import {PlaylistsComponent} from "./playlists/playlists.component";
import {PlayListItemComponent} from "./play-list-item/play-list-item.component";
import { PagenotfoundComponent } from "./pagenotfound/pagenotfound.component";
import { LogoutComponent } from './logout/logout.component';
import { ApiService } from './api.service';

const routes: Routes = [
  { path: 'register', component: SignupComponent,},
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: '', component: HomeComponent },
  { path: 'playlists', component: PlaylistsComponent, canActivate: [ApiService]},
  { path: 'playlist/:playlistSlug', component: PlayListItemComponent, canActivate: [ApiService]},
  { path: '**', pathMatch: 'full', component: PagenotfoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
