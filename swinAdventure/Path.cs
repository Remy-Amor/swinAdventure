namespace SwinAdventure
{
     public class Path : IdentifiableObject
     {
          private Location _endLocation;

          // first id is direction, second id is name if implemented in the future
          public Path(string[] ids, Location endLocation) : base(ids)
          {
               _endLocation = endLocation;
          }

          public Location EndLocation
          {
               get
               {
                    return _endLocation;
               }
               set
               {
                    _endLocation = value;
               }
          } 
     }
}