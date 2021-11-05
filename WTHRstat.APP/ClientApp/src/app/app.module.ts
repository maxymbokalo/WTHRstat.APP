import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule, Routes } from '@angular/router';
import { EmissionComponent } from './emission/emission.component';
import { SourceComponent } from './source/source.component';
import { BackgroundComponent } from './background/background.component';

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule ,RouterModule.forRoot([
    {path:'emissions', component: EmissionComponent},
    {path:'sources', component: SourceComponent}
  ])
  ],
  declarations: [AppComponent, AppHeaderComponent, EmissionComponent, SourceComponent , AppHeaderComponent, FooterComponent,
     BackgroundComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
