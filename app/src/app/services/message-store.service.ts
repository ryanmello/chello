import { inject, Injectable, signal } from '@angular/core';
import { UIMessage } from '../models/models';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class MessageStore {
  private router = inject(Router);

  readonly threadId = signal<number | null>(null);
  readonly messages = signal<UIMessage[]>([]);
  readonly loading = signal<boolean>(false);
  readonly error = signal<string | null>(null);

  newChat() {
    this.threadId.set(null);
    this.messages.set([]);
    this.router.navigate(['/']);
  }
}
