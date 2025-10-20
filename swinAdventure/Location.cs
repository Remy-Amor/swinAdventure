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
                    return "Placeholder";
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