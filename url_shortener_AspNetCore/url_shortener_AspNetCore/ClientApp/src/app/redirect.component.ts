import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShrtUrlservice } from './services/shrt-url.service';

@Component({
    template: '<h1>Redirecting...</h1>'
})
export class RedirectComponent {
    constructor(private route: ActivatedRoute, private shrtUrlService: ShrtUrlservice, private router: Router) {

        this.route.params.subscribe((params) => {
            this.shrtUrlService.getLink(params.shortUrl).subscribe(x => {
                window.location.href = x;
            });
        });
    }
}
