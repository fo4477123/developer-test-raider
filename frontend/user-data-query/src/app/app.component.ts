import { Component, OnInit } from '@angular/core';
import { UserapiService } from './userapi.service';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IconapiService } from './iconapi.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DatePipe],
  imports: [CommonModule, FormsModule]
})
export class AppComponent implements OnInit {
  users: any[] = [];
  filteredUsers: any[] = [];
  searchQuery: string = '';

  constructor(
    private userapiService: UserapiService,
    private iconapiService: IconapiService,
    private sanitizer: DomSanitizer,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.userapiService.getUsers().subscribe(userData => {
      this.users = userData;
      this.users.forEach(user => {
        user.balance = user.balance.replace(',', '');
        const y: number = Number(user.balance);
        user.numericBalance = y;
        if (user.iconPath.length > 0) {
          /*this.iconapiService.getImage(user.iconPath).subscribe((icon: Blob) => {
            console.log('Recivied blob :' + icon.size);
            const img = URL.createObjectURL(icon);
            user.safeIconUrl = this.sanitizer.bypassSecurityTrustUrl(img);
          });*/
          user.safeIconUrl = this.iconapiService.getImagePath(user.iconPath);
        } else {
          /*this.iconapiService.getImage("unknown").subscribe((icon: Blob) => {
            console.log('Recivied blob' + icon);
            const img = URL.createObjectURL(icon);
            user.safeIconUrl = this.sanitizer.bypassSecurityTrustUrl(img);
          });*/
          user.safeIconUrl = this.iconapiService.getImagePath("unknown");
        }
      });
      this.users.sort((a, b) => a.name.localeCompare(b.name));
      this.filteredUsers = [...this.users];
    });
  }

  onSearch() {
    this.filteredUsers = this.users.filter(user => user.name.toLowerCase().includes(this.searchQuery.toLowerCase()));
  }

  resetBalances() {
    this.users.forEach(user => {
      user.balance = "0";
      user.numericBalance = 0;
    });
    this.users.sort((a, b) => a.name.localeCompare(b.name));
    this.filteredUsers = [...this.users];
  }
}
