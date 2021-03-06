import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import './rxjs-extensions';
import { DashboardComponent} from './Components/dashboard.component';
import { ClassesComponent} from './Components/classes.component';
import { InstructorComponent} from './Components/instructor.component';
import { RoomComponent} from './Components/room.component';
import { RatingComponent} from './Components/rating.component';
import { ScheduleComponent} from './Components/schedule.component';
import { TrackComponent} from './Components/track.component';
import { AppComponent }         from './Components/app.component';
import { AppRoutingModule } from './app-routing.module';
import { ClassService }          from './Services/class.service';
import { InstructorService }          from './Services/instructor.service';
import { RoomService }          from './Services/room.service';
import { RatingService }          from './Services/rating.service';
import { ScheduleService }          from './Services/schedule.service';
import { TrackService }          from './Services/track.service';
import { Configuration } from './app.constants';
import {APP_BASE_HREF} from '@angular/common';
import {Ng2PaginationModule} from 'ng2-pagination';

@NgModule({
  imports:      [ 
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    AppRoutingModule, 
    Ng2PaginationModule,
    ],
  declarations: [ AppComponent, DashboardComponent, ClassesComponent, InstructorComponent, RoomComponent, RatingComponent,ScheduleComponent, TrackComponent ],
  providers: [ {provide: APP_BASE_HREF, useValue : '/' },
    ClassService, InstructorService, RoomService, RatingService, ScheduleService, TrackService, Configuration
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
