import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../chat-message/message';
import { ChatMessage as ChatMessageT, UserMessageCreateDTO } from '../../models/models';
import { ChatInput } from '../chat-input/chat-input';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-chat-box',
  imports: [ChatMessage, ChatInput],
  templateUrl: './chat-box.html',
  styles: ``,
})
export class Chat {
  private route = inject(ActivatedRoute);
  private chatService = inject(ChatService);

  threadId = this.route.snapshot.paramMap.get('threadId');

  messages = signal<ChatMessageT[]>([
    { role: 'ai', text: "Hi! I'm Ryan's AI. Ask about experience, skills, or projects." },
  ]);

  public async onMessageSend(text: string) {
    this.messages.update((list) => [...list, { role: 'user', text }]);

    const reply = await this.generateReply(text);
    this.messages.update((list) => [...list, { role: 'ai', text: reply }]);
  }

  private async generateReply(prompt: string): Promise<string> {
    try {
      const body: UserMessageCreateDTO = {
        userId: 1,
        prompt: prompt
      }
      
      const response = await this.chatService.sendMessage(body);
      console.log('API response:', response);

      const lastMessage = response[response.length - 1];
      return lastMessage?.prompt || 'No response';
    } catch (error) {
      console.error('Error sending message:', error);
      return 'Sorry, there was an error processing your message.';
    }
  }
}
