using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }
        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id)) return true;
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            Item takeItem = this.Fetch(id);
            _items.Remove(takeItem);
            return takeItem;
        }
        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id)) return itm;
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                string listItem = "";
                foreach (Item itm in _items)
                {
                    listItem = listItem + itm.ShortDescription + "\n";
                }
                return listItem;
            }
        }
    }
}
