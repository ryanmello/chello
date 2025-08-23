import { Component, inject, Input, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from '../chat-message/message';
import { ChatInput } from '../chat-input/chat-input';
import { MessageService } from '../../../services/message.service';
import { UIMessage, MessageCreateDTO } from '../../../models/models';
import { ThreadService } from '../../../services/thread.service';
import { MessageStore } from '../../../services/message-store.service';

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
  private messageStore = inject(MessageStore);

  messages = this.messageStore.messages;
  threadId = this.messageStore.threadId;

  constructor() {
    this.route.paramMap.subscribe((params) => {
      const threadIdParam = params.get('threadId');
      const newThreadId = threadIdParam ? Number(threadIdParam) : null;
      this.messageStore.threadId.set(newThreadId);
      if (newThreadId && newThreadId !== -1) {
        this.loadThread();
      }
    });
  }

  private async loadThread() {
    const currentThreadId = this.threadId();
    if (!currentThreadId) return;

    this.threadService.getThread(currentThreadId).subscribe({
      next: (respone) => {
        const threadMessages = respone.messages.map((message) => ({
          isHumanMessage: message.isHumanMessage,
          content: message.content,
        }));

        this.messages.set(threadMessages);
        console.log(this.messages());
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  public onMessageSend(text: string) {
    this.messageStore.messages.update((list) => [...list, { isHumanMessage: true, content: text }]);
    this.generateReply(text);
  }

  private generateReply(message: string): void {
    const currentThreadId = this.threadId();
    const body: MessageCreateDTO = {
      userId: 1,
      content: message,
      ...(currentThreadId && currentThreadId !== -1 ? { threadId: currentThreadId } : {}),
    };

    this.messageService.createMessage(body).subscribe({
      next: (response) => {
        this.messageStore.messages.update((list) => [
          ...list,
          { isHumanMessage: false, content: response.content },
        ]);
        this.messageStore.threadId.set(response.threadId);
      },
      error: (error) => {
        console.error('Error sending message:', error);
        this.messageStore.messages.update((list) => [
          ...list,
          { isHumanMessage: false, content: 'Sorry, there was an error processing your message.' },
        ]);
      },
    });
  }
}
