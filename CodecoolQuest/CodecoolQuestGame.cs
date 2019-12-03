using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        private readonly Dictionary<string, int> _coord = new Dictionary<string, int>();

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
            // fixme this is not using OOP principles
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // Move left
                CheckNextCell(-1, 0);
                neighbourCell = _map.Player.Cell.GetNeighbor(-1, 0);

                if (neighbourCell.CanIMoveHere)
                {
                    _map.Player.Move(-1, 0);
                }

                else if (neighbourCell.CanIFight)
                {
                    _map.Player.Fight(neighbourCell, _map);
                    if (neighbourCell.Actor != null)
                        neighbourCell.Actor.InFightCantMove = true;
                }

                foreach (Skeleton skeleton in _map.skeletonList)
                {
                    if (!skeleton.InFightCantMove)
                    {
                        Util.SkeletonMove(_map, neighbourCell, skeleton);
                    }

                    skeleton.InFightCantMove = false;
                }
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
                else if (neighbourCell.CanIFight)
                {
                    _map.Player.Fight(neighbourCell, _map);
                    if (neighbourCell.Actor != null)
                        neighbourCell.Actor.InFightCantMove = true;
                }

                foreach (Skeleton skeleton in _map.skeletonList)
                {
                    if (!skeleton.InFightCantMove)
                    {
                        Util.SkeletonMove(_map, neighbourCell, skeleton);
                    }

                    skeleton.InFightCantMove = false;
                }
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
                else if (neighbourCell.CanIFight)
                {
                    _map.Player.Fight(neighbourCell, _map);
                    if (neighbourCell.Actor != null)
                        neighbourCell.Actor.InFightCantMove = true;
                }

                foreach (Skeleton skeleton in _map.skeletonList)
                {
                    if (!skeleton.InFightCantMove)
                    {
                        Util.SkeletonMove(_map, neighbourCell, skeleton);
                    }

                    skeleton.InFightCantMove = false;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                CheckNextCell(0, 1);
                // Move down
                neighbourCell = _map.Player.Cell.GetNeighbor(0, 1);

                if (neighbourCell.CanIMoveHere)
                {
                    _map.Player.Move(0, 1);
                }
                else if (neighbourCell.CanIFight)
                {
                    _map.Player.Fight(neighbourCell, _map);
                    if (neighbourCell.Actor != null)
                        neighbourCell.Actor.InFightCantMove = true;
                }

                foreach (Skeleton skeleton in _map.skeletonList)
                {
                    if (!skeleton.InFightCantMove)
                    {
                        Util.SkeletonMove(_map, neighbourCell, skeleton);
                    }

                    skeleton.InFightCantMove = false;
                }
            }

            _lastMoveTime = gameTime.TotalGameTime;

            base.Update(gameTime);
        }


        private void CheckNextCell(int x, int y)
        {
            var neighborCell = _map.Player.Cell.GetNeighbor(x, y);

            var matchedItem = _map.GetItems()
                .Find(item => item.Cell.X == neighborCell.X && item.Cell.Y == neighborCell.Y);

            if (matchedItem != null)
            {
                switch (matchedItem.Type)
                {
                    case "item":
                        matchedItem.UpdateOwnerProperties(_map.Player);
                        matchedItem.Disable();
                        _map.GetItems().Remove(matchedItem);
                        break;

                    case "weapon":
                        matchedItem.UpdateOwnerProperties(_map.Player);
                        _map.Player.TileName = "armedplayer";
                        _map.Player.Weapon = matchedItem;
                        matchedItem.Disable();
                        _map.GetItems().Remove(matchedItem);
                        break;

                    case "door":
                        List<Key> playerKeys = new List<Key>();
                        // keys = _map.Player.GetItems().ForEach(item => item.Subtype == "dupa");
                        foreach (var item in _map.Player.GetItems())
                        {
                            if (item.Subtype == "key")
                                playerKeys.Add((Key) item);
                        }

                        Door door = (Door) matchedItem;
                        door.KeyLock(playerKeys);
                        break;
                }
            }
        }

        /// <summary>
        /// This function calculates the drawing area of the map relative to the player's position
        /// </summary>
        /// <returns></returns>
        private void CalculateFogWar()
        {
            var drawingSquare = _map.Player.SightRange;

            _coord["leftBorder"] = (_map.Player.X - drawingSquare <= 0)
                ? 0
                : _map.Player.X - drawingSquare;

            _coord["rightBorder"] = (_map.Player.X + drawingSquare >= _map.Width)
                ? _map.Width
                : _map.Player.X + drawingSquare;

            _coord["topBorder"] = (_map.Player.Y - drawingSquare <= 0)
                ? 0
                : _map.Player.Y - drawingSquare;

            _coord["bottomBorder"] = (_map.Player.Y + drawingSquare >= _map.Height)
                ? _map.Height
                : _map.Player.Y + drawingSquare;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            CalculateFogWar();

            GraphicsDevice.Clear(Color.FromNonPremultiplied(71, 45, 60, 256));

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp);

            for (var x = _coord["leftBorder"]; x < _coord["rightBorder"]; x++)
            {
                for (var y = _coord["topBorder"]; y < _coord["bottomBorder"]; y++)
                {
                    var cell = _map.GetCell(x, y);

                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Actor, x, y);
                    }
                    else if (cell.Thing != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Thing, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(SpriteBatch, cell, x, y);
                    }
                }
            }


            SpriteBatch.End();


            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp);
            GUI.Text(new Vector2(700, 5), _map.Player.Health.ToString(), Color.White);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}