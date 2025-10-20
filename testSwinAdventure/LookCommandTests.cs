
using SwinAdventure;
using System;

namespace SwinAdventureTests
{
    public class LookCommandTests
    {
        private Item _testItem;
        private Player _testPlayer;
        private Bag _testMoneyBag;
        private LookCommand _testLookCommand;

        [SetUp]
        public void Setup()
        {
            _testLookCommand = new LookCommand();
            _testPlayer = new Player("HarryPotter", "a student");

            _testItem = new Item(new string[] { "gem", "Ruby" }, "A Ruby", "A bright Pink ruby");
            _testMoneyBag = new Bag(new string[] { "bag", "money" }, "Money Bag", "A bag that contains Valuables");

            _testPlayer.Inventory.Put(_testItem);
        }
        [Test]
        public void LookAtPlayer()
        {
               Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "inventory"]), Is.EqualTo("You are HarryPotter a student\nYou are carrying:\na A Ruby (gem)"));
        }
        [Test]
        public void LookAtItem()
        {
               Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem"]), Is.EqualTo("A bright Pink ruby"));
        }
        [Test]
        public void LookAtNothing()
        {
               _testPlayer.Inventory.RemoveItems([_testItem]);
               Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem"]), Is.EqualTo("I can't find the gem"));
        }
        [Test]
        public void LookAtItemInPlayer()
        {
          Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem", "in", "me"]), Is.EqualTo("A bright Pink ruby"));
        }

        [Test]
        public void LookAtItemInBag()
        {
            _testPlayer.Inventory.Put(_testMoneyBag);
            _testMoneyBag.Inventory.Put(_testItem);
            Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem", "in", "bag"]) == _testItem.FullDescription);
 
        }
        [Test]
        public void LookAtItemInNoBag()
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem", "in", "bag"]), Is.EqualTo("I cannot find the bag"));
        }
        [Test]
        public void LookAtNothingInBag()
        {
          _testPlayer.Inventory.Put(_testMoneyBag);
          Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "gem", "in", "bag"]), Is.EqualTo("I can't find the gem"));
        }
        [Test]
        public void InvalidLook()
        {
          Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "around"]), Is.EqualTo("You have: a A Ruby (gem)"));
          Assert.That(_testLookCommand.Execute(_testPlayer, ["look", "at", "Remy"]), Is.EqualTo("I can't find the Remy"));
        }

    }
}
