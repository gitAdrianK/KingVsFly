using EntityComponent;
using JumpKing;
using JumpKing.Player;
using KingVsFly.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;

namespace KingVsFly.Entities
{
    public class EntityCheckpoint : Entity
    {
        GameState gameState;
        JKContentManager contentManager;
        Texture2D texture;
        PlayerEntity player;
        int screen;

        public EntityCheckpoint(GameState gameState, PlayerEntity player)
        {
            contentManager = Game1.instance.contentManager;
            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}flag";

            texture = contentManager.Load<Texture2D>(directory);

            this.gameState = gameState;
            this.player = player;
            ResetPlayer();

            screen = gameState.currentScreen;
            Camera.UpdateCamera(gameState.resetPosition);
        }

        protected override void Update(float deltaTime)
        {
            if (Camera.CurrentScreen < screen)
            {
                ResetPlayer();
                Camera.UpdateCamera(gameState.resetPosition);
                gameState.resets++;
                return;
            }
            if (screen < gameState.currentScreen
                && Camera.CurrentScreen == screen + 1
                && player.m_body.IsOnGround)
            {
                gameState.resetPosition = gameState.positions[(int)gameState.enumerator.Current][0];
                if (Camera.CurrentScreen != gameState.currentScreen)
                {
                    ResetPlayer();
                }
                screen = ModEntry.gameState.currentScreen;
                return;
            }
        }

        private void ResetPlayer()
        {
            player.m_body.Position = gameState.resetPosition.ToVector2();
            player.m_body.Velocity = Vector2.Zero;
        }

        public override void Draw()
        {
            Point point = gameState.resetPosition;
            float actualX = point.X;
            float actualY = point.Y + Camera.CurrentScreen * 360 - 6;
            Game1.spriteBatch.Draw(
                texture: texture,
                position: new Vector2(actualX, actualY),
                sourceRectangle: new Rectangle(0, 0, texture.Width, texture.Height),
                color: Color.White);
        }
    }
}