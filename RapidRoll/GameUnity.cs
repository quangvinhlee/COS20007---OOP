using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RapidRoll
{
    public class GameUnity
    {
        private Player _player;
        private List<Block> _blocks;
        private List<Item> _items;
        private int _blockWaitingTime = 0;
        private int _createBlockTime = 55;
        private int _blockMinFreq = 65;
        private int _blockMaxFreq = 80;
        private int _itemFreq = 4;
        private int _timeElapsed = 0;
        private int _obstacleFreq = 3;
        private int _longerFreq = 3;
        private int _blocksMovingVelocity = 3;
        public GameUnity()
        {
            _blocks = new List<Block>();
            _items = new List<Item>();
            _player = new Player();
        }
        // Move player to the left
        public void MoveLeft()
        {
            if (_player.X - _player._movingVelocity < 0) // If player is off the screen => set X = 0
            {
                _player.X = 0;
            }
            else
            {
                _player.X -= _player._movingVelocity; // Move left
            }
        }

        // Move player to the right
        public void MoveRight()
        {
            if (_player.X + _player.Image.Width + _player._movingVelocity > Constants._scrWidth) // If player is off the screen => set X = 0
            {
                _player.X = Constants._scrWidth - _player.Image.Width;
            }
            else
            {
                _player.X += _player._movingVelocity; // Move right
            }
        }


        public void Fall(Player player)
        {
            player.Y += player._fallingVelocity;
        }
        public void Spawn()
        {
            int index = _blocks.Count - 1;
            while (_blocks[index].IsObstacle) 
            {
                index--;
            }
            _player.X = _blocks[index].X;
            _player.Y = _blocks[index].Y - _player.Image.Height;
        }
        public void SetPlayerImage(Player player)
        {
            player.Image = new Bitmap("Ball", "images/ball.png");
        }
        public void ReduceLives()
        {
            if (_player.Lives.Count > 0)
            {
                // Remove the last (most recent) life from the list
                _player.Lives.RemoveAt(_player.Lives.Count - 1);
                Spawn();

            }
        }
        public void CheckBoundary(List<Block> Block, Player player)
        {
            if (player.Lives.Count > 0)
            {
                if (player.Y >= Constants._scrHeight)
                {
                    ReduceLives();
                }
            }
            else if (player.Y >= Constants._headerHeight + player.ThornImage.Height)
            {
                if (player.Inventories.Any(inventory => inventory.ItemType == ItemType.Shield))
                {
                    // Remove the shield effect
                    _player.Inventories.RemoveAll(inventory => inventory.ItemType == ItemType.Shield);
                    SetPlayerImage(_player);
                    // Spawn player on a random block
                    Spawn();
                }
                else
                {
                    ReduceLives();
                }
            }
        }
        public void StandOnBlock(List<Block> blocks, Player player)
        {
            foreach (var block in blocks)
            {
                int bottomBoundary = player.Y + player.Image.Height; // the bottom boundary of the ball
                int leftBoundary = block.X - player.Image.Width; // the leftmost boundary to fall
                int rightBoundary = block.X + block.Image.Width; // the rightmost boundary to fall

                // If the ball stands on the region
                if ((bottomBoundary >= block.Y && bottomBoundary <= block.Y + 2 * Constants._offset) &&
                    (player.X >= leftBoundary && player.X <= rightBoundary))
                {
                    // If it is a normal block
                    if (!block.IsObstacle)
                    {
                        player.Y = block.Y - player.Image.Height;
                    }
                    // If it is an obstacle but player has shield
                    else if (player.Inventories.Any(inventory => inventory.ItemType == ItemType.Shield))
                    {
                        // Remove the shield effect
                        player.Inventories.RemoveAll((inventory => inventory.ItemType == ItemType.Shield));
                        // Set player image here (use your actual method)
                        SetPlayerImage(player);
                        // spawn blocks, player (use your actual method)
                    }
                    // If it is an obstacle but player DOESN'T have shield
                    else
                    {
                        ReduceLives();
                    }
                }
            }
        }
        public void CreateObstacle(List<Block> blocks, int movingVelocity, bool isObstacle)
        {
            Block block = new Block(movingVelocity, isObstacle, false);
            if (isObstacle)
            {
                block.IsObstacle = true;
                block.Image = new Bitmap("Thorn", "images/thorn.png");
            }
            blocks.Add(block);
        }

        public void CreateLongerBlock(List<Block> blocks, int movingVelocity, bool longerBlock)
        {
            Block block = new Block(movingVelocity, false, longerBlock);
            if (longerBlock)
            {
                block.LongerBlock = true;
                block.Image = new Bitmap("LongerBlock", "images/longer_block.png");
            }
            blocks.Add(block);
        }
        public void MoveBlocks(List<Block> blocks)
        {
            foreach (Block block in blocks)
            {
                block.Y -= block.MovingVelocity;
            }
        }

        public void MoveItems(List<Item> items)
        {
            items.RemoveAll(item =>
            {
                if (item != null)
                {
                    item.Y -= item.Velocity;
                    return item.Y < Constants._headerHeight + new Bitmap("UpThorn", "images/up_thorn.png").Height;
                }
                return false;
            });
        }
        public void Scoring(List<Block> blocks, Player player)
        {
            blocks.RemoveAll(block =>
            {
                if (block.Y < Constants._headerHeight + new Bitmap("UpThorn", "images/up_thorn.png").Height)
                {
                    player.Score++;
                    return true;
                }
                return false;
            });
        }

        public void CollectItems(Player player, List<Item> items)
        {
            double CalculateDistance(double x1, double y1, double x2, double y2)
            {
                double deltaX = x2 - x1;
                double deltaY = y2 - y1;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }
            items.RemoveAll(item =>
            {
                if (item != null)
                {
                    double dist = CalculateDistance(player.X + player.Image.Width / 2, player.Y + player.Image.Height / 2, item.X + item.Image.Width / 2, item.Y + item.Image.Height / 2);

                    if (dist <= item.Image.Width / 2 + player.Image.Width / 2)
                    {
                        if (item.ItemType == ItemType.Live && player.Lives.Count < 6) // Maximum number of lives is 6
                        {
                            player.Lives.Add(new Live());
                        }
                        else if (item.ItemType == ItemType.Shield && !player.Inventories.Any(inventory => inventory.ItemType == ItemType.Shield))
                        {
                            player.Image = new Bitmap("MetalBall", "images/metal_ball.png");
                            player.Inventories.Add(new Item(ItemType.Shield));
                        }
                        return true;
                    }
                }
                return false;
            });
        }
        public void DrawPlayer(Player player)
        {
            if (player.Lives.Count > 0)
            {
                // Draw the ball
                SplashKit.DrawBitmap(player.Image, player.X, player.Y);

                // Draw player's lives in the header
                for (int idx = 0; idx < player.Lives.Count; idx++)
                {
                    double x_pos = Constants._scrWidth - (idx + 1) * (player.Lives[idx].Image.Width + Constants._offset) - idx * Constants._offset / 2;
                    SplashKit.DrawBitmap(player.Lives[idx].Image, x_pos, 0.5 * Constants._offset);
                }
            }
        }

        // ----------------------------------------------
        // Draw player's score
        public void DrawScore(Player player, Font font)
        {
            string scoreText = $"Score: {player.Score}";
           SplashKit.DrawText(scoreText, Color.Black, font, 0);
        }

        public void DrawBlocks(List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                SplashKit.DrawBitmap(block.Image, block.X, block.Y);
            }
        }

        public void DrawItems(List<Item> items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    SplashKit.DrawBitmap(item.Image, item.X, item.Y);
                }
            }
        }
        public void DrawTopBoundary()
        {
            // Draw the background color for the top boundary
            SplashKit.FillRectangle(SplashKit.RGBColor(255, 255, 204), 0, 0, Constants._scrWidth, Constants._headerHeight);

            // Draw the top thorn obstacle
            Bitmap obstacle = new Bitmap("UpThorn", "images/up_thorn.png");
            SplashKit.DrawBitmap(obstacle, 0, Constants._headerHeight);
        }

        public void DrawGameOver(Player player)
        {
            if (player.Lives.Count == 0)
            {
                // Load and draw the game over screen image
                Bitmap gameOverScreen = new Bitmap("GameOver", "images/game_over.jpg");
                SplashKit.DrawBitmap(gameOverScreen, 0, 0);
               
            }
        }
        public bool IsGameOver()
        {
            return _player.Lives.Count == 0;
        }
        public void GenerateBlocks()
        {
            // Create either an obstacle or a normal block
            Random rand = new Random();
            if (rand.Next(1, _obstacleFreq + 1) < 2 && !_blocks.Any(block => block.IsObstacle) && _blocks.Any())
            {
                CreateObstacle(_blocks, _blocksMovingVelocity, true); // Create an obstacle
            }
            else if (rand.Next(1, _longerFreq + 1) < 2 && !_blocks.Any(block => block.LongerBlock) && _blocks.Any())
            {
                CreateLongerBlock(_blocks, _blocksMovingVelocity, true); // Create a longer block
            }
            else
            {
                CreateObstacle(_blocks, _blocksMovingVelocity, false); // Create a normal block
            }

            // Reset block_waiting_time and randomly set the next create_block_time
            _blockWaitingTime = 0;
            Random createBlockTimeRandomizer = new Random();
            _createBlockTime = createBlockTimeRandomizer.Next(_blockMinFreq, _blockMaxFreq + 1);
        }
        public void GenerateItems()
        {
            // Put an item on the furthest block
            int idx = _blocks.Count - 1;
            if (!_blocks[idx].IsObstacle)
            {
                // Create a random item type
                Random rand = new Random();
                int num = rand.Next(0, 2);
                ItemType type = num == 1 ? ItemType.Shield : ItemType.Live;

                // Create an item and put it on the furthest block
                Item item = new Item(type);
                Random xRand = new Random();
                item.X = xRand.Next(_blocks[idx].X, _blocks[idx].X + _blocks[idx].Image.Width - item.Image.Width);
                item.Y = _blocks[idx].Y - item.Image.Height;
                item.Velocity = _blocksMovingVelocity;

                _items.Add(item);
            }
        }
        private void IncreaseDifficulty()
        {
            if (_timeElapsed % 1000 == 0 && _timeElapsed <= 3000)
            {
                // Increase player velocities
                _player._fallingVelocity += 2;
                _player._movingVelocity += 2;
                _blocksMovingVelocity += 1;

                // Make blocks move consistently with the new velocity
                foreach (var block in _blocks)
                {
                    block.MovingVelocity = _blocksMovingVelocity;
                }

                // Make items move consistently with the new velocity
                foreach (var item in _items)
                {
                    if (item != null)
                    {
                        item.Velocity = _blocksMovingVelocity;
                    }
                }

                _blockMinFreq -= 15;
                _blockMaxFreq -= 15;

                // Reduce the chances of generating items
                _itemFreq -= 1;
                _obstacleFreq = 4;
                _longerFreq = 4;
            }
        }
        public void Draw()
        {
            DrawTopBoundary();
            DrawPlayer(_player);
            DrawBlocks(_blocks);
            DrawItems(_items);
            DrawGameOver(_player);

        }
        public void update()
        {
            Random rand = new Random();
            _blockWaitingTime += 1;
            _timeElapsed += 1;
            if (_blockWaitingTime == _createBlockTime)
            {
                GenerateBlocks();
            }
            if (rand.Next(1000) < _itemFreq && _blocks.Count > 0)
            {
                GenerateItems();
            }
            MoveBlocks(_blocks);
            MoveItems(_items);
            StandOnBlock(_blocks, _player);
            CollectItems(_player, _items);
            CheckBoundary(_blocks, _player);
            Scoring(_blocks, _player);
            IncreaseDifficulty();
            MoveLeft();
            MoveRight();
            Fall(_player);
        }
        public void Restart()
        {
           
            // Reset all game parameters to their initial values
            _blocksMovingVelocity = 3;
            _blocks.Clear();
            _items.Clear();
            _blockWaitingTime = 0;
            _createBlockTime = 55;
            _blockMinFreq = 65;
            _blockMaxFreq = 80;
            _obstacleFreq = 5;
            _itemFreq = 4;
            _timeElapsed = 0;
            _longerFreq = 3;

            // Reinitialize the player
            _player = new Player();

            // Spawn the player at the initial position
            Spawn();
            
        }

    }

}
