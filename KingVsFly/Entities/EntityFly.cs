using EntityComponent;
using JumpKing;
using JumpKing.Level;
using JumpKing.Player;
using JumpKing.SaveThread;
using JumpKing.XnaWrappers;
using KingVsFly.GameInfo;
using KingVsFly.Patching;
using KingVsFly.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static JumpKing.JKContentManager.RavenSprites;
using static KingVsFly.Patching.GameLoopDraw;

namespace KingVsFly.Entities
{
    public class EntityFly : Entity
    {
        private readonly List<AreaBounds> areas;
        private readonly Dictionary<int, List<Point>> positions;
        private readonly int finalScreen;
        private readonly IEnumerator<int> enumerator;
        private readonly Queue<Point> positionsQueue;
        public int CurrentScreen => enumerator.Current;
        private int prevScreen;

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

        private Facing facing;
        private State state;

        private readonly Random random;

        private readonly RavenContent flySprites;
        private readonly JKSound sound;

        private float progress;
        private Vector2 position;
        private Vector2 nextPosition;
        private Vector2 prevPosition;

        private int idleIndex;
        private int idleCooldown;
        private int flyingIndex;
        private int flyingFrames;

        private readonly PlayerEntity entityPlayer;
        public EntityCheckpoint entityCheckpoint;

        private bool isUnderburgRevisit65;
        private bool isUnderburgRevisit66;

        public EntityFly(PlayerEntity entityPlayer)
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
            prevScreen = CurrentScreen;
            positionsQueue = new Queue<Point>();
            GetRandomCurrentScreenPoints();
            position = positionsQueue.Dequeue().ToVector2();
            prevPosition = position;
            nextPosition = position;

            random = Game1.random;

            JKContentManager contentManager = Game1.instance.contentManager;
            // Be aware that when started through WS or on a custom map no RavenContent exists where we could try to get the fly textures,
            // but since the mod requires explicit activation in the menu this is irrelevant.
            flySprites = contentManager.ravenSprites.raven_content["fly"];
            contentManager.audio.music.event_music.TryGetValue("bug_fly", out sound);

            progress = 0.0f;
            idleIndex = 0;
            idleCooldown = 0;
            flyingIndex = 0;
            flyingFrames = 5;

            this.entityPlayer = entityPlayer;

            isUnderburgRevisit65 = false;
            isUnderburgRevisit66 = false;
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
            float distanceTo = (center - entityPlayer.m_body.GetHitbox().Center.ToVector2()).LengthSquared();
            if (!entityPlayer.m_body.IsOnGround
                && !entityPlayer.m_body.IsOnBlock<SandBlock>()
                || distanceTo > 800)
            {
                return;
            }

            if (entityCheckpoint != null)
            {
                entityCheckpoint.resetPosition = position.ToPoint();
            }
            prevPosition = position;
            if (positionsQueue.Count == 0)
            {
                prevScreen = CurrentScreen;
                enumerator.MoveNext();
                GetRandomCurrentScreenPoints();
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
                idleIndex = random.Next(flySprites.IdleSprites.Length);
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
                if (CurrentScreen == finalScreen)
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
            // before he walks into it.
            if (entityPlayer.m_body.Position.Y <= position.Y + 1)
            {
                entityPlayer.m_body.Velocity = Vector2.Zero;
                if (GameLoopDraw.state == EndingState.Waiting)
                {
                    GameLoopDraw.state = EndingState.Blackscreen;
                }
            }
        }

        /// <summary>
        /// Gets a queue containing positions based on the current screen.
        /// The first point will never be the first and consecutive points will never be the same point.
        /// That is the first positions are inside the screen and the last one above the screen to "indicate a flying away"
        /// </summary>
        /// <returns>Queue of random points.</returns>
        private void GetRandomCurrentScreenPoints()
        {
            if (CurrentScreen == 65)
            {
                if (isUnderburgRevisit65)
                {
                    positionsQueue.Enqueue(positions[CurrentScreen][3]);
                    return;
                }
                positionsQueue.Enqueue(positions[CurrentScreen][1]);
                isUnderburgRevisit65 = true;
                return;
            }
            if (CurrentScreen == 66)
            {
                if (isUnderburgRevisit66)
                {
                    positionsQueue.Enqueue(positions[CurrentScreen][3]);
                    return;
                }
                positionsQueue.Enqueue(positions[CurrentScreen][1]);
                isUnderburgRevisit66 = true;
                return;
            }

            if (positions[CurrentScreen].Count == 2)
            {
                positionsQueue.Enqueue(positions[CurrentScreen][1]);
                return;
            }

            Random random = Game1.random;
            List<Point> points = positions[CurrentScreen];
            int next = random.Next(1, points.Count);
            int prev = next;
            positionsQueue.Enqueue(points[next]);
            // FIXME: The fly sometimes has the same point in a row. Why?
            // It seems to have fixed itself randomly? I think?
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    next = random.Next(points.Count);
                } while (next == prev);
                prev = next;
                positionsQueue.Enqueue(points[next]);
            }
        }

        public override void Draw()
        {
            int cameraScreen = Camera.CurrentScreen;
            if (prevScreen != cameraScreen && CurrentScreen != cameraScreen)
            {
                return;
            }

            SpriteEffects effect = facing == Facing.Left ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Sprite sprite;
            switch (state)
            {
                case State.Idle:
                case State.Waiting:
                    sprite = flySprites.IdleSprites[idleIndex];
                    break;
                case State.FlyingDown:
                    sprite = flySprites.FlyDownTreasure[flyingIndex % flySprites.FlyDownTreasure.Length];
                    break;
                case State.FlyingUp:
                    sprite = flySprites.Fly[flyingIndex % flySprites.Fly.Length];
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
