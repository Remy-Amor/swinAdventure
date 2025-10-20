namespace SwinAdventure
{
     public class Location : GameObject, IHaveInventory {
          private Inventory _inventory;
          private List<Path> _paths;

          public Location(string[] ids, string name, string desc) : base(ids, name, desc)
          {
               _inventory = new Inventory();
               _paths = new List<Path>();
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
                    return "You are in " + nameDescription + ". " + base.FullDescription + "\n Here, you can see: \n" + inventoryDescription
                              + "\n" + this.DescribePaths();
               }
          }

          public Inventory Inventory
          {
               get
               {
                    return _inventory;
               }
          }
          
          // for week 11 task 2
          public List<Path> Paths
          {
               get
               {
                    return _paths;
               }
          }

          public void AddPath(Path path)
          {
               _paths.Add(path);
          }

          public Path? LocatePath(string direction)
          {
               foreach (Path path in _paths)
               {
                    if (path.FirstId() == direction)
                    {
                         return path;
                    }
               }
               return null;
          }

          public string DescribePaths()
          {
               List<string> pathDescription;
               if (_paths != null)
               {
                    pathDescription = new List<string>(["You see paths to the "]);
                    foreach (Path path in _paths)
                    {
                         pathDescription.Add(path.FirstId());
                    }
                    return string.Join(", ", pathDescription);
               }
               else
               {
                    return "There are no paths out of this location";
               }
          }
     }
}