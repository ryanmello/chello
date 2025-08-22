import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../chat-message/message';
import { ChatInput } from '../chat-input/chat-input';
import { MessageService } from '../../../services/message.service';
import { UIMessage, MessageCreateDTO } from '../../../models/models';
import { ThreadService } from '../../../services/thread.service';

@Component({
  selector: 'app-chat-box',
  imports: [ChatMessage, ChatInput],
  templateUrl: './chat-box.html',
  styles: ``,
})
export class Chat {
  private route = inject(ActivatedRoute);
  private messageService = inject(MessageService);
  private threadService = inject(ThreadService);

  messages = signal<UIMessage[]>([]);
  threadId = -1;

  constructor() {
    this.route.paramMap.subscribe((params) => {
      const threadIdParam = params.get('threadId');
      this.threadId = threadIdParam ? Number(threadIdParam) : -1;
      if (this.threadId !== -1) {
        this.loadThread();
      }
    });
  }

  private async loadThread() {
    this.threadService.getThread(this.threadId).subscribe({
      next: (respone) => {
        const threadMessages = respone.messages.map((message) => ({
          isHumanMessage: message.isHumanMessage,
          content: message.content
        }));
        
        this.messages.set(threadMessages);
        console.log(this.messages())
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  public onMessageSend(text: string) {
    this.messages.update((list) => [...list, { isHumanMessage: true, content: text }]);
    this.generateReply(text);
  }

  private generateReply(message: string): void {
    const body: MessageCreateDTO = {
      userId: 1,
      content: message,
      ...(this.threadId !== -1 ? { threadId: this.threadId } : {}),
    };

    this.messageService.createMessage(body).subscribe({
      next: (response) => {
        this.messages.update((list) => [
          ...list,
          { isHumanMessage: false, content: response.content },
        ]);
        this.threadId = response.threadId;
      },
      error: (error) => {
        console.error('Error sending message:', error);
        this.messages.update((list) => [
          ...list,
          { isHumanMessage: false, content: 'Sorry, there was an error processing your message.' },
        ]);
      },
    });
  }
}
