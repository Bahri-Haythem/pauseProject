import { Router, NavigationEnd } from "@angular/router";
import {
  Component,
  OnInit,
  Renderer,
  HostListener,
  Inject,
} from "@angular/core";
import { Location } from "@angular/common";
import { DOCUMENT } from "@angular/common";
import {TranslateService} from '@ngx-translate/core';


@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent implements OnInit {
  constructor(
    private router: Router,
    private renderer: Renderer,
    public location: Location,
    @Inject(DOCUMENT) document
  ) {}
  @HostListener("window:scroll", ["$event"])
  onWindowScroll(e) {
    if (window.pageYOffset > 100) {
      var element = document.getElementById("navbar-top");
      if (element) {
        element.classList.remove("navbar-transparent");
        element.classList.add("bg-danger");
      }
    } else {
      var element = document.getElementById("navbar-top");
      if (element) {
        element.classList.add("navbar-transparent");
        element.classList.remove("bg-danger");
      }
    }
  }
  ngOnInit() {
    //this.onWindowScroll(event);
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        if (JSON.parse(localStorage.getItem("user")) == null) {
          localStorage.clear();
        }
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}
