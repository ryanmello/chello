import { Component, inject, signal } from '@angular/core';
import { HlmButton } from '@spartan-ng/helm/button';
import { SidebarFooter } from '../sidebar-footer/sidebar-footer';
import { SidebarLink } from '../sidebar-link/sidebar-link';
import { Thread } from '../../../models/models';
import { ThreadService } from '../../../services/thread.service';
import { MessageStore } from '../../../services/message-store.service';

@Component({
  selector: 'app-sidebar',
  imports: [HlmButton, SidebarFooter, SidebarLink],
  templateUrl: './sidebar.html',
  styles: ``,
})
export class Sidebar {
  private threadService = inject(ThreadService);
  private messageStore = inject(MessageStore);

  threads = signal<Thread[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);

  onNewChat() {
    this.messageStore.newChat();
  }

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
        console.error(error);
      },
    });
  }
}
