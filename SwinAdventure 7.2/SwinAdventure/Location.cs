using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string name, string desc) : base(new string[] { "location" }, name, desc)
        {
            _inventory = new Inventory();
            
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                string locationDescription = base.FullDescription;
                string itemsDescription = "Items at this location:\n" + Inventory.ItemList;

                return $"\nYou are at {Name}\nRoom Description: {locationDescription}\n\n{itemsDescription}";
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }
}
