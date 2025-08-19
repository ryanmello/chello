import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../chat-message/message';
import { ChatMessage as ChatMessageT } from '../../models/models';
import { ChatInput } from '../chat-input/chat-input';

@Component({
  selector: 'app-chat-box',
  imports: [ChatMessage, ChatInput],
  templateUrl: './chat-box.html',
  styles: ``,
})
export class Chat {
  private route = inject(ActivatedRoute);
  threadId = this.route.snapshot.paramMap.get('threadId');

  messages = signal<ChatMessageT[]>([
    { role: 'ai', text: "Hi! I'm Ryan's AI. Ask about experience, skills, or projects." },
  ]);

  onMessageSend(text: string) {
    this.messages.update((list) => [...list, { role: 'user', text }]);

    const reply = this.generateReply(text);
    this.messages.update((list) => [...list, { role: 'ai', text: reply }]);
  }

  private generateReply(prompt: string) {
    // make api call to the backend that contains the userId and prompt
    // get back the AI response and append it to the answer array
    return prompt;
  }
}
