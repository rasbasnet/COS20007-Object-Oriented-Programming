using System;
namespace LibraryTest
{
    public class Game : LibraryResource
    {
        private string _developer, _rating;
        public Game(string name, string developer, string rating) : base(name)
        {
            _developer = developer;
            _rating = rating;
        }

        public string Developer { get => _developer;}
        public string Rating { get => _rating; }
    }
}
