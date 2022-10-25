
using System.Collections;

namespace LendingLibrary
{
    class Program
    {
        // instantiate a new Library and a new Backpack

        private static readonly Library library = new Library();
        private static readonly Backpack<Book> bookBag = new Backpack<Book>();

        static void Main(string[] args)
        {
            // create our book dictionary
            LoadBooks();
            // runs our program
            UserInterface(); 
        }

        static void UserInterface()
        {
            while(true)
            {
                // all options here
                    Console.WriteLine("Welcome to the lending Library");
                    Console.WriteLine("Pick an option...");
                    Console.WriteLine("1. View All Books");
                    Console.WriteLine("2. Add New Book");
                    Console.WriteLine("3. Borrow A Book");
                    Console.WriteLine("4. Return a Book");
                    Console.WriteLine("5. View Book Bag");
                    Console.WriteLine("6. Exit");

                        // get answer from user
                    string answer = Console.ReadLine();

                    // switch case 
                    switch (answer)
                    {
                        case "1":
                        Console.Clear();
                        Console.WriteLine("Library");
                        Console.WriteLine("=======");
                        OutputBooks(library);
                        break;

                        case "2":
                        Console.Clear();
                        AddBook();
                        Console.Clear();
                        break;

                        case "3":
                        Console.Clear();
                        BorrowBook();
                        Console.Clear();
                        break;

                        case "4":
                        Console.Clear();
                        ReturnBook();
                        Console.Clear();
                        break;

                        case "5":
                        Console.Clear();
                        Console.WriteLine("=======");
                        OutputBooks(bookBag);
                        break;

                        case "6":
                        return;

                        default:
                        Console.WriteLine("Invalid option...");
                        break;



                    }


                    


            }
        }
        // Create a predefined set of books
        static void LoadBooks()
        {
            library.Add("Alice In Wonderland", "Lewis", "Carol", 146);
            library.Add("The Greate Gatsby", "F. Scott", "Fitzgerald", 218);
            library.Add("To Kill A Mockingbird", "Harper", "Lee", 281);
            library.Add("Lord Of The Flies", "William", "Golding", 224);

        }

        static void OutputBooks(IEnumerable<Book> books)
        {
            int counter = 1;

            foreach (Book book in books)
            {
                Console.WriteLine($"{counter++}. {book.Title}, {book.Author.FirstName} {book.Author.LastName}");
            }
            Console.WriteLine();
        }

        private static void AddBook()
        {
            Console.WriteLine("Please enter the following details:");
            Console.WriteLine("Book Title : ");
            string title = Console.ReadLine();

                Console.WriteLine("Author First Name : ");
                string first = Console.ReadLine();

                Console.WriteLine("Author Last Name : ");
                string last = Console.ReadLine();

                Console.WriteLine("Number of pages : ");
                int numberOfPages  = Convert.ToInt32(Console.ReadLine());

                library.Add(title, first, last, numberOfPages);
        

        }
        private static void BorrowBook()
        {   // go through all books available 
            foreach (Book book in library)
            {
                Console.WriteLine(book.Title);
            }
            // ask which book to borrow 
            Console.WriteLine();
            Console.WriteLine("Which Book would you like to borrow?");

            // ask for user selection 
            string selection = Console.ReadLine();

            // assign the borrowed book to a variable 
            Book borrowed = library.Borrow(selection);

            // pack it in our bookbag 
            bookBag.Pack(borrowed);
        }

        static void ReturnBook()
        {
            OutputBooks(bookBag);
            Console.WriteLine("Which book would you like to return?");
            int selection = Convert.ToInt32(Console.ReadLine());
            Book bookToReturn = bookBag.Unpack(selection - 1);
            Console.WriteLine("=======");
    
            Console.WriteLine("Book returned to Library");

            library.Return(bookToReturn);
            Console.WriteLine("Done :)");
        }
    }
}
