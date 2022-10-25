

using System;
using System.Collections;
using System.Collections.Generic;

namespace LendingLibrary
{
public interface ILibrary : IReadOnlyCollection<Book>
{
     /// <summary>
     /// Add a Book to the library.
     /// </summary>
    void Add(string title, string firstName, string lastName, int numberOfPages);

     /// <summary>
     /// Remove a Book from the library with the given title.
     /// </summary>
     /// <returns>The Book, or null if not found.</returns>
    Book Borrow(string title);

     /// <summary>
     /// Return a Book to the library.
     /// </summary>
    void Return(Book book);
 }

// Since books need to be borrowed by Title,
//  use a private Dictionary<string, Book> for storage.

public class Library : ILibrary
{ 
    private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();

    // public int Count { get; set;} = 0;
    public int Count => books.Count; // this property is used to count the number of books in our library.

// Add a book
    public void Add(string title, string firstName, string lastName, int numberOfPages)
    {
        // book object is created.
        Book book = new Book
        {
            Title = title,
            Author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
            },
            NumOfPages = numberOfPages,
        };
        // book is added to dictionary
        books.Add(title, book); // adding whatever book we create to our dictionary 
    }

    // borrow a book
    public Book Borrow(string title)
    {
        if(!books.ContainsKey(title))
        {
            return null;
        } 
        Book book = books[title]; // find book that matches title
        books.Remove(title); // removes book from library

        return book; // book that was borrowed

    }

// return book to library
public void Return(Book book)
{
    // readd book to library shelf
    books.Add(book.Title, book);
}

public IEnumerator<Book> GetEnumerator()
{
    foreach (Book book in books.Values)
    yield return book;
}

IEnumerator IEnumerable.GetEnumerator()
{
    return GetEnumerator();
}

}



}