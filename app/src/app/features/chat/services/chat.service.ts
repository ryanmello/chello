import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChelloMessage, UserMessage, UserMessageCreateDTO } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
    private http = inject(HttpClient)
    private baseUrl = 'https://localhost:7191/api';

    sendMessage(message: UserMessageCreateDTO): Observable<ChelloMessage> {
      return this.http.post<ChelloMessage>(`${this.baseUrl}/messages`, message);
    }

    getMessages(userId: string): Observable<UserMessage[]> {
      return this.http.get<UserMessage[]>(`${this.baseUrl}/messages`);
    }
}
