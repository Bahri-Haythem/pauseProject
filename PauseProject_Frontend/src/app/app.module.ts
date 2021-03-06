import { CommentComponent } from "./pages/examples/comment/comment.component";
import { StarService } from "./pages/examples/star/star.service";
import { StarComponent } from "./pages/examples/star/star.component";
import { AngularFireModule } from "angularfire2";
import {
  AngularFirestoreModule,
  AngularFirestore,
} from "angularfire2/firestore";
import { AngularFireAuthModule } from "angularfire2/auth";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HttpClient,HttpClientModule } from "@angular/common/http";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { TabsModule } from "ngx-bootstrap/tabs";
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';

import { RatingModule } from "ngx-bootstrap/rating";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { CarouselModule } from "ngx-bootstrap/carousel";
import { ModalModule } from "ngx-bootstrap/modal";
import { PagesModule } from "./pages/pages.module";
import { ToolsComponent } from "./pages/examples/tools/tools.component";
import { IndexComponent } from "./pages/examples/index/index.component";
import { ProfilepageComponent } from "./pages/examples/profilepage/profilepage.component";
import { RegisterpageComponent } from "./pages/examples/registerpage/registerpage.component";
import { LandingpageComponent } from "./pages/examples/landingpage/landingpage.component";
import { BooksComponent } from "./books/books.component";
import { BooksService } from "./books/books.service";
import { HeaderComponent } from "./header/header.component";
import { FooterComponent } from "./footer/footer.component";
import { MoviesComponent } from "./movies/movies.component";
import { GamesComponent } from "./games/games.component";
import { SeriesComponent } from "./series/series.component";
import { MusicComponent } from "./music/music.component";
import { MoviesService } from "./movies/movies.service";
import { SeriesService } from "./series/series.service";
import { GamesService } from "./games/games.service";
import { MusicService } from "./music/music.service";
import { environment } from "src/environments/environment";
import { LoginComponent } from "./loginpage/login/login.component";
import { BookComponent } from "./book/book.component";
import { SerieComponent } from "./serie/serie.component";
import { MovieComponent } from "./movie/movie.component";
import { GameComponent } from "./game/game.component";
import { MusicElementComponent } from "./music-element/music-element.component";
import { BookService } from "./book/book.service";
import { MovieService } from "./movie/movie.service";
import { SerieService } from "./serie/serie.service";
import { GameService } from "./game/game.service";
import { MusicElementService } from "./music-element/music.service";
//import { SearchComponent } from './search/search.component';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    SerieComponent,
    MovieComponent,
    GameComponent,
    MusicElementComponent,
    LoginComponent,
    StarComponent,
   // SearchComponent,
    CommentComponent,
  ],

  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    PagesModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFireAuthModule,
    AngularFirestoreModule,
    RatingModule.forRoot(), //to check
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
  providers: [
    BooksService,
    MoviesService,
    SeriesService,
    GamesService,
    MusicService,
    BookService,
    MovieService,
    SerieService,
    GameService,
    MusicElementService,
    StarService,
    AngularFirestore,
  ],
  
  bootstrap: [AppComponent],
})
export class AppModule {}
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
