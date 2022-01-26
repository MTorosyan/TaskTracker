import { Component, OnInit } from '@angular/core';
import { TaskTrackerService } from '../service/task-tracker-service.service';
import { Tasktrackermodel } from '../model/task-tracker-model';

@Component({
  selector: 'app-task-tracker',
  templateUrl: './task-tracker.component.html',
  styleUrls: ['./task-tracker.component.css']
})
export class TaskTrackerComponent implements OnInit {


  taskList = new Array<Tasktrackermodel>();
  constructor(private tasktrackerService:TaskTrackerService) { }
   

  ngOnInit() {

    
  
    this.tasktrackerService.getTasks().subscribe(
      res =>{

        this.taskList = res;
      }

    )

  }

  editTask($taskId){

     this.tasktrackerService.editTask($taskId).subscribe(
       res => {

       }
     )
  }


  createTask($taskId){
    
    //routes
     
  }


  deleteTask($taskId){    
    this.tasktrackerService.deleteTask($taskId).subscribe(
      () => {
        
        //add loader
        this.tasktrackerService.getTasks().subscribe(
          () =>{   
        });
      
      }); 
    
    
    }

}
