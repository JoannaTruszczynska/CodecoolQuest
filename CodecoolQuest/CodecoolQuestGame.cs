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

        private void MoveEnemies()
        {

            foreach (Actor actor in _map.GetActors())
            {
                if (!actor.InFightCantMove)
                {

                    actor.Move(Util.RandomNumber(-1, 2), Util.RandomNumber(-1, 2));
                }

                actor.InFightCantMove = false;
            }
        }

        private void DoTurn(int dx, int dy)
        {
            CheckNextCell(dx, dy);
            var neighbourCell = _map.Player.Cell.GetNeighbor(dx, dy);

            if (neighbourCell.CanIMoveHere)
            {
                _map.Player.Move(dx, dy);
            }
            MoveEnemies();
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
                DoTurn(-1,0);
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                DoTurn(1, 0);
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                DoTurn(0, -1);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                DoTurn(0, 1);
            }
            _lastMoveTime = gameTime.TotalGameTime;
            base.Update(gameTime);
        }


        private void CheckNextCell(int x, int y)
        {
            var neighborCell = _map.Player.Cell.GetNeighbor(x, y);
            
            var matchedThings = _map.GetThings()
                .Find(item => item.Cell.X == neighborCell.X && item.Cell.Y == neighborCell.Y);
            if (matchedThings != null)
            {
                Sort.SortForThings(matchedThings, _map);
            }
            
            var matchedActor = _map.GetActors()
                .Find(actor => actor.Cell.X == neighborCell.X && actor.Cell.Y == neighborCell.Y);
            if (matchedActor != null)
            {
                Sort.SortForActors(matchedActor, _map);
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
            GUI.Text(new Vector2(1100, 5), "Player health: " + _map.Player.Health.ToString(), Color.White);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}