using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRoll
{
    public class Live
    {
        public Bitmap Image { get; private set; }

        public Live()
        {
            // Load the live image
            Image = new Bitmap("Live", "images/live.png");
        }
    }
}
