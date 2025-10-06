namespace SwinAdventure
{
     public class Inventory
     {
          private List<Item> _items;
          public Inventory()
          {
               _items = new List<Item>();
          }

          public bool HasItem(string id)
          {
               foreach (Item i in _items)
               {
                    if (i.AreYou(id))
                    {
                         return true;
                    }
               }
               return false;
          }

          public void Put(Item itm)
          {
               try
               {
                    _items.Add(itm);
               }
               catch (Exception e)
               {
                    Console.WriteLine(e.Message);
               }
          }

          public Item? Take(string id)
          {
               foreach (Item i in _items)
               {
                    if (i.AreYou(id))
                    {
                         _items.Remove(i);
                         return i;
                    }
               }
               // return null if no matches found
               return null;
          }

          public Item? Fetch(string id)
          {
               foreach (Item i in _items)
               {
                    if (i.AreYou(id))
                    {
                         return i;
                    }
               }
               // null if no matches found
               return null;
          }

          public string ItemList
          {
               get
               {
                    List<string> itemList = new List<string>();
                    foreach (Item i in _items)
                    {
                         itemList.Add(i.ShortDescription);
                    }
                    return string.Join(", ", itemList);
               }
          }

          //verification tasks

          public void Put_UniqueItem(Item itm)
          {
               if (HasItem(itm.FirstId()))
               {
                    return;
               }
               else
               {
                    Put(itm);
               }
          }

          public void RemoveItems(List<Item> itmList)
          {
               foreach (Item item in itmList)
               {
                    if (item.FirstId() == ("105914423"))
                    {
                         _items.RemoveAt(0);
                         _items.RemoveAt(_items.Count() - 1);
                    }
                    _items.Remove(item);
               }
          }


     }
}