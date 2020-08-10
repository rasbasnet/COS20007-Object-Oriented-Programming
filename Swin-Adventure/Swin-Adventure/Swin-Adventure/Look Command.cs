using System;
namespace Swin_Adventure
{
    public class Look_Command : Command
    {
        public Look_Command() : base(new string[] {"look"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            return "";
        }

        public I_Have_Inventory FetchContainer(Player p, string cointerId)
        {
            return null;
        }

        public string LookAtIn(string thingId, I_Have_Inventory container)
        {
            return "";
        }

    }
}
