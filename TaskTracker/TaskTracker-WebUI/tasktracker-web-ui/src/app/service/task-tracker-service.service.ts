import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITaskTracker } from '../interface/task-tracker-interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskTrackerService {
  
  /**
   * This is the task tracker service which uses rest calls to the service to access the tasktracker api
   */
  constructor(private http:HttpClient) {
      
  }

   getTasks():Observable<ITaskTracker[]>{

    return this.http.get<ITaskTracker[]>("http://localhost:7777/api/tasktrackerapi");
   }

   
   editTask(taskID: number):Observable<ITaskTracker>{

    return this.http.put<ITaskTracker>("http://localhost:7777/api/tasktrackerapi/edittask",taskID);
   }

   deleteTask(taskID: number):Observable<ITaskTracker>{

    return this.http.delete<ITaskTracker>(`http://localhost:7777/api/tasktrackerapi/deletetask/${taskID}`);
   }

   createTask(task:ITaskTracker):Observable<ITaskTracker>{

    return this.http.post<ITaskTracker>("http://localhost:7777/api/tasktrackerapi/createnewtask",task);
   }

   
   


  }

