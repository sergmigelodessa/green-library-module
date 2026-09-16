using GreenLibrary.Data.Xml;
using GreenLibrary.Models;
using GreenLibrary.Services;

namespace GreenLibrary.Tests;

public class BooksStorageIntegrationTests
{
    [Test]
    public void SaveAndLoad_IntoXMLFile()
    {
        var filePath = Path.Combine(Path.GetTempPath(), $"books-{Guid.NewGuid()}.xml");

        try
        {
            var service1 = new BookLibrary(new XmlBookStorage());
            service1.Add(new Book("Test AAAA", "NVVV", 120));
            service1.Add(new Book("Test DDDD", "MKKK", 200));
            service1.Save(filePath);

            var service2 = new BookLibrary(new XmlBookStorage());
            service2.Load(filePath);

            var recordsOrigin = service1.Books.Select(book => (book.Title, book.Author, book.PagesCount));
            var recordsFromFile = service2.Books.Select(book => (book.Title, book.Author, book.PagesCount));

            Assert.That(recordsFromFile, Is.EqualTo(recordsOrigin));
        }
        finally
        {
            File.Delete(filePath);
        }
    }
}

