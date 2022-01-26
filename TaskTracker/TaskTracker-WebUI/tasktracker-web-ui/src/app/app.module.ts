import { BrowserModule,  } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { TaskTrackerComponent } from './task-tracker/task-tracker.component';
import { TaskTrackerService } from './service/task-tracker-service.service';
import { FormsModule } from '@angular/forms';
import { CreateTaskComponent } from './task-tracker/create-task/create-task.component';
import { EditTaskComponent } from './task-tracker/edit-task/edit-task.component';

@NgModule({
  declarations: [
    AppComponent,
    TaskTrackerComponent,
    EditTaskComponent,
    CreateTaskComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule,
  ],
  providers: [TaskTrackerService],
  bootstrap: [TaskTrackerComponent],
  
})
export class AppModule { }
