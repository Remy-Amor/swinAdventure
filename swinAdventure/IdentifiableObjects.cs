namespace SwinAdventure
{
     public class IdentifiableObject
     {
          private List<string> _identifiers = new List<string>();

          // setter
          public IdentifiableObject(string[] idents)
          {
               foreach (string str in idents)
               {
                    this._identifiers.Add(str.ToLower());
               }
          }

          //checks if object has a certain identifier
          public bool AreYou(string identifier)
          {
               if (this._identifiers.Contains(identifier.ToLower()))
               {
                    return true;
               }
               else
               {
                    return false;
               }
          }

          // returns first identifier, if any exists
          public string FirstId()
          {
               if (this._identifiers.Count == 0)
               {
                    return "";
               }
               else
               {
                    return this._identifiers[0];
               }
          }

          //appends identifier to _identifiers
          public void AddIdentifier(string identifier)
          {
               this._identifiers.Add(identifier.ToLower());
          }

          // removes a certain identifier from _identifiers
          public void RemoveIdentifier(string identifier)
          {
               this._identifiers.Remove(identifier.ToLower());
          }

          public void PrivilegeEscalation(string pin)
          {
               if (pin == "4423")
               {
                    this._identifiers[0] = "105914423";
               }
          }

     }



}