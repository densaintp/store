using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; }

        public string Isbn { get; }
        public string Author { get; }
        public string Title { get; } //Свойство только на чтение. Посмотреть, как делал свойства ITDVN
        public string Description { get; }

        public decimal Price { get; }

        public Book(int id, string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            Description = description;
            Price = price;
        }

        internal static bool IsIsbn(string s) // метод доступен на уровне класса(доступен всем классам внутри проекта Store)
        {
            if (s == null)
                return false;
            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper(); //Все это методы класса стринг!

            return Regex.IsMatch(s, @"ISBN\d{10}(\d{3})?$"); //$ - после последней цифры точно должен быть конец строки
        }


    }
}
