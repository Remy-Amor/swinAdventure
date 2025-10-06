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
               Assert.That(_testToolBag.Locate("Bag"), Is.EqualTo(_testToolBag));
          }

          [Test]
          public void BagLocatesNothing()
          {
               Assert.That(_testFoodBag.Locate("Hammer"), Is.EqualTo(null));
          }

          [Test]
          public void BagFullDescription()
          {
               _testFoodBag.Inventory.Put(_testItem2);
               Assert.That(_testFoodBag.FullDescription, Is.EqualTo("In the Food bag you can see:\na apple (apple)"));
          }

          [Test]
          public void BaginBag()
          {
               // can locate bag inside bag
               _testFoodBag.Inventory.Put(_testToolBag);
               Assert.That(_testFoodBag.Locate("Tool Bag"), Is.EqualTo(_testToolBag));
               // can locate other items in bag
               _testFoodBag.Inventory.Put(_testItem1);
               Assert.That(_testFoodBag.Locate("Hammer"), Is.EqualTo(_testItem1));

               // can not locate items inside nested bag
               _testToolBag.Inventory.Put(_testItem2);
               Assert.That(_testFoodBag.Locate("Apple"), Is.EqualTo(null));

          }

          [Test]
          public void BagPrivilegedItem()
          {
               _testFoodBag.Inventory.Put(_testToolBag);
               _testItem1.PrivilegeEscalation("4423");
               _testToolBag.Inventory.Put(_testItem1);
               Assert.That(_testFoodBag.Locate("105914423"), Is.EqualTo(null));
          }


     }
}