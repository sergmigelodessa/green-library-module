using GreenLibrary.Models;

namespace GreenLibrary.Interfaces;

public interface IBookStorage
{
    List<Book> Load(string filePath);

    void Save(string filePath, List<Book> books);
}