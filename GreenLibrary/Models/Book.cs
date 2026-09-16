namespace GreenLibrary.Models; 

public class Book
{
    public Book(string title, string author, int pagesCount)
    {
        Title = title;
        Author = author;
        PagesCount = pagesCount;
    }

    public string Title { get; }
        
    public string Author { get; }

    public int PagesCount { get; }
}