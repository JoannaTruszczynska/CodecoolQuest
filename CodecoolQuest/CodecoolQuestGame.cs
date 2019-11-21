using System;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Codecool.Quest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CodecoolQuestGame : Game
    {
        public static CodecoolQuestGame GameSingleton;

        public SpriteBatch SpriteBatch;

        public GameMap _map;
        private TimeSpan _lastMoveTime;

        public const double MoveInterval = 0.1;

        public CodecoolQuestGame()
        {
            GameSingleton = this;

            using var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.AllowUserResizing = true;
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            _lastMoveTime = TimeSpan.Zero;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            GUI.Load();
            Tiles.Load();

            _map = MapLoader.LoadMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            var neighbourCell = _map.Player.Cell.GetNeighbor(0, 0);

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                // Exit the game
                Exit();
                return;
            }

            var deltaTime = gameTime.TotalGameTime - _lastMoveTime;

            if (deltaTime.TotalSeconds < MoveInterval)
                return;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // Move left
                CheckNextCell(-1, 0);
                neighbourCell = _map.Player.Cell.GetNeighbor(-1, 0);

                if (neighbourCell.CanIMoveHere)
                {
                    _map.Player.Move(-1, 0);
                }

                if (neighbourCell.CanIFight)
                {
                    neighbourCell.Actor.TakeDamage(5);

                    if (neighbourCell.Actor.Health > 0)
                    {
                        _map.Player.TakeDamage(2);
                    }

                    else
                    {
                        neighbourCell.Actor = null;
                        neighbourCell.CanIFight = false;
                        neighbourCell.CanIMoveHere = true;
                        neighbourCell.CellType = CellType.Floor;
                    }
                }


                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                // Move right
                CheckNextCell(1, 0);
                neighbourCell = _map.Player.Cell.GetNeighbor(1, 0);

                if (neighbourCell.CanIMoveHere)
                {
                    _map.Player.Move(1, 0);
                }
                if (neighbourCell.CanIFight)
                {
                    neighbourCell.Actor.TakeDamage(5);

                    if (neighbourCell.Actor.Health > 0)
                    {
                        _map.Player.TakeDamage(2);
                    }

                    else
                    {
                        neighbourCell.Actor = null;
                        neighbourCell.CanIFight = false;
                        neighbourCell.CanIMoveHere = true;
                        neighbourCell.CellType = CellType.Floor;
                    }
                }

                _lastMoveTime = gameTime.TotalGameTime;

            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                // Move up
                CheckNextCell(0, -1);
                neighbourCell = _map.Player.Cell.GetNeighbor(0, -1);

                if (neighbourCell.CanIMoveHere)
                {
                    _map.Player.Move(0, -1);
                }
                if (neighbourCell.CanIFight)
                {
                    neighbourCell.Actor.TakeDamage(5);

                    if (neighbourCell.Actor.Health > 0)
                    {
                        _map.Player.TakeDamage(2);
                    }

                    else
                    {
                        neighbourCell.Actor = null;
                        neighbourCell.CanIFight = false;
                        neighbourCell.CanIMoveHere = true;
                        neighbourCell.CellType = CellType.Floor;
                    }
                }

                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                CheckNextCell(0,1);
                // Move down
                neighbourCell = _map.Player.Cell.GetNeighbor(0, 1);
                
                if (neighbourCell.CanIMoveHere)
                {

                    _map.Player.Move(0, 1);
                }
                if (neighbourCell.CanIFight)
                {
                    neighbourCell.Actor.TakeDamage(5);

                    if (neighbourCell.Actor.Health > 0)
                    {
                        _map.Player.TakeDamage(2);
                    }

                    else
                    {
                        neighbourCell.Actor = null;
                        neighbourCell.CanIFight = false;
                        neighbourCell.CanIMoveHere = true;
                        neighbourCell.CellType = CellType.Floor;
                    }
                }

                _lastMoveTime = gameTime.TotalGameTime;
            }


            base.Update(gameTime);
        }

        private void CheckNextCell(int x, int y)
        {
            var neighborCell = _map.Player.Cell.GetNeighbor(x, y);
            
            var matchedItem = _map.GetItems().Find(item => item.Cell.X == neighborCell.X && item.Cell.Y == neighborCell.Y);
             
             if (matchedItem != null)
             {
                 switch (matchedItem.Type)
                 {
                    case "item":
                        _map.Player.SetItem(matchedItem);
                        matchedItem.Disable();
                        _map.GetItems().Remove(matchedItem);
                        break;

                    case "weapon":
                        _map.Player.Weapon = matchedItem;
                        matchedItem.Disable();
                        _map.GetItems().Remove(matchedItem);
                        break;

                    case "door":
                        Console.WriteLine("door");
                        List<Key> keys = new List<Key>();
                        foreach (var item in _map.Player.GetItems())
                        {
                            keys.Add((Key)item);
                        }
                        Door door = (Door)_map.GetItems().Find(item => item.Type == "door");
                        door.KeyLock(keys);
                        break;
                 }
             } 
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp);

            for (var x = 0; x < _map.Width; x++)
            {
                for (var y = 0; y < _map.Height; y++)
                {
                    var cell = _map.GetCell(x, y);

                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Actor, x, y);
                    }
                    else if (cell.Item != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Item, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(SpriteBatch, cell, x, y);
                    }
                }
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
