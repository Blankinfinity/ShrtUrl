import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { RedirectComponent } from './redirect.component';

const routes: Routes = [
  { path: '', component: AppComponent, pathMatch: 'full' },
//{ path: 'url/:shortUrl', component: RedirectComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
