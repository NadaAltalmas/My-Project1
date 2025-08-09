using System;
using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Book
{

    public string BookTitle { get; set; }
    public bool IsCheckedOut { get; set; }

    public Book(string book)
    {
        BookTitle = book;
        IsCheckedOut = false;

    }
}

class User
{
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; }
    public User(string name)
    {
        Name = name;
        BorrowedBooks = new List<Book>();

    }
    // Added in the user class:
    public bool CanBorrow()
    {
        return BorrowedBooks.Count < 3;
    }
    

}

class LibrarySystem
{
    private List<Book> books = new List<Book>();
    private User user;

    public LibrarySystem()
    {
        //Sample books
        books.Add(new Book("C# Fundamentals"));
        books.Add(new Book("Introduction to Algorithms"));
        books.Add(new Book("Clean Code"));
        books.Add(new Book("The Pragmatic Programmer"));

        //One user for simplicity
        user = new User("Alice");

    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Search for a Book");
            Console.WriteLine("2. Borrow a Book");
            Console.WriteLine("3. Return a Book");
            Console.WriteLine("4. View borrowed Books");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option: ");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    SearchBook();
                    break;
                case "2":
                    BorrowBook();
                    break;
                case "3":
                    ReturnBook();
                    break;
                case "4":
                    ViewBorrowedBooks();
                    break;
                case "5":
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

        }
    }

    private void SearchBook()
    {
        Console.WriteLine("Enter the name of the book you want to search:");
        string BookTitle = Console.ReadLine();

        Book found = books.Find(b => b.BookTitle.Equals(BookTitle, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"Book '{found.BookTitle}' is {(found.IsCheckedOut ? "Currently checked out " : "available")}.");
        }
        else
        {
            Console.WriteLine("Book is not found in the library.");
        }
    }

    private void BorrowBook()
    {
        // Used in the BorrowBook() method inside the LibrarySystem class:
        if (!user.CanBorrow())
        {
            Console.WriteLine("Borrowing limit reached. Return a book before borrowing another.");
            return;
        }
        Console.WriteLine("Enter book title to Borrow:");
        string BookTitle = Console.ReadLine();

        Book bookToBorrow = books.Find(b => b.BookTitle.Equals(BookTitle, StringComparison.OrdinalIgnoreCase));

        if (bookToBorrow == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (bookToBorrow.IsCheckedOut)
        {
            Console.WriteLine("Sorry this book is already checked out");
        }
        else
        {
            // When borrowing a book:
            bookToBorrow.IsCheckedOut = true;
            user.BorrowedBooks.Add(bookToBorrow);
            Console.WriteLine($"You have successfully borrowed '{bookToBorrow.BookTitle}'.");

        }
    }

    private void ReturnBook()
    {
        Console.WriteLine("Enter book title to return:");
        string BookTitle = Console.ReadLine();
        Book bookToReturn = user.BorrowedBooks.Find(b => b.BookTitle.Equals(BookTitle, StringComparison.OrdinalIgnoreCase));

        if (bookToReturn != null)
        {
            //When returning a book:
            bookToReturn.IsCheckedOut = false;
            user.BorrowedBooks.Remove(bookToReturn);
            Console.WriteLine($"You have returned '{bookToReturn.BookTitle}'.");
        }
        else
        {
            Console.WriteLine("You haven't borrowed this book.");
        }
    }

    private void ViewBorrowedBooks()
    {
        Console.WriteLine("Books you have borrowed:");
        if (user.BorrowedBooks.Count == 0)
        {
            Console.WriteLine("None.");
        }
        else
        {
            foreach (Book book in user.BorrowedBooks)
            {
                Console.WriteLine($"- {book.BookTitle}");
            }
            
        } 
    }
  }

class Program
{
    static void Main()
    {
        LibrarySystem Library = new LibrarySystem();
        Library.Run();
    }
    
}


