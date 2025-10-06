namespace TestSwinAdventure
{

     using SwinAdventure;

     public class BagTests
     {
          private Bag _testToolBag;
          private Bag _testFoodBag;
          private Item _testItem1;
          private Item _testItem2;

          [SetUp]
          public void Setup()
          {
               _testToolBag = new Bag(["Tool Bag", "Bag"], "Tool Bag", "A tool bag");
               _testFoodBag = new Bag(["Food bag", "another bag"], "Food bag", "Description for food bag");
               _testItem1 = new Item(["Hammer", "tool"], "hammer", "This is a hammer");
               _testItem2 = new Item(["Apple", "Food"], "apple", "This is an apple");
          }

          [Test]
          public void BagLocatesItems()
          {
               _testToolBag.Inventory.Put(_testItem1);
               Assert.That(_testToolBag.Locate("Hammer"), Is.EqualTo(_testItem1));
          }

          [Test]
          public void BagLocatesItself()
          {

          }

          [Test]
          public void BagLocatesNothing()
          {

          }

          [Test]
          public void BagFullDescription()
          {

          }

          [Test]
          public void BaginBag()
          {

          }

          [Test]
          public void BagPrivilegedItem()
          {

          }


     }
}