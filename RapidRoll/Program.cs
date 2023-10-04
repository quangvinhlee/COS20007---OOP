using System;
using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace RapidRoll
{
    public static class Constants
    {
        public const int _scrWidth = 550;
        public const int _scrHeight = 700;
        public const int _headerHeight = 55;
        public const int _fontSize = 25;
        public const int _offset = 10;
    }
    public class Program
    {
        private Player _player;
        private List<Block> _block;
        private GameUnity _gameUnity;

        public Program()
        {
            // Initialize SplashKit
            SplashKit.OpenWindow("Rapid Roll", Constants._scrWidth, Constants._scrHeight);

            // Create a new Player instance
            _player = new Player();
            _block = new List<Block>();
            _gameUnity = new GameUnity();
            // Load other game assets or initialize game state here
        }

            public void Run()
            {
                 List<Block> blocks = new List<Block>();

            while (!SplashKit.WindowCloseRequested("Rapid Roll"))
                {
                    SplashKit.ProcessEvents();
                    SplashKit.ClearScreen();
                // Create new blocks and add them to the list

                _gameUnity.Draw();
                _gameUnity.update();
                // Draw the player (ball) at its current position
                _gameUnity.Fall(_player);
                if (SplashKit.KeyDown(KeyCode.DKey))
                {
                    _gameUnity.MoveRight();
                }
                if (SplashKit.KeyDown(KeyCode.AKey))
                {
                    _gameUnity.MoveLeft();
                }
                if (_gameUnity.IsGameOver() && SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    _gameUnity.Restart();
                }
                SplashKit.Delay(16);
                    SplashKit.RefreshScreen();
                }

                // Clean up
                SplashKit.CloseWindow("Rapid Roll");
            }


            public static void Main()
            {
                Program game = new Program();
                game.Run();
            }
        }
    }
