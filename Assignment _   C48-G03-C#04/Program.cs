using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1

            double[] prices = { 25.5, 40.0, 33.75 };

            Console.WriteLine(prices[1]);

            Console.WriteLine();


            // Question 2

            int[,] shelfCopies =
            {
                {3,5},
                {1,4}
            };

            Console.WriteLine(shelfCopies[1, 0]);

            Console.WriteLine();


            // Question 3

            PrintWelcomeMessage();

            Console.WriteLine();


            // Question 4

            PrintBookTitle("Clean Code");

            Console.WriteLine();


            // Question 5

            int pages = 400;

            AddBonusPages(pages);

            Console.WriteLine(pages);

            Console.WriteLine();


            // Question 6

            double[] prices2 = { 25.5, 40.0 };

            ApplyDiscount(prices2);

            Console.WriteLine(prices2[0]);

            Console.WriteLine();


            // Question 7

            AddBonusPagesByRef(ref pages);

            Console.WriteLine(pages);

            Console.WriteLine();


            // Question 8

            ReplaceArray(ref prices2);

            Console.WriteLine(prices2.Length);

            Console.WriteLine();


            // Question 9

            double price;

            if (TryGetPrice("Clean Code", out price))
            {
                Console.WriteLine(price);
            }
            else
            {
                Console.WriteLine("Book not found");
            }

            Console.WriteLine();


            // Question 10

            PrintBookInfo("Clean Code");

            PrintBookInfo("Refactoring", 464);

            Console.WriteLine();


            // Question 11

            PrintBookInfo(pages: 500, title: "The Pragmatic Programmer");

            Console.WriteLine();


            // Question 12

            PrintAllTitles("Clean Code", "Refactoring", "The Pragmatic Programmer");
        }


        // Question 3

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Library");
        }


        // Question 4

        static void PrintBookTitle(string title)
        {
            Console.WriteLine("Book title: " + title);
        }


        // Question 5

        static void AddBonusPages(int pages)
        {
            pages = pages + 50;
        }


        // Question 6

        static void ApplyDiscount(double[] prices)
        {
            prices[0] = prices[0] - 5;
        }


        // Question 7

        static void AddBonusPagesByRef(ref int pages)
        {
            pages = pages + 50;
        }


        // Question 8

        static void ReplaceArray(ref double[] prices)
        {
            prices = new double[] { 10.0, 12.5, 15.0 };
        }


        // Question 9

        static bool TryGetPrice(string title, out double price)
        {
            if (title == "Clean Code")
            {
                price = 25.5;
                return true;
            }

            price = 0;
            return false;
        }


        // Question 10

        static void PrintBookInfo(string title, int pages = 300)
        {
            Console.WriteLine("Book: " + title + ", Pages: " + pages);
        }


        // Question 12

        static void PrintAllTitles(params string[] titles)
        {
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}