namespace SwinAdventure
{
     public class MoveCommand : Command
     {
          private string[] validDirections = new string[] { "north", "east", "south", "west"};
          public MoveCommand() : base(["move"])
          {

          }

          public override string Execute(Player player, string[] text)
          {
               if (text.Length == 2)
               {
                    if (validDirections.Contains(text[1]))
                    {
                         string direction = text[1];
                         Path? path = player.Location.LocatePath(direction);
                         if (path != null)
                         {
                              player.Location = path.EndLocation;
                              return player.Location.FullDescription;
                         }
                         else
                         {
                              return "There are no paths that way!";
                         }
                    }
                    else
                    {
                         return "Please enter a valid direction";
                    }
               }
               else
               {
                    return "Please enter a valid direction";
               }
          }
          
     }
}