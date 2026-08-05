using System;

namespace Assignment
{

    // Task 4
    // Declare Enum

    enum Genre
    {
        Fiction,
        NonFiction,
        Science
    }

    class Book
    {

        // Task 1
        // Private Field

        private string password = "secret";


        // Task 2
        // Internal Field

        internal int copiesInStock = 5;

        // Task 3
        // Public Field

        public string Title;

        // Task 4
        // Genre Property

        public Genre Genre { get; set; }

        // Helper method
        // (Used only because password is private)
        public void ShowPassword()
        {
            Console.WriteLine(password);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            // Task 1
            // Try to print private field from Main

            // Console.WriteLine(book.password);

            /*
             Answer:
             It does NOT compile.
             Because password is private, so it can only be accessed
             inside the Book class.
            */

            // Password can only be printed through a method inside Book.
            book.ShowPassword();



            // Task 2
            // Print internal field

            Console.WriteLine(book.copiesInStock);

            /*
             Answer:
             Yes, it compiles.
             Because Main and Book are in the same project,
             and internal members are accessible inside the same assembly.
            */


            // Task 3
            // Public Title Field

            book.Title = "Clean Code";

            Console.WriteLine(book.Title);


            // Task 4
            // Assign Genre and print it

            book.Genre = Genre.Science;

            Console.WriteLine(book.Genre);



            // Task 5
            // Print enum integer values

            Console.WriteLine((int)Genre.Fiction);

            Console.WriteLine((int)Genre.NonFiction);

            Console.WriteLine((int)Genre.Science);


            // Task 6

            int genreNumber = 1;

            Genre genreFromNumber = (Genre)genreNumber;

            Console.WriteLine(genreFromNumber);

            // Task 7

            Genre genre = Genre.Fiction;

            string genreString = genre.ToString();

            Console.WriteLine(genreString);


            // Task 8

            string genreText = "Science";

            Genre parsedGenre =
                (Genre)Enum.Parse(typeof(Genre), genreText);

            Console.WriteLine(parsedGenre);


            // Task 9

            string invalidGenre = "Mystery";

            bool success = Enum.TryParse(invalidGenre, out Genre result);

            if (success)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Unknown genre");
            }
        }
    }
}