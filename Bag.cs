namespace SwinAdventure
{
     public class Bag : Item
     {
          private Inventory _inventory = new Inventory();

          // constructor
          public Bag(string[] ids, string name, string desc) : base(ids, name, desc) { }
          
          public Inventory Inventory
          {
               get
               {
                    return _inventory;
               }
          }
     }
}