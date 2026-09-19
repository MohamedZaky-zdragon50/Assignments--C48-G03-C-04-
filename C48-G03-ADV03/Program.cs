using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
    }

    // Exercise 1: Student Grade Manager
   
    static void Exercise1()
    {
        Console.WriteLine("Exercise 1: Student Grade Manager");

        // List is suitable here because we need to store a group of grades
        // and perform operations such as sorting and removing items.
        List<int> grades = new List<int>
        {
            85, 92, 78, 95, 88, 70, 100, 65
        };

        Console.WriteLine("Grades:");
        Console.WriteLine(string.Join(", ", grades));

        Console.WriteLine("Count: " + grades.Count);
        Console.WriteLine("First grade: " + grades[0]);
        Console.WriteLine("Last grade: " + grades[grades.Count - 1]);

        grades.Sort();

        Console.WriteLine("\nSorted grades:");
        Console.WriteLine(string.Join(", ", grades));

        int firstAbove90 = grades.Find(grade => grade > 90);
        Console.WriteLine("\nFirst grade above 90: " + firstAbove90);

        List<int> failingGrades = grades.FindAll(grade => grade < 75);

        Console.WriteLine("Failing grades:");
        Console.WriteLine(string.Join(", ", failingGrades));

        grades.RemoveAll(grade => grade < 75);

        Console.WriteLine("Grades after removing failing grades:");
        Console.WriteLine(string.Join(", ", grades));

        bool has100 = grades.Contains(100);
        Console.WriteLine("Does the collection contain 100? " + has100);

        List<string> gradeText = grades.ConvertAll(grade => "Grade: " + grade);

        Console.WriteLine("\nGrade strings:");
        foreach (string item in gradeText)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    // Exercise 2: Leaderboard
    static void Exercise2()
    {
        Console.WriteLine("Exercise 2: Leaderboard");

        // SortedDictionary keeps the entries sorted by key.
        // Here the key is the player's score.
        SortedDictionary<int, string> leaderboard =
            new SortedDictionary<int, string>();

        leaderboard.Add(500, "Ahmed");
        leaderboard.Add(200, "Sara");
        leaderboard.Add(800, "Ali");
        leaderboard.Add(350, "Mona");

        Console.WriteLine("Leaderboard:");
        foreach (KeyValuePair<int, string> player in leaderboard)
        {
            Console.WriteLine(player.Key + " = " + player.Value);
        }

        int firstKey = 0;
        string firstValue = "";

        foreach (KeyValuePair<int, string> player in leaderboard)
        {
            firstKey = player.Key;
            firstValue = player.Value;
            break;
        }

        Console.WriteLine("\nFirst key: " + firstKey);
        Console.WriteLine("First value: " + firstValue);

        Console.WriteLine(
            "Does score 500 exist? " + leaderboard.ContainsKey(500)
        );

        if (leaderboard.TryGetValue(999, out string? player999))
        {
            Console.WriteLine("Player with score 999: " + player999);
        }
        else
        {
            Console.WriteLine("Player with score 999: Not Found");
        }

        leaderboard.Remove(200);

        Console.WriteLine("\nLeaderboard after removing score 200:");
        foreach (KeyValuePair<int, string> player in leaderboard)
        {
            Console.WriteLine(player.Key + " = " + player.Value);
        }

        Console.WriteLine();
    }

    // Exercise 3: Phone Book
    static void Exercise3()
    {
        Console.WriteLine("Exercise 3: Phone Book");

        Dictionary<string, string> phoneBook =
            new Dictionary<string, string>();

        phoneBook.Add("Ahmed", "01011111111");
        phoneBook.Add("Sara", "01022222222");
        phoneBook.Add("Ali", "01033333333");
        phoneBook.Add("Mona", "01044444444");

        phoneBook["Omar"] = "01055555555";

        Console.WriteLine("Omar's number: " + phoneBook["Omar"]);

        try
        {
            phoneBook.Add("Ahmed", "01099999999");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("\nTrying to add Ahmed again with Add():");
            Console.WriteLine("Error: " + ex.Message);
        }

        // TryAdd() is safer because it returns false instead of throwing
        // an exception when the key already exists.
        bool added = phoneBook.TryAdd("Ahmed", "01099999999");

        Console.WriteLine(
            "\nTrying to add Ahmed again with TryAdd(): " + added
        );

        string searchName = "Khaled";

        if (phoneBook.ContainsKey(searchName))
        {
            Console.WriteLine(searchName + " exists in the phone book.");
        }
        else
        {
            Console.WriteLine(searchName + " does not exist in the phone book.");
        }

        if (phoneBook.TryGetValue("Khaled", out string? phoneNumber))
        {
            Console.WriteLine("Khaled's number: " + phoneNumber);
        }
        else
        {
            Console.WriteLine("Khaled's number: Not Found");
        }

        Console.WriteLine("\nKeys:");
        foreach (string name in phoneBook.Keys)
        {
            Console.Write(name + " ");
        }

        Console.WriteLine("\nValues:");
        foreach (string number in phoneBook.Values)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine("\n");
    }

    // Exercise 4: Unique Email Validator
    
    static void Exercise4()
    {
        Console.WriteLine("Exercise 4: Unique Email Validator");

        // OrdinalIgnoreCase makes the HashSet treat upper/lowercase
        // versions of the same email as equal.
        HashSet<string> emails =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");

        Console.WriteLine("Email count: " + emails.Count);

        Console.WriteLine(
            "Why? Ahmed's two emails are considered the same, " +
            "and Sara's two emails are also considered the same " +
            "because the HashSet ignores letter case."
        );

        HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

        HashSet<int> unionSet = new HashSet<int>(setA);
        unionSet.UnionWith(setB);

        HashSet<int> intersectionSet = new HashSet<int>(setA);
        intersectionSet.IntersectWith(setB);

        HashSet<int> exceptSet = new HashSet<int>(setA);
        exceptSet.ExceptWith(setB);

        Console.WriteLine("\nUnionWith:");
        Console.WriteLine(string.Join(", ", unionSet));

        Console.WriteLine("IntersectWith:");
        Console.WriteLine(string.Join(", ", intersectionSet));

        Console.WriteLine("ExceptWith:");
        Console.WriteLine(string.Join(", ", exceptSet));

        HashSet<int> smallSet = new HashSet<int> { 1, 2 };

        Console.WriteLine(
            "\nIs {1, 2} a subset of Set A? " +
            smallSet.IsSubsetOf(setA)
        );

        Console.WriteLine();
    }

    // Exercise 5: Print Queue Simulator
    static void Exercise5()
    {
        Console.WriteLine("Exercise 5: Print Queue Simulator");

        Queue<string> printQueue = new Queue<string>();

        printQueue.Enqueue("Report.pdf");
        printQueue.Enqueue("Invoice.pdf");
        printQueue.Enqueue("Letter.docx");
        printQueue.Enqueue("Resume.pdf");
        printQueue.Enqueue("Photo.jpg");

        Console.WriteLine("Queue contents:");
        foreach (string document in printQueue)
        {
            Console.WriteLine(document);
        }

        Console.WriteLine("Count: " + printQueue.Count);

        Console.WriteLine(
            "\nNext document: " + printQueue.Peek()
        );

        Console.WriteLine("\nProcessing queue:");

        while (printQueue.Count > 0)
        {
            string document = printQueue.Dequeue();
            Console.WriteLine("Printing: " + document);
        }

        Console.WriteLine("Queue count after processing: " + printQueue.Count);

        if (printQueue.TryDequeue(out string? nextDocument))
        {
            Console.WriteLine("Document: " + nextDocument);
        }
        else
        {
            Console.WriteLine(
                "TryDequeue on an empty queue returns false and " +
                "does not throw an exception."
            );
        }

        Console.WriteLine();
    }

    // Exercise 6: Browser History (Undo)
    static void Exercise6()
    {
        Console.WriteLine("Exercise 6: Browser History (Undo)");

        // Stack follows LIFO:
        // Last In, First Out.
        Stack<string> history = new Stack<string>();

        history.Push("google.com");
        history.Push("github.com");
        history.Push("stackoverflow.com");
        history.Push("youtube.com");
        history.Push("claude.ai");

        Console.WriteLine("Current page: " + history.Peek());

        Console.WriteLine("\nGoing back:");

        for (int i = 0; i < 3; i++)
        {
            string page = history.Pop();
            Console.WriteLine("Left: " + page);
        }

        Console.WriteLine("\nCurrent page after going back: " + history.Peek());

        if (history.TryPop(out string? pageLeft))
        {
            Console.WriteLine("Left: " + pageLeft);
        }
        else
        {
            Console.WriteLine(
                "TryPop on an empty stack returns false " +
                "and does not throw an exception."
            );
        }

        // Empty the remaining stack so the final TryPop demonstrates
        // what happens with an actually empty Stack.
        while (history.Count > 0)
        {
            history.Pop();
        }

        if (history.TryPop(out string? emptyPage))
        {
            Console.WriteLine("Page: " + emptyPage);
        }
        else
        {
            Console.WriteLine(
                "TryPop on an empty stack returns false " +
                "and does not throw an exception."
            );
        }
    }
}
