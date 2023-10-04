using SplashKitSDK;

namespace RapidRoll
{
    public class Player
    {
        public Bitmap Image { get;  set; }
        public Bitmap ThornImage { get;  set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int _movingVelocity;
        public int _fallingVelocity;
        private List<Live> _lives;
        public List<Item> Inventories { get;  set; }
        public int Score { get; set; }
        public Player()
        {
            Image = new Bitmap("Ball", "images/ball.png");
            ThornImage = new Bitmap("Ball", "images/up_thorn.png");
            _movingVelocity = 4;
            _fallingVelocity = 5;
            Random rand = new Random();
            X = rand.Next(0, Constants._scrWidth - Image.Width);
            Y = Constants._headerHeight + ThornImage.Height;
            _lives = new List<Live>();
            for (int i = 0; i < 3; i++)
            {
                _lives.Add(new Live());
            }
            Inventories = new List<Item>();
            Score = 0;
        }
        public List<Live> Lives { get { return _lives; } }
        
    }
}
