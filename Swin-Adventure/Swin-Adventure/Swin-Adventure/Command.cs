using System;
namespace Swin_Adventure
{
    public abstract class Command : IdentifiableObject
    {

        public Command(string[] ids) : base(ids)
        {

        }

        public abstract string Execute(Player p, string[] text);
    }

}
