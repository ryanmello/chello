import { Component, Input } from '@angular/core';
import { HlmButton } from '@spartan-ng/helm/button';
import { SidebarFooter } from '../sidebar-footer/sidebar-footer';
import { SidebarLink } from '../sidebar-link/sidebar-link';
import { Thread } from '../../../models/models';

@Component({
  selector: 'app-sidebar',
  imports: [HlmButton, SidebarFooter, SidebarLink],
  templateUrl: './sidebar.html',
  styles: ``,
})
export class Sidebar {
  @Input() threads: Thread[] = [];
  @Input() loading: boolean = false;
  @Input() error: string | null = null;
}
