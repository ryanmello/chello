import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ChelloMessage, UserMessage, UserMessageCreateDTO } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
    private http = inject(HttpClient)
    private baseUrl = 'https://localhost:7191/api';

    async sendMessage(message: UserMessageCreateDTO): Promise<UserMessage[]> {
      const payload = {
        userId: message.userId,
        prompt: message.prompt,
      }

      return firstValueFrom(this.http.post<UserMessage[]>(`${this.baseUrl}/messages`, payload));
    }

    async getMessages(userId: string): Promise<UserMessage[]> {
      return firstValueFrom(this.http.get<UserMessage[]>(`${this.baseUrl}/messages`));
    }
}
