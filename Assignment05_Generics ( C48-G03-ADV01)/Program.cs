using System;
using System.Collections.Generic;
using System.Threading;

namespace Assignment05_Generics
{
    // Q2
    class Container<T>
    {
        private T value;

        public void Add(T value)
        {
            this.value = value;
        }

        public T Get()
        {
            return value;
        }
    }

    // Q3
    class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    // Q4 and Q5
    class GenericMethods
    {
        public static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public static T FindMax<T>(T first, T second) where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
                return first;

            return second;
        }
    }

    // Q6
    interface IRepository<T>
    {
        void Add(T item);
        T Get(int index);
    }

    class StudentRepository : IRepository<string>
    {
        private List<string> students = new List<string>();

        public void Add(string item)
        {
            students.Add(item);
        }

        public string Get(int index)
        {
            return students[index];
        }
    }

    // Q7
    class ValueTypeExample<T> where T : struct
    {
        public T Value { get; set; }

        public ValueTypeExample(T value)
        {
            Value = value;
        }
    }

    // Q8
    class ReferenceTypeExample<T> where T : class
    {
        public T Value { get; set; }

        public ReferenceTypeExample(T value)
        {
            Value = value;
        }
    }

    // Q9
    class Creator<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    // Q10
    interface IPrintable
    {
        void Print();
    }

    class Report : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Report is printed.");
        }
    }

    class Printer<T> where T : IPrintable
    {
        public void PrintItem(T item)
        {
            item.Print();
        }
    }

    // Q11
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    class Dog : Animal
    {
    }

    class AnimalBox<T> where T : Animal
    {
        public void MakeAnimalEat(T animal)
        {
            animal.Eat();
        }
    }

    // Q12
    class Employee
    {
        public string Name { get; set; }

        public Employee()
        {
            Name = "New Employee";
        }
    }

    class PrintableEmployee : Employee, IPrintable
    {
        public void Print()
        {
            Console.WriteLine(Name + " is an employee.");
        }
    }

    class EmployeeManager<T> where T : Employee, IPrintable, new()
    {
        public void Work(T employee)
        {
            employee.Print();
        }
    }

    // Q14
    class SafeList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= items.Count)
                return default(T);

            return items[index];
        }
    }

    // Q15
    interface IProducer<out T>
    {
        T GetItem();
    }

    class DogProducer : IProducer<Dog>
    {
        public Dog GetItem()
        {
            return new Dog();
        }
    }

    // Q16
    interface IConsumer<in T>
    {
        void Consume(T item);
    }

    class AnimalConsumer : IConsumer<Animal>
    {
        public void Consume(Animal item)
        {
            item.Eat();
        }
    }

    // Q18
    class GenericCounter<T>
    {
        public static int Count = 0;

        public GenericCounter()
        {
            Count++;
        }
    }

    // Q19
    class DogBox : AnimalBox<Dog>
    {
    }

    // Q20
    class Cache<TKey, TValue>
    {
        private class CacheItem
        {
            public TValue Value { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        private Dictionary<TKey, CacheItem> items = new Dictionary<TKey, CacheItem>();

        public void Add(TKey key, TValue value, TimeSpan expiration)
        {
            CacheItem item = new CacheItem();
            item.Value = value;
            item.ExpirationTime = DateTime.Now.Add(expiration);

            items[key] = item;
        }

        public TValue Get(TKey key)
        {
            if (!items.ContainsKey(key))
                return default(TValue);

            CacheItem item = items[key];

            if (DateTime.Now >= item.ExpirationTime)
            {
                items.Remove(key);
                return default(TValue);
            }

            return item.Value;
        }

        public void Remove(TKey key)
        {
            if (items.ContainsKey(key))
                items.Remove(key);
        }

        public bool Contains(TKey key)
        {
            if (!items.ContainsKey(key))
                return false;

            if (DateTime.Now >= items[key].ExpirationTime)
            {
                items.Remove(key);
                return false;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Assignment 05 - Generics =====");
            Console.WriteLine();

            // Q2
            Container<int> numberContainer = new Container<int>();
            numberContainer.Add(100);
            Console.WriteLine("Q2 Container: " + numberContainer.Get());

            // Q3
            Pair<int, string> student = new Pair<int, string>(1, "Ahmed");
            Console.WriteLine("Q3 Pair: Key = " + student.Key + ", Value = " + student.Value);

            // Q4
            int first = 10;
            int second = 20;
            GenericMethods.Swap(ref first, ref second);
            Console.WriteLine("Q4 Swap: first = " + first + ", second = " + second);

            // Q5
            int max = GenericMethods.FindMax(15, 30);
            Console.WriteLine("Q5 FindMax: " + max);

            // Q6
            StudentRepository repository = new StudentRepository();
            repository.Add("Ali");
            repository.Add("Omar");
            Console.WriteLine("Q6 Repository: " + repository.Get(0));

            // Q7
            ValueTypeExample<int> valueExample = new ValueTypeExample<int>(50);
            Console.WriteLine("Q7 struct constraint: " + valueExample.Value);

            // Q8
            ReferenceTypeExample<string> referenceExample =
                new ReferenceTypeExample<string>("Hello");
            Console.WriteLine("Q8 class constraint: " + referenceExample.Value);

            // Q9
            Creator<Report> creator = new Creator<Report>();
            Report newReport = creator.Create();
            newReport.Print();

            // Q10
            Printer<Report> printer = new Printer<Report>();
            printer.PrintItem(new Report());

            // Q11
            AnimalBox<Dog> dogBox = new AnimalBox<Dog>();
            dogBox.MakeAnimalEat(new Dog());

            // Q12
            EmployeeManager<PrintableEmployee> manager =
                new EmployeeManager<PrintableEmployee>();
            manager.Work(new PrintableEmployee());

            // Q14
            SafeList<string> safeList = new SafeList<string>();
            safeList.Add("C#");
            safeList.Add("OOP");
            Console.WriteLine("Q14 Valid index: " + safeList.Get(0));
            Console.WriteLine("Q14 Invalid index: " + safeList.Get(10));

            // Q15
            IProducer<Dog> dogProducer = new DogProducer();
            IProducer<Animal> animalProducer = dogProducer;
            Animal producedAnimal = animalProducer.GetItem();
            producedAnimal.Eat();

            // Q16
            IConsumer<Animal> animalConsumer = new AnimalConsumer();
            IConsumer<Dog> dogConsumer = animalConsumer;
            dogConsumer.Consume(new Dog());

            // Q18
            new GenericCounter<int>();
            new GenericCounter<int>();
            new GenericCounter<string>();

            Console.WriteLine("Q18 int counter: " + GenericCounter<int>.Count);
            Console.WriteLine("Q18 string counter: " + GenericCounter<string>.Count);

            // Q19
            DogBox dogBox2 = new DogBox();
            dogBox2.MakeAnimalEat(new Dog());

            // Q20
            Cache<int, string> cache = new Cache<int, string>();

            cache.Add(1, "Hello Cache", TimeSpan.FromSeconds(5));
            Console.WriteLine("Q20 Contains key 1: " + cache.Contains(1));
            Console.WriteLine("Q20 Get key 1: " + cache.Get(1));

            cache.Remove(1);
            Console.WriteLine("Q20 Contains key 1 after Remove: " + cache.Contains(1));

            cache.Add(2, "This will expire", TimeSpan.FromSeconds(2));
            Console.WriteLine("Q20 Key 2 before expiration: " + cache.Get(2));

            Thread.Sleep(2500);

            Console.WriteLine("Q20 Key 2 after expiration: " + cache.Get(2));

            Console.WriteLine();
            Console.WriteLine("Program finished.");
            Console.ReadKey();
        }
    }
}
