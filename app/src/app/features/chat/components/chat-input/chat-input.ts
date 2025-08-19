import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-chat-input',
  imports: [],
  templateUrl: './chat-input.html',
  styles: ``,
})
export class ChatInput {
  @Output() send = new EventEmitter<string>();

  handleSend(input: HTMLInputElement) {
    const text = input.value.trim();
    if (text) {
      this.send.emit(text);
      input.value = '';
    }
  }
}
