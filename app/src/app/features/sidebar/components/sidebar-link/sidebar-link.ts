import { Component, Input } from '@angular/core';
import { Thread } from '../../models/models';
import { HlmButton } from '@spartan-ng/helm/button';

@Component({
  selector: 'app-sidebar-link',
  imports: [HlmButton],
  templateUrl: './sidebar-link.html',
  styles: ``,
})
export class SidebarLink {
  @Input() thread!: Thread;
}
