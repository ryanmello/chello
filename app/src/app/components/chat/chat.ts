import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

type Message = { role: 'user' | 'ai'; text: string };

@Component({
  selector: 'app-chat',
  imports: [],
  templateUrl: './chat.html',
  styles: ``,
})
export class Chat {
  private route = inject(ActivatedRoute);
  threadId = this.route.snapshot.paramMap.get('threadId');

  messages = signal<Message[]>([
    { role: 'ai', text: "Hi! I'm Ryan's AI. Ask about experience, skills, or projects." },
  ]);

  handleSend(input: HTMLInputElement) {
    const text = input.value.trim();
    input.value = '';

    if (!text) return;

    this.messages.update((list) => [...list, { role: 'user', text }]);

    const reply = this.generateReply(text);
    this.messages.update((list) => [...list, { role: 'ai', text: reply }]);
  }

  private generateReply(prompt: string) {
    return prompt;
  }
}
