using System;

class Book
{
    public string Title { get; set; }
    public int Year { get; set; }
    public bool IsTaken { get; set; }

    public Book(string title, int year, bool isTaken = false)
    {
        Title = title;
        Year = year;
        IsTaken = isTaken;
    }
}

class Library
{
    // Вывести все книги
    public static void ShowAllBooks(Book[] books)
    {
        Console.WriteLine("\nСписок книг:");
        foreach (Book book in books)
        {
            string status = book.IsTaken ? "Занята" : "Свободна";
            Console.WriteLine($"- {book.Title} ({book.Year}) — {status}");
        }
    }

    // Взять книгу
    public static void BorrowBook(Book[] books, string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (book.IsTaken)
                {
                    Console.WriteLine($"Книга \"{title}\" уже занята.");
                }
                else
                {
                    book.IsTaken = true;
                    Console.WriteLine($"Вы взяли книгу \"{title}\".");
                }
                return;
            }
        }

        Console.WriteLine($"Книга \"{title}\" не найдена.");
    }

    // Вернуть книгу
    public static void ReturnBook(Book[] books, string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (!book.IsTaken)
                {
                    Console.WriteLine($"Книга \"{title}\" и так была свободна!");
                }
                else
                {
                    book.IsTaken = false;
                    Console.WriteLine($"Вы вернули книгу \"{title}\".");
                }
                return;
            }
        }

        Console.WriteLine($"Книга \"{title}\" не найдена.");
    }
}

class Program
{
    static void Main()
    {
        // Создаём массив из 5 книг
        Book[] books = new Book[]
        {
            new Book("Война и мир", 1869),
            new Book("Преступление и наказание", 1866),
            new Book("Мастер и Маргарита", 1967),
            new Book("1984", 1949),
            new Book("Три мушкетера", 1844)
        };

        // Демонстрация работы
        Library.ShowAllBooks(books);

        Console.WriteLine("\nПопробуем взять книгу '1984':");
        Library.BorrowBook(books, "1984");

        Console.WriteLine("\nПопробуем вернуть книгу '1984':");
        Library.ReturnBook(books, "1984");

        Console.WriteLine("\nПопробуем вернуть несуществующую книгу 'Гарри Поттер':");
        Library.ReturnBook(books, "Гарри Поттер");

        Console.WriteLine("\nИтоговый список книг:");
        Library.ShowAllBooks(books);
    }
}
