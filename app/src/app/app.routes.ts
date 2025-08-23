import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./features/chat/chat-box/chat-box').then((m) => m.Chat) },
  { path: 'c/:threadId', loadComponent: () => import('./features/chat/chat-box/chat-box').then((m) => m.Chat) },
  { path: 'sign-in', loadComponent: () => import('./features/auth/sign-in/sign-in').then((m) => m.SignIn) },
  { path: 'sign-up', loadComponent: () => import('./features/auth/sign-up/sign-up').then((m) => m.SignUp) },
];
