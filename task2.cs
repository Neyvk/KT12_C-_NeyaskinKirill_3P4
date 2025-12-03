public interface IComparer<T>
{
    int Compare(T x, T y);
}

public class StringComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x.Length < y.Length) return -1;
        if (x.Length > y.Length) return 1;
        return 0;
    }
}

public class Book
{
    public string Title;
    public double Price;

    public override string ToString()
    {
        return Title + " - " + Price;
    }
}

public class BookComparer : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        if (x.Price < y.Price) return -1;
        if (x.Price > y.Price) return 1;
        return 0;
    }
}

public class Sorter
{
    public static void Sort<T>(T[] array, IComparer<T> comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[i], array[j]) > 0)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string[] words = { "бе", "бубу", "б", "бябябябяяб" };
        Sorter.Sort(words, new StringComparer());
        Console.WriteLine("Сортировка строк по длине:");
        for (int i = 0; i < words.Length; i++)
            Console.WriteLine(words[i]);

        Book[] books = {
            new Book { Title = "Улюлюлюлюл", Price = 2 },
            new Book { Title = "Парапарапарап", Price = 50 },
            new Book { Title = "Трам_парам-парам_пам-пам", Price = 10 }
        };
        Sorter.Sort(books, new BookComparer());
        Console.WriteLine("\nСортировка книг по цене:");
        for (int i = 0; i < books.Length; i++)
            Console.WriteLine(books[i]);
    }
}
