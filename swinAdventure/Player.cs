
namespace SwinAdventure
{
     public class Player : GameObject, IHaveInventory
     {
          private Inventory _inventory;
          private Location _location;

          public Player(string name, string description) : base(["me", "inventory"], name, description)
          {
               _inventory = new Inventory();
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
                    return Location.Locate(id);
               }
          }

          public Inventory Inventory
          {
               get
               {
                    return _inventory;
               }
          }

          public Location Location
          {
               get
               {
                    return _location;
               }
               set
               {
                    _location = value;
               }
          }

          public override string FullDescription
          {
               get
               {
                    return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + _inventory.ItemList;
               }
          }

          // public override void SaveTo(StreamWriter writer)
          // {
          //      base.SaveTo(writer);
          //      // writer.WriteLine(Inventory.ItemList);
          // }

          public override void LoadFrom(StreamReader reader)
          {
               base.LoadFrom(reader);
               Console.WriteLine("Player Information");
               Console.WriteLine(Name);
               Console.WriteLine(ShortDescription);
               // as full description is three lines, must be skipped to get to the inventory item list.
               for (int i = 0; i < 1; i++)
               {
                    reader.ReadLine();
               }
               // line read is the inventory item list
               Console.WriteLine(reader.ReadLine());
          }
     }
}