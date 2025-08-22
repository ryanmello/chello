import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Thread } from '../models/models';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ThreadService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7191/api';

  getThreads(userId: number): Observable<Thread[]> {
    return this.http.get<Thread[]>(`${this.baseUrl}/threads`, {
      params: { userId: userId },
    });
  }

  getThread(threadId: number): Observable<Thread> {
    return this.http.get<Thread>(`${this.baseUrl}/threads/${threadId}`);
  }
}
