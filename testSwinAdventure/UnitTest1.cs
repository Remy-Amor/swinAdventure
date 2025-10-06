namespace TestSwinAdventure;

using SwinAdventure;

public class Tests
{
    //instantiates a test object for use in the tests
    public IdentifiableObject testObject = new IdentifiableObject(["Remy", "Amor", "105914423"]);
    private Inventory testInventory;
    private Item invItem1;
    private Item invItem2;

    private Item testItem;
    [SetUp]
    public void Setup()
    {

        // inventory setup
        testInventory = new Inventory();
        invItem1 = new Item(["105914423"], "invItem1", "long description");
        invItem2 = new Item(["100100"], "invItem2", "long description");
        testInventory.Put(invItem1);
        testInventory.Put(invItem2);


        // item setup
        testItem = new Item(["101101101", "Remy", "AMOR"], "Toothbrush", "Brushes Teeth");
    }


    // TESTING IDENTIFIABLE OBJECTS
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestAreYou()
    {
        Assert.That(testObject.AreYou("amor") == true);
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.That(testObject.AreYou("1O5914423") == false);
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.That(testObject.AreYou("AmOr") == true);
    }

    [Test]
    public void TestFirstID()
    {
        Assert.That(testObject.FirstId() == "remy");
    }

    [Test]
    public void TestFirstIDWithNoIDs()
    {
        IdentifiableObject noIdentsObject = new IdentifiableObject([]);
        Assert.That(noIdentsObject.FirstId() == "");
    }

    [Test]
    public void TestAddID()
    {
        testObject.AddIdentifier("Student");
        Assert.That(testObject.AreYou("student") == true);
    }

    [Test]
    public void TestPrivilegeEscalation()
    {
        testObject.PrivilegeEscalation("4423");
        Assert.That(testObject.FirstId() == "105914423");
    }
    // verification task
    [Test]
    public void TestRemoveIdentifier()
    {
        IdentifiableObject testObjectRemove = new IdentifiableObject(["Dobby"]);
        testObjectRemove.RemoveIdentifier("dobby");
        Assert.That(testObjectRemove.AreYou("DOBBY").Equals(false));
    }



    // TESTING ITEMS 

    [Test]
    public void TestIdentifiable()
    {
        Assert.That(testItem.AreYou("remy") == true);
    }

    [Test]
    public void TestShortDescription()
    {
        Assert.That(testItem.ShortDescription, Is.EqualTo("a Toothbrush (101101101)"));
    }

    [Test]
    public void TestFullDescription()
    {
        Assert.That(testItem.FullDescription == "Brushes Teeth");
    }

    [Test]
    public void TestItemPrivilegeEscalation()
    {
        testItem.PrivilegeEscalation("4423");
        Assert.That(testItem.FirstId() == "105914423");
    }


    // for Inventory 


    [Test]
    public void TestFindItem()
    {
        Assert.That(testInventory.HasItem("105914423"), Is.EqualTo(true));
    }

    [Test]
    public void TestNoItemFind()
    {
        Assert.That(testInventory.HasItem("notanid"), Is.EqualTo(false));
    }

    [Test]
    public void TestFetchItem()
    {
        Assert.That(testInventory.Fetch("105914423"), Is.TypeOf<Item>());
        Assert.That(testInventory.HasItem("105914423"), Is.EqualTo(true));
    }

    [Test]
    public void TestTakeItem()
    {
        Assert.That(testInventory.Take("105914423"), Is.TypeOf<Item>());
        Assert.That(testInventory.HasItem("105914423"), Is.EqualTo(false));
    }

    [Test]
    public void TestItemList()
    {
        Assert.That(testInventory.ItemList, Is.EqualTo("a invItem1 (105914423), a invItem2 (100100)"));
    }

    // verification task test
    [Test]
    public void TestPutUniqueItem()
    {
        Item nonUniqueItem = new Item(["105914423"], "Remy", "description");
        testInventory.Put_UniqueItem(nonUniqueItem);
        Assert.That(testInventory.ItemList, Is.EqualTo("a invItem1 (105914423), a invItem2 (100100)"));
    }
}
