using GreenLibrary.Interfaces;
using GreenLibrary.Models;
using GreenLibrary.Services;
using Moq;

namespace GreenLibrary.Tests;

public class BookLibraryTests
{
    [Test]
    public void Add_AddFewBooks()
    {
        var library = new BookLibrary(new Mock<IBookStorage>().Object);
        var book = new Book("Test 1", "Test AAA", 202);

        library.Add(book);

        Assert.That(library.Books, Has.Count.EqualTo(1));
    }

    [Test]
    public void SortByAuthorAndTitle_CustomSorting()
    {
        var library = new BookLibrary(new Mock<IBookStorage>().Object);
        library.Add(new Book("B1", "B", 80));
        library.Add(new Book("A1", "A", 200));
        library.Add(new Book("C1", "C", 120));

        library.SortByAuthorAndTitle();

        Assert.That(
            library.Books.Select(book => book.Title),
            Is.EqualTo(["A1", "B1", "C1"]));
    }

    [Test]
    public void SearchByTitle_Find1ByStr()
    {
        var library = new BookLibrary(new Mock<IBookStorage>().Object);
        library.Add(new Book("test1AAA", "QQQQQ", 120));
        library.Add(new Book("test2BBB", "WWWWWW", 80));
        library.Add(new Book("test3CCC", "EEEEEE", 200));

        var result = library.Search("test2");

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Title, Is.EqualTo("test2BBB"));
    }
}
