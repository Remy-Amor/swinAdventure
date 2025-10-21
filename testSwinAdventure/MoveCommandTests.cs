using SwinAdventure;
namespace TestSwinAdventure;

     public class MoveCommandTests
     {
          Player _testPlayer;

          Item item1;
          Item item2;
          Item item3;
          Item locationItem1;
          Item locationItem2;


          Bag bag;
          Location testLocation;

          Location fieldLocation;
          Location tavernLocation;
          Location deadEndLocation;
          SwinAdventure.Path pathNorthField;
          SwinAdventure.Path pathWestField;
          SwinAdventure.Path pathEastDungeon;
          SwinAdventure.Path pathSouthtavern;
          SwinAdventure.Path pathEastDeadEnd;


          // command setup
          MoveCommand cmd;


          [SetUp]
          public void SetUp()
          {
               _testPlayer = new Player("name", "something");
               item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
               item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");
               item3 = new Item(new string[] { "weapon", "sword" }, "A Sword", "A Sword to fight enemies");
               locationItem1 = new Item(["weapon", "bow"], "A bow", "A bow to shoot enemies with");
               locationItem2 = new Item(["food", "porridge"], "Porridge", "A hearty meal");
               bag = new Bag(["Player Bag", "bag"], "bag", "A handy bag");

               _testPlayer.Inventory.Put(bag);
               bag.Inventory.Put(item3);


               //add the items into the player's inventory
               _testPlayer.Inventory.Put(item1);
               _testPlayer.Inventory.Put(item2);

               // location 
               testLocation = new Location(["location", "dungeon"], "Dungeon", "A dark scary dungeon");
               testLocation.Inventory.Put(locationItem1);
               testLocation.Inventory.Put(locationItem2);
               _testPlayer.Location = testLocation;

               // MoveCommand testing 
               fieldLocation = new Location(["location", "field"], "A Field", "A beautiful field");
               tavernLocation = new Location(["location", "tavern"], "The Tavern", "A lively tavern");
               deadEndLocation = new Location(["location", "deadend"], "Dead end", "Uh oh, no paths out!");
               pathNorthField = new SwinAdventure.Path(["north"], fieldLocation);
               pathWestField = new SwinAdventure.Path(["west"], fieldLocation);
               pathEastDungeon = new SwinAdventure.Path(["east"], testLocation);
               pathSouthtavern = new SwinAdventure.Path(["south"], tavernLocation);
               pathEastDeadEnd = new SwinAdventure.Path(["east"], deadEndLocation);
               // assigning paths
               testLocation.AddPath(pathWestField);
               testLocation.AddPath(pathEastDeadEnd);
               tavernLocation.AddPath(pathNorthField);
               fieldLocation.AddPath(pathEastDungeon);
               fieldLocation.AddPath(pathSouthtavern);

               cmd = new MoveCommand();
          }

          [Test]
          public void InvalidMoveCommand()
          {
               Assert.That(cmd.Execute(_testPlayer, ["move"]), Is.EqualTo("Please enter a valid direction"));
               Assert.That(cmd.Execute(_testPlayer, ["move", "to", "Somewhere"]), Is.EqualTo("Please enter a valid direction"));
          }

          [Test]
          public void InvalidDirection()
          {
               Assert.That(cmd.Execute(_testPlayer, ["move", "north"]), Is.EqualTo("There are no paths that way!"));
          }

          [Test]
          public void ValidDirection()
          {
               Assert.That(cmd.Execute(_testPlayer, ["move", "west"]), Is.EqualTo("You are in A Field. A beautiful field\nHere, you can see: \n\nPaths to the east, south\n"));
          }
      }
