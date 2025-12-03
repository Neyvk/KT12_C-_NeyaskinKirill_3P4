public interface IFactory<T>
{
    T Create();
}
public class RandomNumberFactory : IFactory<int>
{
    Random rand = new Random();

    public int Create()
    {
        return rand.Next(0, 100);
    }
}

public class Person
{
    public string Name;
    public int Age;

    public override string ToString()
    {
        return Name + ", " + Age + " лет";
    }
}
public class PersonFactory : IFactory<Person>
{
    public Person Create()
    {
        Person p = new Person();
        Console.Write("Введите имя: ");
        p.Name = Console.ReadLine();
        Console.Write("Введите возраст: ");
        p.Age = int.Parse(Console.ReadLine());
        return p;
    }
}
public class Creator
{
    public static T[] CreateArray<T>(IFactory<T> factory, int n)
    {
        T[] array = new T[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = factory.Create();
        }
        return array;
    }
}
class Program
{
    static void Main()
    {
        IFactory<int> numberFactory = new RandomNumberFactory();
        Console.WriteLine("Сколько чисел создать?:");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Creator.CreateArray(numberFactory, n);
        Console.WriteLine("\nСлучайные числа:");
        for (int i = 0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);

        IFactory<Person> personFactory = new PersonFactory();
        Console.WriteLine("\nСколько людей создать?");
        n = int.Parse(Console.ReadLine());
        Person[] people = Creator.CreateArray(personFactory, n);
        Console.WriteLine("\nМассив людей:");
        for (int i = 0; i < people.Length; i++)
            Console.WriteLine(people[i]);
    }
}
