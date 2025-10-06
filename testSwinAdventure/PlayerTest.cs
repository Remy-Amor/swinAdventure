namespace TestSwinAdventure;
using SwinAdventure;
public class PlayerTest
{
  private Item _testItem1;
  private Item _testItem2;
  private Player _testPlayer;

  [SetUp]
  public void Setup()
  {
    _testPlayer = new Player("James", "an explorer");
    _testItem1 = new Item(["silver", "hat"], "Silver Hat", "A very shiny silver hat");
    _testItem2 = new Item(["light", "torch"], "Torch", "A Torch to light the path");
    _testPlayer.Inventory.Put(_testItem1);
    _testPlayer.Inventory.Put(_testItem2);
  }
  [Test]
  public void IdentifiablePlayer()
  {
    Assert.That(_testPlayer.AreYou("me") == true && _testPlayer.AreYou("inventory") == true);
  }

  [Test]
  public void LocatePlayer()
  {
    Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));
  }

  [Test]
  public void LocateItems()
  {
    Assert.That(_testPlayer.Locate("silver"), Is.EqualTo(_testItem1));
  }

  [Test]
  public void LocateNothing()
  {
    Assert.That(_testPlayer.Locate("Nonsense"), Is.EqualTo(null));
  }
  [Test]
  public void PlayerFullDescription()
  {
    Assert.That(_testPlayer.FullDescription, Is.EqualTo("You are James an explorer\nYou are carrying:\na Silver Hat (silver), a Torch (light)"));
  }

  [Test]
  // test Player writing
  public void PlayerSaveTest()
  {
    StreamWriter writer = new StreamWriter("TestPlayer.txt");
    try
    {
      _testPlayer.SaveTo(writer);
    }
    finally
    {
      writer.Close();
    }
    FileInfo fileInfo = new FileInfo("TestPlayer.txt");
    Assert.That(File.Exists("TestPlayer.txt") && fileInfo.Length > 0);
  }
    

}