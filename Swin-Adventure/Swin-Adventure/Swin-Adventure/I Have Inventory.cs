using System;
namespace Swin_Adventure
{
    public interface I_Have_Inventory
    {
        GameObject Locate(string id);
        //Inventory members are by default public abstract!
        String Name { get; }
    }
}
