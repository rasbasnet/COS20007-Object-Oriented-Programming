using System;
namespace Swin_Adventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description, _name;
        
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }


        public string ShortDescription
        {
            get
            {
                return $"a {this.FirstId()} ({this.Name})";
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

        public string Name { get => _name;}
    }
}
