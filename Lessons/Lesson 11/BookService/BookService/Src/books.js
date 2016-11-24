import 'fetch-polyfill'; import {HttpClient} from 'aurelia-fetch-client'; 
 
let httpClient = new HttpClient();
export class Books { 
 
    constructor(data) {
        Object.assign(this, data);
        this.heading = 'Testing the Book Web API from Aurelia';
        this.bookList = null;
        this.status = null;
        this.id = 0;
        this.title = "";
        this.authorId = ""; 
        this.BookId = 0;
        this.getBooks();
    } 
 
    activate(path) {
        if(path && path.id) {
            this.BookId = path.id;
            this.getBook(this.BookId);
        }
    }

    getBooks() {
        httpClient.fetch('http://localhost:65030/api/books', {
            method: "GET"
        })
        .then(response => response.json())
        .then(data => {
            this.bookList = data;
            console.log(data);
        });
    }
    
    getBook(id) {
        var url = "http://localhost:65030/api/books/" + id;
        console.log(this.BookId);
        httpClient.fetch(url, {
            method: "GET"         })
            .then(response => response.json())
            .then(data => {
                    this.id = data.Id;
                    this.title =  data.Title;
                    this.authorId =  data.AuthorId;
                 })
             } 
 
 
    insertBook() {
        var book = {
            "Title": this.title,
            // uncomment for simplicity
            //"Year": this.id,
            //"Price": this.price,
            //"Genre": this.genre,
            "AuthorId": this.authorId
        }; 
 
        httpClient.fetch('http://localhost:65030/api/books', {
            method: "POST",
            headers: {
                'content-type': 'application/json'          },
                body: JSON.stringify(book)         })
         .then(response => response.json())
         .then(data => {
             this.status = data;
             this.getBooks();
             });
             } 
 
    updateBook()
    {
        var book = {
            "Id": this.id,
            "Title": this.title,
            // uncomment for simplicity
            //"Year": this.id,
            //"Price": this.price,
            //"Genre": this.genre,
            "AuthorId": this.authorId
        }; 
 
        var url = "http://localhost:65030/api/books/" + this.id; 
        httpClient.fetch(url, {
            method: "PUT",
            headers: {
                'content-type': 'application/json'              },
            body: JSON.stringify(book)      })
            .then(response => response.json())
            .then(data => {
                this.status = data;
                this.getBooks();
                })
                } 
 
    deleteBook() {
        var url = "http://localhost:65030/api/books/" + this.id; 
        httpClient.fetch(url, { 
            method: "DELETE"         })
            .then(response => response.json())
            .then(data => {
            this.status = data;
            this.getBooks();
            console.log(data);
            });
    }
} 
