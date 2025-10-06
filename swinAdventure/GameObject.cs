namespace SwinAdventure
{
     public abstract class GameObject : IdentifiableObject
     {
          private string? _description;
          private string? _name;

          public GameObject(string[] idents, string name, string desc) : base(idents)
          {
               _description = desc;
               _name = name;
          }

          public string? Name
          {
               get
               {
                    return _name;
               }
          }

          public virtual string? FullDescription
          {
               get
               {
                    return _description;
               }
          }

          public string ShortDescription
          {
               get
               {
                    return "a " + this._name + " (" + FirstId() + ")";
               }
          }

          public virtual void SaveTo(StreamWriter writer)
          {
               writer.WriteLine(Name);
               writer.WriteLine(FullDescription);
          }

          public virtual void LoadFrom(StreamReader reader)
          {
               _name = reader.ReadLine();
               _description = reader.ReadLine();
          }
     }
}