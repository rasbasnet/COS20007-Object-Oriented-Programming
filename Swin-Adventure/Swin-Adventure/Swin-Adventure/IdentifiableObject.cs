using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        //constuctor
        public IdentifiableObject(string[] idents)
        {
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }

        //check if passed in id is in _identifiers
        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            return false;
        }

        //returns first identifier in _identifiers
        public string FirstId()
        {
            return _identifiers[0];
        }

        //adds identifier in _identifiers
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }

}
