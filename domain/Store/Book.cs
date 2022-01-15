using System;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; } //Свойство только на чтение. Посмотреть, как делал свойства ITDVN

        public Book(int id,string title)
        {
            Id = id;
            Title = title;
        }

    }
}
