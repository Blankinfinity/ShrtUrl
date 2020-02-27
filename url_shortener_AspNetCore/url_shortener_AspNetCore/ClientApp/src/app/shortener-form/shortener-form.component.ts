import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ShrtUrlservice } from '../services/shrt-url.service';

@Component({
  selector: 'app-shortener-form',
  templateUrl: './shortener-form.component.html',
  styleUrls: ['./shortener-form.component.scss']
})
export class ShortenerFormComponent {
  addressForm = this.fb.group({
    url: [null, Validators.required]
  });

  shrturl = '';

  constructor(private fb: FormBuilder, private shrtUrlService: ShrtUrlservice) {}

  onSubmit() {
    this.shrtUrlService.createShrtUrl(this.addressForm.get('url').value).subscribe(x => {
      this.shrturl = x;
      console.log(x);
    });
  }
}
