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

  public onMessageSend(text: string) {
    this.messages.update((list) => [...list, { role: 'user', text }]);
    this.generateReply(text);
  }

  private generateReply(prompt: string): void {
    const body: UserMessageCreateDTO = {
      userId: 1,
      prompt: prompt
    }
    
    this.chatService.sendMessage(body).subscribe({
      next: (response) => {
        console.log('API response:', response);
        const lastMessage = response[response.length - 1];
        const reply = lastMessage?.prompt || 'No response';
        
        // Add AI response to messages
        this.messages.update((list) => [...list, { role: 'ai', text: reply }]);
      },
      error: (error) => {
        console.error('Error sending message:', error);
        this.messages.update((list) => [...list, { role: 'ai', text: 'Sorry, there was an error processing your message.' }]);
      }
    });
  }
}
