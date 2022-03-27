import { Component, OnInit } from '@angular/core';
import { TASKS } from '../../mock-task';
import { Task } from '../../Task';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})
export class TasksComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.taskService.getTasks().subscribe((tasks) => (this.tasks = tasks));
  }

  deleteTaskInTasks(task: Task) {
    this.taskService
      .deleteTask(task)
      .subscribe(
        () => (this.tasks = this.tasks.filter((t) => t.id !== task.id))
      );
  }

  setReminderInTasks(task: Task) {
    task.reminder = !task.reminder;
    this.taskService.updateReminderInTask(task).subscribe();
  }

  addTaskInTasks(task: Task) {
    console.log(task);
    this.taskService.addTask(task).subscribe((task) => this.tasks.push(task));
  }
}
