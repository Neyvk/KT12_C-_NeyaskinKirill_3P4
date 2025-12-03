public interface IList<T>
{
    void Add(T item);
    void Remove(T item);
    T Get(int index);
    void Set(int index, T item);
    int Count { get; }
}

public class ArrayList<T> : IList<T>
{
    T[] items = new T[4];
    int count = 0;

    public int Count { get { return count; } }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            T[] newItems = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
                newItems[i] = items[i];
            items = newItems;
        }
        items[count] = item;
        count++;
    }

    public void Remove(T item)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
            if (items[i].Equals(item))
            {
                index = i;
                break;
            }
        if (index == -1) return;
        for (int i = index; i < count - 1; i++)
            items[i] = items[i + 1];
        count--;
    }

    public T Get(int index)
    {
        return items[index];
    }

    public void Set(int index, T item)
    {
        items[index] = item;
    }
}

public class LinkedList<T> : IList<T>
{
    class Node
    {
        public T Value;
        public Node Next;
        public Node(T value) { Value = value; Next = null; }
    }

    Node head = null;
    int count = 0;

    public int Count { get { return count; } }

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
            head = newNode;
        else
        {
            Node current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
        count++;
    }

    public void Remove(T item)
    {
        if (head == null) return;
        if (head.Value.Equals(item))
        {
            head = head.Next;
            count--;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                count--;
                return;
            }
            current = current.Next;
        }
    }

    public T Get(int index)
    {
        Node current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;
        return current.Value;
    }

    public void Set(int index, T item)
    {
        Node current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;
        current.Value = item;
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

class Program
{
    static void Main()
    {
        IList<int> intList = new ArrayList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Remove(2);
        Console.WriteLine("ArrayList<int>:");
        for (int i = 0; i < intList.Count; i++)
            Console.WriteLine(intList.Get(i));

        IList<string> strList = new LinkedList<string>();
        strList.Add("Alice");
        strList.Add("Bob");
        strList.Set(1, "Charlie");
        Console.WriteLine("\nLinkedList<string>:");
        for (int i = 0; i < strList.Count; i++)
            Console.WriteLine(strList.Get(i));

        IList<Person> people = new ArrayList<Person>();
        people.Add(new Person { Name = "John", Age = 30 });
        people.Add(new Person { Name = "Jane", Age = 25 });
        Console.WriteLine("\nArrayList<Person>:");
        for (int i = 0; i < people.Count; i++)
            Console.WriteLine(people.Get(i));
    }
}
