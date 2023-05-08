import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SignupComponent} from "./signup/signup.component";
import {LoginComponent} from "./login/login.component";
import {HomeComponent} from "./home/home.component";
import {PlaylistsComponent} from "./playlists/playlists.component";
import {PlayListItemComponent} from "./play-list-item/play-list-item.component";

const routes: Routes = [
  { path: 'register', component: SignupComponent,},
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent },
  { path: 'playlists', component: PlaylistsComponent},
  { path: 'playlist/:playlistSlug', component: PlayListItemComponent,}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
