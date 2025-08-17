import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chat',
  imports: [],
  templateUrl: './chat.html',
  styles: ``
})
export class Chat {
  private route = inject(ActivatedRoute);
  threadId = this.route.snapshot.paramMap.get("threadId")
}
