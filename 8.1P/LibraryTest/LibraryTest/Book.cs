using System;
namespace LibraryTest
{
    public class Book : LibraryResource
    {
        private string _author, _isbn;
        public Book(string name, string author, string isbn) : base(name)
        {
            _author = author;
            _isbn = isbn;
        }

        public string Author { get => _author;}
        public string Isbn { get => _isbn;}
    }
}
