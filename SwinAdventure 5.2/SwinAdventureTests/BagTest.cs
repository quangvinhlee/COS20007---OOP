﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventureTests
{
    public class BagTest
    {
        private Bag _bagObject;
        private Bag _secondBagObject;
        private Item _shovel;
        private Item _sword;
        private Item _bow;

        [SetUp]
        public void SetUp()
        {
            _bagObject = new Bag(new[] { "bag" }, "a bag", "This is a bag");
            _secondBagObject = new Bag(new[] { "second bag" }, "a second bag", "This is a second bag");
            _shovel = new Item(new[] { "shovel" }, "a shovel", "This is a shovel");
            _sword = new Item(new[] { "sword" }, "a sword", "This is a Sword");
            _bow = new Item(new[] { "bow" }, "a bow", "This is a bow");
            _secondBagObject.Inventory.Put(_bow);
            _bagObject.Inventory.Put(_sword);
            _bagObject.Inventory.Put(_shovel);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.IsTrue(_bagObject.Inventory.HasItem("sword"));
            Assert.IsTrue(_bagObject.Inventory.HasItem("shovel"));

            Assert.AreEqual(_bagObject.Locate("sword"), _sword);
            Assert.AreEqual(_bagObject.Locate("shovel"), _shovel);
        }

        [Test]
        public void TestBagLocatesItself()
        {
            string[] bagIds = new string[] { "bag" };

            foreach (string id in bagIds)
            {
                Assert.AreEqual(_bagObject.Locate(id), _bagObject);
            }
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreEqual(null, _bagObject.Locate("bow"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual(_bagObject.FullDescription, "a bag, containing:\na sword (sword)\na shovel (shovel)\n");
        }

        [Test]
        public void TestBagInBag()
        {
            _bagObject.Inventory.Put(_secondBagObject);
            Assert.AreEqual(_bagObject.Locate("second bag"), _secondBagObject);
            Assert.AreEqual(_bagObject.Locate("sword"), _sword);
            Assert.AreEqual(null, _bagObject.Locate("bow"));

            Assert.AreEqual(_bagObject.FullDescription, "a bag, containing:\na sword (sword)\na shovel (shovel)\na second bag (second bag)\n");
            Assert.AreEqual(_secondBagObject.FullDescription, "a second bag, containing:\na bow (bow)\n");
        }
    }
}
