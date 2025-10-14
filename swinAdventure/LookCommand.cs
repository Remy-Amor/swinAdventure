namespace SwinAdventure
{
    public class LookCommand : Command
    {
          public LookCommand() : base(["look"])
          {
          }
        
        public override string Execute(Player p, string[] text)
          {
            // defaults to the container being the player
            IHaveInventory? container = p;

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
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
                else return "Error in look input";

            }
            return "I do not know how to look like that";
        }
        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            GameObject? obj = p.Locate(containerId);
            if (obj == null)
            {
                return null;
            }
            else
            {
                IHaveInventory? container = obj as IHaveInventory;
                return container;
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
