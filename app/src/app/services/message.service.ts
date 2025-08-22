import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message, MessageCreateDTO } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7191/api';

  getMessages(userId?: string, threadId?: string): Observable<Message[]> {
    if (userId == null && threadId == null) {
      throw new Error('Either userId or threadId must be provided');
    }
    return this.http.get<Message[]>(`${this.baseUrl}/messages`, {
      params: {
        ...(userId ? { userId } : {}),
        ...(threadId ? { threadId } : {}),
      },
    });
  }

  createMessage(message: MessageCreateDTO): Observable<Message> {
    return this.http.post<Message>(`${this.baseUrl}/messages`, message);
  }
}
