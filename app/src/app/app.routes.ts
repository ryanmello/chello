import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./features/chat/components/chat-box/chat-box').then((m) => m.Chat) },
  { path: 'chat', loadComponent: () => import('./features/chat/components/chat-box/chat-box').then((m) => m.Chat) },
  { path: 'chat/:threadId', loadComponent: () => import('./features/chat/components/chat-box/chat-box').then((m) => m.Chat) },
];
