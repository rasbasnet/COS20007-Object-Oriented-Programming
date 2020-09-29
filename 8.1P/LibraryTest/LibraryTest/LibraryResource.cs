using System;
namespace LibraryTest
{
    public abstract class LibraryResource
    {
        private String _name;
        private bool _onloan;
        public LibraryResource(string name)
        {
            _name = name;
            _onloan = false;
        }

        public string Name { get => _name; }
        public bool OnLoan { get => _onloan; set => _onloan = value; }
    }
}
