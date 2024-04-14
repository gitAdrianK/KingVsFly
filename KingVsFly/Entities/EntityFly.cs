using EntityComponent;
using JumpKing;
using JumpKing.Player;
using JumpKing.XnaWrappers;
using KingVsFly.Game;
using KingVsFly.Patching;
using KingVsFly.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using static KingVsFly.Patching.GameLoopDraw;

namespace KingVsFly.Entities
{
    public class EntityFly : Entity
    {
        private enum Facing
        {
            Left,
            Right,
        }

        private enum State
        {
            Idle,
            FlyingUp,
            FlyingDown,
            Waiting,
        }

        GameState gameState;
        JKContentManager contentManager;
        Random random;

        FlyContent content;
        JKSound sound;
        Queue<Point> positionsQueue;

        Facing facing;
        State state;
        int screen;
        int prevScreen;

        float progress;
        Vector2 position;
        Vector2 prevPosition;
        Vector2 nextPosition;

        int idleIndex;
        int idleCooldown;

        int flyingIndex;
        int flyingFrames;

        PlayerEntity player;

        public EntityFly(GameState gameState, PlayerEntity player)
        {
            contentManager = Game1.instance.contentManager;
            random = Game1.random;

            char sep = Path.DirectorySeparatorChar;
            string directory = $"{Game1.instance.contentManager.root}{sep}props{sep}textures{sep}raven{sep}fly";

            // Be aware that when started through WS or on a custom map no RavenContent exists where we could try to get the fly textures.
            // So we just load it ourselves.
            content = new FlyContent(contentManager.Load<Texture2D>(directory));
            contentManager?.audio?.music?.event_music?.TryGetValue("bug_fly", out sound);

            this.gameState = gameState;

            positionsQueue = gameState.GetRandomCurrentScreenPoints();

            screen = gameState.currentScreen;
            prevScreen = screen;

            progress = 0.0f;
            position = positionsQueue.Dequeue().ToVector2();
            nextPosition = positionsQueue.Dequeue().ToVector2();

            idleIndex = 0;
            idleCooldown = 0;

            flyingIndex = 0;
            flyingFrames = 5;

            this.player = player;
        }

        protected override void Update(float deltaTime)
        {
            switch (state)
            {
                case State.Idle:
                    UpdateIdle();
                    break;
                case State.FlyingUp:
                case State.FlyingDown:
                    UpdateFlying(deltaTime);
                    break;
                case State.Waiting:
                    UpdateIdleAnimation();
                    UpdateWaiting();
                    break;
            }
        }

        private void UpdateIdle()
        {
            UpdateIdleState();
            UpdateIdleAnimation();
        }

        private void UpdateIdleState()
        {
            Vector2 center = new Vector2(position.X + 10, position.Y);
            float distanceTo = (center - player.m_body.GetHitbox().Center.ToVector2()).LengthSquared();
            if (!player.m_body.IsOnGround || distanceTo > 800)
            {
                return;
            }
            gameState.resetPosition = position.ToPoint();
            prevPosition = position;
            if (positionsQueue.Count == 0)
            {
                gameState.AdvanceScreen();
                prevScreen = screen;
                screen = gameState.currentScreen;
                positionsQueue = gameState.GetRandomCurrentScreenPoints();
            }
            nextPosition = positionsQueue.Dequeue().ToVector2();
            state = position.Y < nextPosition.Y ? State.FlyingDown : State.FlyingUp;
            facing = position.X < nextPosition.X ? Facing.Right : Facing.Left;
            sound.Play();
        }

        private void UpdateIdleAnimation()
        {
            idleCooldown--;
            if (idleCooldown > 0)
            {
                return;
            }
            if (random.Next(100) == 0)
            {
                idleIndex = random.Next(content.IdleSprites.Length);
                idleCooldown = 60;
            }
        }

        private void UpdateFlying(float deltaTime)
        {
            UpdateFlyingPosition(deltaTime);
            UpdateFlyingAnimation();
        }

        private void UpdateFlyingPosition(float deltaTime)
        {
            progress += deltaTime * 0.5f;
            if (progress >= 1.0f)
            {
                progress = 0.0f;
                state = State.Idle;
                position = nextPosition;
                prevPosition = position;
                if (screen == gameState.finalScreen)
                {
                    state = State.Waiting;
                }
                return;
            }
            position = Vector2.Lerp(prevPosition, nextPosition, progress);
        }

        private void UpdateFlyingAnimation()
        {
            if (flyingFrames <= 0)
            {
                flyingFrames = 5;
                flyingIndex++;
            }
            flyingFrames--;
        }

        private void UpdateWaiting()
        {
            // XXX: The trigger for the normal babe ending is still there so we stop the player
            // before he walk into it.
            if (player.m_body.Position.Y <= position.Y + 1)
            {
                player.m_body.Velocity = Vector2.Zero;
                if (GameLoopDraw.state == EndingState.Waiting)
                {
                    GameLoopDraw.state = EndingState.Blackscreen;
                }
            }
        }

        public override void Draw()
        {
            int cameraScreen = Camera.CurrentScreen;
            if (!(prevScreen == cameraScreen || screen == cameraScreen))
            {
                return;
            }

            SpriteEffects effect = facing == Facing.Left ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Sprite sprite;
            switch (state)
            {
                case State.Idle:
                case State.Waiting:
                    sprite = content?.IdleSprites[idleIndex];
                    break;
                case State.FlyingDown:
                    sprite = content?.FlyDownTreasure[flyingIndex % content.FlyDownTreasure.Length];
                    break;
                case State.FlyingUp:
                    sprite = content?.Fly[flyingIndex % content.Fly.Length];
                    break;
                default:
                    // UnreachableException.
                    throw new Exception();
            }

            // Magic number guesswork to somewhat center the sprite.
            // Why this in needed? The points are "kingsized", so we need to adjust them for the fly.
            float actualX = position.X + 10;
            float actualY = position.Y + cameraScreen * 360 + 18;

            sprite.Draw(actualX, actualY, effect);
        }
    }
}
