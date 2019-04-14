import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html'
})
export class BookComponent {
  public books: Book[];
  public editing: boolean = false;
  public currentBook: Book;
  private http: HttpClient;
  private url: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.url = `${baseUrl}api/Book`;
    http.get<Book[]>(this.url).subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
  
  public getDetails(id: number) {
    this.http.get<Book>(this.url).subscribe(result => {
      this.currentBook = result;
      this.editing = true;
    }, error => console.error(error));
  }

  public edit(toEdit: Book) {
    this.currentBook = toEdit ? toEdit : new Book();
    this.editing = true;
  }

  public cancel() {
    this.currentBook = new Book();
    this.editing = false;
  }

  public delete(id: number) {
    this.http.delete<Book[]>(`${this.url}/${id}`).subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }

  public save() {
    console.log("Passou no save")
    if (this.currentBook.id) {
      this.http.put<Book[]>(this.url, this.currentBook).subscribe(result => {
        this.cancel();
        this.books = result;
      }, error => console.error(error));
    } else {
      this.http.post<Book[]>(this.url, this.currentBook).subscribe(result => {
        this.books = result;
        this.cancel();
      }, error => console.error(error));
    }
  }
}

class Book {
  id: string;
  title: string;
  author: string;
  quantity: number;
}
