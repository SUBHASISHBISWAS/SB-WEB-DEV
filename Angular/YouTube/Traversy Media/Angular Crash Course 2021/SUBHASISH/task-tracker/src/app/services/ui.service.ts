import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UiService {
  private showAddTaskForm: boolean = false;
  private subject = new Subject<any>();

  constructor() {}

  toggleAddTask(): void {
    console.log('toggle');
    this.showAddTaskForm = !this.showAddTaskForm;
    this.subject.next(this.showAddTaskForm);
  }

  onToggle(): Observable<any> {
    return this.subject.asObservable();
  }
}
