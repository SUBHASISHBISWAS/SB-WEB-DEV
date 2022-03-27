import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { from } from 'rxjs';
import { Task } from '../../Task';

@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.css'],
})
export class TaskItemComponent implements OnInit {
  @Input() task: Task;
  @Output() onDeleteTask: EventEmitter<Task> = new EventEmitter<Task>();
  @Output() onSetReminderTask: EventEmitter<Task> = new EventEmitter<Task>();
  faTimes = faTimesCircle;
  constructor() {}

  ngOnInit(): void {}

  onDelete(task) {
    console.log('Delete');
    this.onDeleteTask.emit(task);
  }
  onDoubleClick(task: Task) {
    console.log('Task');
    this.onSetReminderTask.emit(task);
  }
}
