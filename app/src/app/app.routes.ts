import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./features/chat/chat-box/chat-box').then((m) => m.Chat) },
  { path: 'c/:threadId', loadComponent: () => import('./features/chat/chat-box/chat-box').then((m) => m.Chat) },
];
