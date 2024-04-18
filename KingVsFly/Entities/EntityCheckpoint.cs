﻿using EntityComponent;
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
        private List<AreaBounds> areas;
        private Dictionary<int, List<Point>> positions;
        private IEnumerator<int> enumerator;
        private int currentScreen => enumerator.Current;
        public Point resetPosition;
        public int resets;

        private Texture2D texture;

        private PlayerEntity entityPlayer;

        public EntityFly entityFly;

        private bool isUnderburgRevisit65;
        private bool isUnderburgRevisit66;

        public EntityCheckpoint(PlayerEntity entityPlayer)
        {
            if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedGhost))
            {
                areas = GhostBabeGameInfo.areas;
                positions = GhostBabeGameInfo.positions;
            }
            else if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedNBP))
            {
                areas = NewBabeGameInfo.areas;
                positions = NewBabeGameInfo.positions;
            }
            else
            {
                areas = MainBabeGameInfo.areas;
                positions = MainBabeGameInfo.positions;
            }
            enumerator = AreaBounds.BoundsListIterator(areas).GetEnumerator();
            enumerator.MoveNext();
            resetPosition = positions[currentScreen][0];
            resets = 0;

            JKContentManager contentManager = Game1.instance.contentManager;
            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}flag";
            texture = contentManager.Load<Texture2D>(directory);

            this.entityPlayer = entityPlayer;
            ResetPlayer();

            isUnderburgRevisit65 = false;
            isUnderburgRevisit66 = false;
        }

        protected override void Update(float deltaTime)
        {
            int cameraScreen = Camera.CurrentScreen;
            if (cameraScreen != currentScreen
                && cameraScreen != entityFly.currentScreen
                && cameraScreen != entityFly.currentScreen + 1)
            {
                ResetPlayer();
                resets++;
                return;
            }

            if (currentScreen != entityFly.currentScreen
                && cameraScreen == entityFly.currentScreen
                && (entityPlayer.m_body.IsOnGround || entityPlayer.m_body.IsOnBlock<SandBlock>()))
            {
                enumerator.MoveNext();
                resetPosition = positions[currentScreen][0];
                if (currentScreen == 65)
                {
                    if (isUnderburgRevisit65)
                    {
                        resetPosition = positions[currentScreen][2];
                    }
                    isUnderburgRevisit65 = true;
                }
                if (currentScreen == 66)
                {
                    if (isUnderburgRevisit66)
                    {
                        resetPosition = positions[currentScreen][2];
                    }
                    isUnderburgRevisit66 = true;
                }
            }
        }

        private void ResetPlayer()
        {
            entityPlayer.m_body.Position = resetPosition.ToVector2();
            entityPlayer.m_body.Velocity = Vector2.Zero;
            Camera.UpdateCamera(resetPosition);
        }

        public override void Draw()
        {
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