namespace SwinAdventure
{
    public class LookCommand : Command
    {
        private string[] validDirections = new string[] { "north", "east", "south", "west"};

          public LookCommand() : base(["look"])
          {
          }
        
        public override string Execute(Player p, string[] text)
          {
            // defaults to the container being the player
            IHaveInventory? container = p;

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[1] == "at")
                    {
                        if (text.Length == 5)
                        {
                            if (text[3] == "in")
                            {
                                //call the FetchContainer with the p and text[4] to update the container
                                container = FetchContainer(p, text[4]);
                                if (container == null)
                                {
                                    return "I cannot find the " + text[4];
                                }
                            }
                            else return "What do you want to look in?";
                        }
                        //call the LookAtIn with (text[2], container);
                        return LookAtIn(text[2], container);
                    }
                    else return "What do you want to look at?";

            }
            else if (text.Length == 2)
            {
                if (text[1] == "around")
                    {
                        if (p.Inventory.ItemList != null)
                        {
                            return ("You have: " + p.Inventory.ItemList);
                        }
                        else return ("You have nothing.");
                    } else if (validDirections.Contains(text[1]))
                    {
                    if (p.Location.LocatePath(text[1]) != null)
                    {
                        return "To the " + text[1] + " you see: " + p.Location.LocatePath(text[1]).EndLocation.Name;
                    }
                    else return "There is no path to the " + text[1];
                    }
                    else return "What do you want to look at?";
            }
               else return p.Location.FullDescription;
        }
        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            GameObject? obj = p.Locate(containerId);
            if (obj != null)
            {
                IHaveInventory? container = obj as IHaveInventory;
                return container;
            }
            else if (p.Location != null)
            {
                obj = p.Location.Locate(containerId);
                if (obj == null)
                {
                    return null;
                }
                //              //effectively the same as the lines above
                else return obj as IHaveInventory;
            }
            else
               {
                return null;
               }
        }
        private string? LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? itm = container.Locate(thingId);
               if (itm == null)
               {
                    return "I can't find the " + thingId;
               }
               return itm.FullDescription;
        }
    }
}
