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

  handleSend(textArea: HTMLTextAreaElement) {
    const text = textArea.value.trim();
    if (text) {
      this.send.emit(text);
      textArea.value = '';
      this.resetHeight(textArea);
    }
  }

  handleKeydown(event: KeyboardEvent, textArea: HTMLTextAreaElement) {
    if (event.key === 'Enter' && !event.shiftKey) {
      event.preventDefault();
      this.handleSend(textArea);
    }
  }

  adjustHeight(textArea: HTMLTextAreaElement) {
    textArea.style.height = 'auto';
    textArea.style.height = Math.min(textArea.scrollHeight, 128) + 'px'; // Max height of 128px (8rem)
  }

  private resetHeight(textArea: HTMLTextAreaElement) {
    textArea.style.height = 'auto';
  }
}
