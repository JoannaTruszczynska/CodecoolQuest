using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Codecool.Quest.Models
{
    public static class GUI
    {
        private static Texture2D _button;
        private static SpriteFont _font;

        public static void Load()
        {
            _button = CodecoolQuestGame.GameSingleton.Content.Load<Texture2D>("ButtonNormal");
            _font = CodecoolQuestGame.GameSingleton.Content.Load<SpriteFont>("Font");
        }

        /// <summary>
        /// Draws a GUI button and returns true when it's pressed
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Button(Rectangle rect, string text)
        {
            var state = Mouse.GetState();
            var color = Color.White;

            if (rect.Contains(state.X, state.Y))
            {
                color = Color.Gray;
                if (state.LeftButton == ButtonState.Pressed)
                    return true;
            }

            CodecoolQuestGame.GameSingleton.SpriteBatch.Draw(_button, rect, color);
            Text(new Vector2(rect.X, rect.Y), text, color);

            return false;
        }

        /// <summary>
        /// Draws given text
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void Text(Vector2 pos, string text, Color color)
        {
            CodecoolQuestGame.GameSingleton.SpriteBatch.DrawString(_font, text, pos, color);
        }
    }
}
