import { ITaskTracker } from "../interface/task-tracker-interface";

 export class Tasktrackermodel implements ITaskTracker{
     taskID: number;
    taskName: string;
     taskDescription: string;
     estimateTaskTime: Date;
     dateStarted: Date;
     dateFinished: Date;
     comment: string;

    

}