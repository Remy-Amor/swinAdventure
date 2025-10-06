// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace SwinAdventure
{
class MainClass
    {
        public static void Main(string[] args)
        {

            Player _testPlayer;
            _testPlayer = new Player("James", "an explorer");

            Item item1 = new Item([ "silver", "hat"], "Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(["light", "torch" ], "Torch", "A Torch to light the path");


            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            //Print the player Identifiers
          //   Console.WriteLine(_testPlayer.AreYou("me"));
          //   Console.WriteLine(_testPlayer.AreYou("inventory"));

          //   if(_testPlayer.Locate("torch") !=null){
          //       Console.WriteLine("The object torch exists");
          //       Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
          //   } else{
          //       Console.WriteLine("The object torch does not exist");
          //   }

            //write the PlayerObject to file
            StreamWriter writer = new StreamWriter("Player.txt");
            try {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }
            
            
            //read from the file
            StreamReader reader = new StreamReader("Player.txt");
            try {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {

                writer.Close();
            }
        }
    }

}
