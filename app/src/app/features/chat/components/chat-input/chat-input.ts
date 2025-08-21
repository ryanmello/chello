import { Component, EventEmitter, Output } from '@angular/core';
import { HlmButton } from '@spartan-ng/helm/button';
import { HlmInput } from '@spartan-ng/helm/input';

@Component({
  selector: 'app-chat-input',
  imports: [HlmButton, HlmInput],
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
