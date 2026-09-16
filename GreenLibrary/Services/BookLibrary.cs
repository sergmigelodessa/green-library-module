using GreenLibrary.Interfaces;
using GreenLibrary.Models;

namespace GreenLibrary.Services;

public class BookLibrary
{
    private readonly IBookStorage _storage;
    private List<Book> books = [];

    public BookLibrary(IBookStorage storage)
    {
        _storage = storage;
    }

    public List<Book> Books => books;

    public void Add(Book book)
    {
        books.Add(book);
    }

    public void Load(string filePath)
    {
        books.AddRange(_storage.Load(filePath));
    }

    public void Save(string filePath)
    {
        _storage.Save(filePath, books);
    }

    public void SortByAuthorAndTitle()
    {
        books = books
            .OrderBy(book => book.Author, StringComparer.OrdinalIgnoreCase)
            .ThenBy(book => book.Title, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public List<Book> Search(string str)
    {
        return books.Where(book => book.Title.Contains(str)).ToList();  
    }
}