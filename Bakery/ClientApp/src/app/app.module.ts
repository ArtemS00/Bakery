import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { environment } from '../environments/environment';
import { BUNS_API_URL } from './app-injection-tokens';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BunsTableComponent } from './components/buns-table/buns-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    BunsTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: BUNS_API_URL,
      useValue: environment.bunsApi
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
