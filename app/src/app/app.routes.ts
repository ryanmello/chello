import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./components/chat/chat').then((m) => m.Chat) },
  { path: 'chat', loadComponent: () => import('./components/chat/chat').then((m) => m.Chat) },
  { path: 'chat/:threadId', loadComponent: () => import('./components/chat/chat').then((m) => m.Chat) },
];
