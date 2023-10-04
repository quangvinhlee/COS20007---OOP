using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRoll
{
    public class Block
    {
        public Bitmap Image { get; set; }
        public int X { get;  set; }
        public int Y { get;  set; }
        public int MovingVelocity { get;  set; }
        public bool IsObstacle { get;  set; }
        public bool LongerBlock { get;  set; }

        public Block(int movingVelocity, bool isObstacle, bool longerBlock)
        {
            // Load the block image
            Image = new Bitmap("Block", "images/block.png");

            // Initialize x-position randomly within the screen width
            Random rand = new Random();
            X = rand.Next(0, Constants._scrWidth - Image.Width);

            Y = Constants._scrHeight;
            MovingVelocity = movingVelocity; // Velocity of moving upwards
            IsObstacle = false;
            LongerBlock = false;
        }
       
    }
}
