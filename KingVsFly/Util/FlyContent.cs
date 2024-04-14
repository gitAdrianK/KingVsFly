using JumpKing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Stolen from JKContentManager

namespace KingVsFly.Util
{
    internal class FlyContent
    {
        internal Texture2D texture;

        public Sprite[] IdleSprites;
        public Sprite[] IdleSpritesTreasure;

        public Sprite Blink;
        public Sprite BlinkTreasure;

        public Sprite[] Fly;
        public Sprite[] FlyTreasure;
        public Sprite[] FlyDownTreasure;

        internal FlyContent(Texture2D texture)
        {
            this.texture = texture;
            Vector2 center = Vector2.One / 2f;
            Sprite[] array = SpriteChopUtilGrid(this.texture, new Point(4, 2), Vector2.Zero, new Rectangle(0, 0, 128, 64));
            Sprite[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i].center = center;
            }

            IdleSprites = new Sprite[3];
            IdleSprites[0] = array[0];
            IdleSprites[1] = array[2];
            IdleSprites[2] = array[3];
            IdleSpritesTreasure = new Sprite[3];
            IdleSpritesTreasure[0] = array[4];
            IdleSpritesTreasure[1] = array[6];
            IdleSpritesTreasure[2] = array[7];
            Blink = array[1];
            BlinkTreasure = array[5];
            Sprite[] array3 = SpriteChopUtilGrid(this.texture, new Point(3, 3), Vector2.Zero, new Rectangle(0, 64, 144, 96));
            array2 = array3;
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i].center = center;
            }

            Fly = new Sprite[3];
            Fly[0] = array3[0];
            Fly[1] = array3[1];
            Fly[2] = array3[2];
            FlyTreasure = new Sprite[3];
            FlyTreasure[0] = array3[3];
            FlyTreasure[1] = array3[4];
            FlyTreasure[2] = array3[5];
            FlyDownTreasure = new Sprite[3];
            FlyDownTreasure[0] = array3[6];
            FlyDownTreasure[1] = array3[7];
            FlyDownTreasure[2] = array3[8];
        }

        private static Sprite[] SpriteChopUtilGrid(Texture2D texture, Point cells, Vector2 center, Rectangle source)
        {
            int countX = source.Width / cells.X;
            int countY = source.Height / cells.Y;
            Sprite[] array = new Sprite[cells.X * cells.Y];
            for (int i = 0; i < cells.X; i++)
            {
                for (int j = 0; j < cells.Y; j++)
                {
                    array[i + j * cells.X] = Sprite.CreateSpriteWithCenter(texture, new Rectangle(source.X + countX * i, source.Y + countY * j, countX, countY), center);
                }
            }

            return array;
        }
    }
}
