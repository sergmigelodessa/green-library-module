using System.Xml.Linq;
using GreenLibrary.Interfaces;
using GreenLibrary.Models;


namespace GreenLibrary.Data.Xml;

public sealed class XmlBookStorage : IBookStorage
{
    public List<Book> Load(string filePath)
    {
        var document = XDocument.Load(filePath);
        var books = document.Root?.Elements("book");

        return books.Select(ReadBook).ToList();
    }

    public void Save(string filePath, List<Book> books)
    {
        var document = new XDocument(
            new XElement("books",
                books.Select(book => new XElement(
                    "book",
                    new XElement("title", book.Title),
                    new XElement("author", book.Author),
                    new XElement("pages", book.PagesCount.ToString()))
                )));

        document.Save(filePath);
    }

    private static Book ReadBook(XElement element)
    {
        var title = element.Element("title")?.Value;
        var author = element.Element("author")?.Value;
        var pagesCountStr = element.Element("pages")?.Value;

        // yes, here should be more smart validations))
        int pages = int.Parse(pagesCountStr);

        return new Book(title, author, pages);
    }
}