import { Component } from '@angular/core';
import { HlmButton } from '@spartan-ng/helm/button';
import { SidebarFooter } from '../sidebar-footer/sidebar-footer';
import { SidebarLink } from '../sidebar-link/sidebar-link';

@Component({
  selector: 'app-sidebar',
  imports: [HlmButton, SidebarFooter, SidebarLink],
  templateUrl: './sidebar.html',
  styles: ``,
})
export class Sidebar {
  threads = [
    { title: 'First' },
    { title: 'Second' },
    { title: 'Third' }
  ];
}
