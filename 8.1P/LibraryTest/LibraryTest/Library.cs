using System;
using System.Collections.Generic;
namespace LibraryTest
{
    public class Library
    {
        private List<LibraryResource> _resources;
        private String _name;
        public Library(string name)
        {
            _name = name;
            _resources = new List<LibraryResource>();
        }

        public string Name {get => _name;}

        public void AddResource(LibraryResource resource)
        {
            _resources.Add(resource);
        }

        public bool HasResource(string name)
        {
            foreach (LibraryResource resource in _resources)
            {
                if (resource.Name == name)
                {
                    return resource.OnLoan ? false : true;
                }
            }
            return false;
        }
    }
}
