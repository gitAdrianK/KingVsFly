using EntityComponent;
using HarmonyLib;
using JumpKing;
using JumpKing.Level;
using JumpKing.Player;
using JumpKing.SaveThread;
using KingVsFly.GameInfo;
using KingVsFly.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace KingVsFly.Entities
{
    public class EntityCheckpoint : Entity
    {
        private readonly List<AreaBounds> areas;
        private readonly Dictionary<int, List<Point>> positions;
        private readonly int finalScreen;
        private readonly IEnumerator<int> enumerator;
        private int CurrentScreen => enumerator.Current;
        public Point resetPosition;
        public int resets;

        private readonly Texture2D texture;

        private readonly PlayerEntity entityPlayer;
        private readonly Traverse traversePlayer;
        private readonly Traverse traverseFailState;

        public EntityFly entityFly;

        private bool isUnderburgRevisit65;
        private bool isUnderburgRevisit66;

        public EntityCheckpoint(PlayerEntity entityPlayer)
        {
            if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedGhost))
            {
                areas = GhostBabeGameInfo.areas;
                positions = GhostBabeGameInfo.positions;
                finalScreen = GhostBabeGameInfo.finalScreen;
            }
            else if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedNBP))
            {
                areas = NewBabeGameInfo.areas;
                positions = NewBabeGameInfo.positions;
                finalScreen = NewBabeGameInfo.finalScreen;
            }
            else
            {
                areas = MainBabeGameInfo.areas;
                positions = MainBabeGameInfo.positions;
                finalScreen = MainBabeGameInfo.finalScreen;
            }
            enumerator = AreaBounds.BoundsListIterator(areas).GetEnumerator();
            enumerator.MoveNext();
            resetPosition = positions[CurrentScreen][0];
            resets = 0;

            JKContentManager contentManager = Game1.instance.contentManager;
            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}flag";
            texture = contentManager.Load<Texture2D>(directory);

            this.entityPlayer = entityPlayer;
            traversePlayer = Traverse.Create(this.entityPlayer);
            traverseFailState = traversePlayer?.Field("m_fail_state");
            ResetPlayer();

            isUnderburgRevisit65 = false;
            isUnderburgRevisit66 = false;
        }

        protected override void Update(float deltaTime)
        {
            int cameraScreen = Camera.CurrentScreen;
            if (cameraScreen == finalScreen
                && entityFly.CurrentScreen != finalScreen)
            {
                ResetPlayer();
                return;
            }
            if (cameraScreen != CurrentScreen
                && cameraScreen != entityFly.CurrentScreen
                && cameraScreen != entityFly.CurrentScreen + 1)
            {
                ResetPlayer();
                resets++;
                return;
            }

            if (CurrentScreen != entityFly.CurrentScreen
                && cameraScreen == entityFly.CurrentScreen
                && (entityPlayer.m_body.IsOnGround || entityPlayer.m_body.IsOnBlock<SandBlock>()))
            {
                enumerator.MoveNext();
                resetPosition = positions[CurrentScreen][0];
                if (CurrentScreen == 65)
                {
                    if (isUnderburgRevisit65)
                    {
                        resetPosition = positions[CurrentScreen][2];
                    }
                    isUnderburgRevisit65 = true;
                }
                if (CurrentScreen == 66)
                {
                    if (isUnderburgRevisit66)
                    {
                        resetPosition = positions[CurrentScreen][2];
                    }
                    isUnderburgRevisit66 = true;
                }
            }
        }

        private void ResetPlayer()
        {
            traverseFailState.Field("m_wait_done").SetValue(true);
            entityPlayer.m_body.Position = resetPosition.ToVector2();
            entityPlayer.m_body.Velocity = Vector2.Zero;
            Camera.UpdateCamera(resetPosition);
        }

        public override void Draw()
        {
            if (Camera.CurrentScreen != CurrentScreen)
            {
                return;
            }

            Point point = resetPosition;
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