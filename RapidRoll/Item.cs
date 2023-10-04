using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRoll
{
    public enum ItemType
    {
        Shield,
        Live
    }
    public class Item
    {
        public Bitmap Image { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }
        public ItemType ItemType { get; private set; }

        public Item(ItemType item_type)
        {
            if (item_type == ItemType.Live)
            {
                // Load the live item image
                Image = new Bitmap("Live", "images/live.png");
            }
            else
            {
                // Load the shield item image
                Image = new Bitmap("Shield", "images/shield.png");
            }

            ItemType = item_type;
            X = 0; // Set an initial X position (adjust as needed)
            Y = 0; // Set an initial Y position (adjust as needed)
            Velocity = 0; // Set an initial velocity (adjust as needed)
        }
    }
}
