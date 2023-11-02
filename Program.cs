using ClassLibrary;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Library library = new Library();

            int userInput = -1;

            while (userInput != 0)
            {
                Console.Clear();
                Console.WriteLine("Приветствуем в библиотеке!");
                Console.WriteLine("1. Взять: ");
                Console.WriteLine("2. Добавить: ");
                Console.WriteLine("3. Удалить: ");
                Console.WriteLine("4. Показать библиотеку: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        library.BorrowMenu();
                        break;

                    case "2":
                        library.AddItemMenu();
                        break;

                    case "3":
                        library.RemoveItem();
                        break;

                    case "4":
                        library.ShowItems();
                        break;

                    case "5":
                        userInput = 0;
                        break;
                }
            }


            static void ShowBooks(List<Book> books)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"Книга {book.Title}, {book.Author}, {book.IsLoanable}");
                }

                Console.WriteLine("Какую хотите взять?");
                string userInput = Console.ReadLine();

                if (books.Where(x => x.Title == userInput).Where(x => x.IsLoanable).Any())
                {
                    Console.WriteLine("Успешно");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Книга {userInput} занята");
                }
            }
        }
    }
}