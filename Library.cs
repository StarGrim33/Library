using ClassLibrary;

namespace Library
{
    internal class Library
    {
        private List<ILoanable> _books = new List<ILoanable>();
        private List<ILoanable> _dvds = new List<ILoanable>();
        private List<ILoanable> _cdds = new List<ILoanable>();

        public Library()
        {
            _books = BookInitialize();
        }

        public void BorrowMenu()
        {
           

            int userInput = -1;

            while (userInput != 0)
            {
                Console.WriteLine("Что бы вы хотели взять?: ");
                Console.WriteLine("1. Книгу");
                Console.WriteLine("2. DVD");
                Console.WriteLine("3. CD");
                Console.WriteLine("0. Выйти");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BorrowItem(_books);
                        return;

                    case "2":
                        BorrowItem(_dvds);
                        return;

                    case "3":
                        BorrowItem(_cdds);
                        return;

                    case "4":
                        userInput = 0;
                        return;
                }
            }
        }

        private void BorrowItem(List<ILoanable> printables)
        {
            Console.WriteLine("Список доступных книг:");

            foreach (var item in printables)
            {
                if (item.IsLoanable)
                {
                    IPrintable printable = (IPrintable)item;
                    printable.Print();
                }
            }

            Console.WriteLine("Введите ID книги, которую вы хотите взять (или 0 для отмены):");
            int idToBorrow = int.Parse(Console.ReadLine());

            if (idToBorrow == 0)
            {
                Console.WriteLine("Операция отменена.");
                return;
            }

            Console.WriteLine("Введите ваше имя для бронирования:");
            string borrowerName = Console.ReadLine();

            foreach (var item in printables)
            {
                if (item.IsLoanable && item is Book book && book.ID == idToBorrow)
                {
                    
                    IPrintable printable = (IPrintable)book;
                    printable.Print();
                    book.Borrow(idToBorrow, borrowerName);
                    return;
                }
            }

            Console.WriteLine("Книга с указанным ID не найдена или недоступна для выдачи.");
        }

        public void AddItemMenu()
        {
            Console.WriteLine("Что вы хотите добавить? ");
            Console.WriteLine("1. Книги");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. CD");

            int userInput = -1;

            while (userInput != 0)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        break;

                    case "4":
                        userInput = 0;
                        break;
                }
            }
        }

        public void RemoveItem()
        {

        }

        public void ShowItems()
        {

        }

        private List<ILoanable> BookInitialize()
        {
            List<ILoanable> list = new List<ILoanable>() {
            new Book(1, "Эрих Мария Ремарк", "Черный обелиск", 11221),
        new Book(2, "Эрих Мария Ремарк", "На Западном фронте без перемен", 15622)
            };
            return list;
        }
    }
}
