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
            I_Have_Inventory _container;

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            } else
            {
                if (text[0].ToLower() != "look")
                    return "Error in look input.";

                if (text[1].ToLower() != "at")
                    return "What do you want to look at?";

                if (text.Length == 5)
                {
                    if (text[3].ToLower() != "in")
                        return "What do you want to look in?";

                    _container = FetchContainer(p, text[4]);
                } else
                {
                    _container = p;
                }

            }
            return _container == null ? $"I can't find the {text[4]}" : LookAtIn(text[2], _container);
        }

        private I_Have_Inventory FetchContainer(Player p, string cointerId)
        {
            return p.Locate(cointerId) as I_Have_Inventory;
        }

        private string LookAtIn(string thingId, I_Have_Inventory container)
        {
            var item = container.Locate(thingId);

            return item == null ? $"I can't find the {thingId}" : item.FullDescription;
        }

    }
}
