namespace SwinAdventure
{
     public class Bag : Item, IHaveInventory
     {
          private Inventory _inventory = new Inventory();

          // constructor
          public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
          { }


          public Inventory Inventory
          {
               get
               {
                    return _inventory;
               }
          }

          public GameObject? Locate(string id)
          {
               if (AreYou(id))
               {
                    return this;
               }
               else if (Inventory.HasItem(id))
               {
                    return Inventory.Fetch(id);
               }
               else
               {
                    return null;
               }
          }

          public override string FullDescription
          {
               get { return "In the " + Name + " you can see:\n" + Inventory.ItemList; }
          }

          public bool IsEmpty
          {
               get
               {
                    if (Inventory.ItemList == "")
                    {
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }
     }
}