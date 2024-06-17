using EntityComponent;
using JumpKing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Reflection;

namespace KingVsFly.Entities
{
    public class EntitySnake : Entity
    {
        private readonly Random random;
        private int index;
        private int cooldown;
        private readonly Vector2 position;
        private readonly Texture2D texture;
        private readonly int sectionWidth;
        private readonly int sectionHeight;
        public EntitySnake()
        {
            random = Game1.random;
            index = 0;
            cooldown = 120;

            position = new Vector2(195, 150);

            JKContentManager contentManager = Game1.instance.contentManager;
            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}snake";
            texture = contentManager.Load<Texture2D>(directory);
            sectionWidth = texture.Width / 3;
            sectionHeight = texture.Height / 2;
        }

        protected override void Update(float deltaTime)
        {
            if (Camera.CurrentScreen != 87)
            {
                return;
            }

            cooldown--;
            if (cooldown > 0)
            {
                return;
            }
            if (random.Next(100) == 0)
            {
                index = random.Next(6);
                cooldown = 120;
            }
        }

        public override void Draw()
        {
            if (Camera.CurrentScreen != 87)
            {
                return;
            }

            int div = index / 3;
            int mod = index % 3;

            Game1.spriteBatch.Draw(
                texture: texture,
                position: position,
                sourceRectangle: new Rectangle(sectionWidth * mod, sectionHeight * div, sectionWidth, sectionHeight),
                color: Color.White);
        }
    }
}
