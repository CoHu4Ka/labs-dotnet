using System;

#nullable enable // ← Включаем строгую проверку null внутри файла

// ------------------------
// Класс Book
// ------------------------
class Book
{
    // ✅ Добавлено "required" — теперь компилятор требует задать Title при создании объекта.
    // Это предотвращает ситуацию, когда Title может остаться null.
    public required string Title { get; set; }

    public int Year { get; set; }

    public bool IsTaken { get; set; }

    // ✅ Конструктор гарантирует, что Title не будет null.
    // Используем проверку ?? throw — чтобы сразу выдать ошибку, если кто-то передаст null.
    public Book(string title, int year, bool isTaken = false)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Year = year;
        IsTaken = isTaken;
    }
}

// ------------------------
// Класс Library — логика операций
// ------------------------
static class Library
{
    // 📘 Просмотр всех книг
    public static void ShowAllBooks(Book[] books)
    {
        // ✅ Добавлена проверка: books не должен быть null
        if (books is null)
            throw new ArgumentNullException(nameof(books));

        Console.WriteLine("\nСписок книг:");
        foreach (Book book in books)
        {
            string status = book.IsTaken ? "Занята" : "Свободна";
            Console.WriteLine($"- {book.Title} ({book.Year}) — {status}");
        }
    }

    // 📗 Взять книгу
    public static void BorrowBook(Book[] books, string? title)
    {
        // ✅ Параметр title теперь string? — допускает null,
        // но внутри есть проверка, чтобы избежать ошибок при null.
        if (books is null)
            throw new ArgumentNullException(nameof(books));
        if (title is null)
        {
            Console.WriteLine("Название книги не может быть пустым (null).");
            return;
        }

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

    // 📕 Вернуть книгу
    public static void ReturnBook(Book[] books, string? title)
    {
        // ✅ Те же проверки, что и выше
        if (books is null)
            throw new ArgumentNullException(nameof(books));
        if (title is null)
        {
            Console.WriteLine("Название книги не может быть пустым (null).");
            return;
        }

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

// ------------------------
// Основная программа
// ------------------------
class Program
{
    static void Main()
    {
        // ✅ Массив инициализирован явно — компилятор уверен, что он не null.
        Book[] books = new Book[]
        {
            new Book("Война и мир", 1869),
            new Book("Преступление и наказание", 1866),
            new Book("Мастер и Маргарита", 1967),
            new Book("1984", 1949),
            new Book("Три мушкетера", 1844)
        };

        Library.ShowAllBooks(books);

        Console.WriteLine("\nВведите название книги, которую хотите взять:");
        string? userInput = Console.ReadLine();

        // ✅ Console.ReadLine() возвращает string? (может быть null)
        // поэтому используем null-forgiving оператор (!) при передаче:
        // Мы *уверены*, что пользователь что-то ввёл.
        // Если нет — BorrowBook сам обработает null.
        Library.BorrowBook(books, userInput!);

        Console.WriteLine("\nВведите название книги, которую хотите вернуть:");
        string? returnInput = Console.ReadLine();
        Library.ReturnBook(books, returnInput!);

        Console.WriteLine("\nИтоговый список книг:");
        Library.ShowAllBooks(books);
    }
}
