namespace SwinAdventure
{
     public class Location : GameObject, IHaveInventory {
          private Inventory _inventory;

          public Location(string[] ids, string name, string desc) : base(ids, name, desc)
          {
               _inventory = new Inventory();
          }

          public GameObject? Locate(string id)
          {
               if (AreYou(id))
               {
                    return this;
               }
               else
               {
                    return _inventory.Fetch(id);
               }
          }

          public override string FullDescription
          {
               get
               {
                    string nameDescription;
                    string inventoryDescription;

                    if (Name != null && Name != "")
                    {
                         nameDescription = Name;
                    }
                    else nameDescription = "an unknown location";

                    if (Inventory != null && Inventory.ItemList != null)
                    {
                         inventoryDescription = Inventory.ItemList;
                    }
                    else inventoryDescription = "there are no items at this location. ";
                    return "You are in " + nameDescription + ". " + base.FullDescription + "\n Here, you can see: \n" + inventoryDescription;
               }
          }

          public Inventory Inventory
          {
               get
               {
                    return _inventory;
               }
          }
          
     }
}