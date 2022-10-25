
namespace LendingLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public int NumOfPages { get; set; }

        public Author Author { get; set; }
    }

    public class Author
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}