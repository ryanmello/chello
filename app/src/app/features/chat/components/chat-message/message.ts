import { Component, input } from '@angular/core';
import { ChatMessage as ChatMessageT } from '../../models/models';

@Component({
  selector: 'app-chat-message',
  imports: [],
  templateUrl: './message.html',
  styles: ``,
})
export class ChatMessage {
  m = input.required<ChatMessageT>();
}
