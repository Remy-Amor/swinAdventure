// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace SwinAdventure
{
class MainClass
    {
        public static void Main(string[] args)
        {

            // Player _testPlayer;
            // _testPlayer = new Player("James", "an explorer");

            // Item item1 = new Item(["silver", "hat"], "Silver Hat", "A very shiny silver hat");
            // Item item2 = new Item(["light", "torch"], "Torch", "A Torch to light the path");


            // _testPlayer.Inventory.Put(item1);
            // _testPlayer.Inventory.Put(item2);

            // //Print the player Identifiers
            // //   Console.WriteLine(_testPlayer.AreYou("me"));
            // //   Console.WriteLine(_testPlayer.AreYou("inventory"));

            // //   if(_testPlayer.Locate("torch") !=null){
            // //       Console.WriteLine("The object torch exists");
            // //       Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            // //   } else{
            // //       Console.WriteLine("The object torch does not exist");
            // //   }

            // //write the PlayerObject to file
            // StreamWriter writer = new StreamWriter("Player.txt");
            // try
            // {
            //     _testPlayer.SaveTo(writer);
            // }
            // finally
            // {
            //     writer.Close();
            // }


            // //read from the file
            // StreamReader reader = new StreamReader("Player.txt");
            // try
            // {
            //     _testPlayer.LoadFrom(reader);
            // }
            // finally
            // {

            //     writer.Close();
            // }


            // // Week 9 Task
            // List<IHaveInventory> myContainers = new List<IHaveInventory>();

            // Player _testPlayer = new Player("James", "an explorer");
            // myContainers.Add(_testPlayer);

            // Bag _testToolBag = new Bag(["bag", "tool"], "Tools Bag", "A bag that contains tools");
            // Item _testItem2 = new Item(["stew", "beef"], "A Beef Stew", "A hearty beef stew");

            // _testToolBag.Inventory.Put(_testItem2);
            // myContainers.Add(_testToolBag);

            // for (int i = 0; i < myContainers.Count; i++) {
            //     GameObject container = (GameObject)myContainers[i];
            //     Console.WriteLine(container.FullDescription);
            // }

            Player _testPlayer;
            Console.WriteLine("Player Name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Player Description: ");
            string playerDesc = Console.ReadLine();
            _testPlayer = new Player(playerName, playerDesc);

            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");
            Item item3 = new Item(new string[] { "weapon", "sword" }, "A Sword", "A Sword to fight enemies");
            Item locationItem1 = new Item(["weapon", "bow"], "A bow", "A bow to shoot enemies with");
            Item locationItem2 = new Item(["food", "porridge"], "Porridge", "A hearty meal");


            Bag bag = new Bag(["Player Bag", "bag"], "bag", "A handy bag");
            _testPlayer.Inventory.Put(bag);
            bag.Inventory.Put(item3);

             //add the items into the player's inventory

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            // location testing variables
            Location testLocation = new Location(["location", "dungeon"], "Dungeon", "A dark scary dungeon");
            testLocation.Inventory.Put(locationItem1);
            testLocation.Inventory.Put(locationItem2);
            _testPlayer.Location = testLocation;


            bool finished = false;
            LookCommand cmd = new LookCommand();
            while (!finished)
               {
                Console.WriteLine("What do you want to do?");
                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    finished = true;
                    break;
                }

                string[] split = command.Split(" ");

                Console.WriteLine(cmd.Execute(_testPlayer, split) + "\n");
               }
        }
    }

}
