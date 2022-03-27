import { Injectable } from '@angular/core';
import { Task } from '../Task';
import { TASKS } from '../mock-task';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    Content_type: 'application/json',
  }),
};
@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private getApiUrl = 'http://localhost:5000/tasks';

  constructor(private http: HttpClient) {}

  getTasks(): Observable<Task[]> {
    const tasks = this.http.get<Task[]>(this.getApiUrl);
    //const tasks = of(TASKS);
    return tasks;
  }

  deleteTask(task: Task): Observable<Task> {
    const deleteUrl = `http://localhost:5000/tasks/${task.id}`;
    return this.http.delete<Task>(deleteUrl);
  }
  updateReminderInTask(task: Task): Observable<Task> {
    const deleteUrl = `${this.getApiUrl}/${task.id}`;
    return this.http.put<Task>(deleteUrl, task, httpOptions);
  }

  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>(this.getApiUrl, task, httpOptions);
  }
}
