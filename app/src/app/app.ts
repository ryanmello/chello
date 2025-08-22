import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from './features/sidebar/sidebar/sidebar';
import { ThreadService } from './services/thread.service';
import { Thread } from './models/models';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar],
  templateUrl: './app.html',
})
export class App {
  private threadService = inject(ThreadService);
  protected readonly title = signal('chello');

  threads = signal<Thread[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);

  ngOnInit() {
    this.loading.set(true);
    this.threadService.getThreads(1).subscribe({
      next: (response) => {
        this.threads.set(response);
        this.loading.set(false);
      },
      error: (error) => {
        this.error.set('Failed to load threads');
        this.loading.set(false);
        console.error(error)
      },
    });
  }
}
