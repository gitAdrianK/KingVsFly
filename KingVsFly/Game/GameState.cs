using JumpKing;
using KingVsFly.GameInfo;
using KingVsFly.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace KingVsFly.Game
{
    public class GameState
    {
        public enum Map
        {
            MainBabe,
            NewBabe,
            GhostBabe,
        }

        public IEnumerator enumerator;
        public int currentScreen;

        public int finalScreen;

        public Dictionary<int, List<Point>> positions;
        public Point resetPosition;

        public int resets;

        public GameState(Map map)
        {
            switch (map)
            {
                case Map.MainBabe:
                    enumerator = AreaBounds.BoundsListIterator(MainBabeGameInfo.areas).GetEnumerator();
                    positions = MainBabeGameInfo.positions;
                    finalScreen = MainBabeGameInfo.finalScreen;
                    break;
                case Map.NewBabe:
                    enumerator = AreaBounds.BoundsListIterator(NewBabeGameInfo.areas).GetEnumerator();
                    positions = NewBabeGameInfo.positions;
                    finalScreen = NewBabeGameInfo.finalScreen;
                    break;
                case Map.GhostBabe:
                    enumerator = AreaBounds.BoundsListIterator(GhostBabeGameInfo.areas).GetEnumerator();
                    positions = GhostBabeGameInfo.positions;
                    finalScreen = GhostBabeGameInfo.finalScreen;
                    break;
            }
            enumerator.MoveNext();
            resetPosition = positions[(int)enumerator.Current][0];
            currentScreen = (int)enumerator.Current;
            resets = 0;
        }

        public void AdvanceScreen()
        {
            if (enumerator.MoveNext())
            {
                currentScreen = (int)enumerator.Current;
            }
        }

        /// <summary>
        /// Gets a queue containing positions based on the current screen.
        /// The first point will never be the first and consecutive points will never be the same point.
        /// That is the first positions are inside the screen and the last one above the screen to "indicate a flying away"
        /// </summary>
        /// <returns>Queue of random points.</returns>
        public Queue<Point> GetRandomCurrentScreenPoints()
        {
            Queue<Point> queue = new Queue<Point>();

            if (currentScreen == finalScreen)
            {
                queue.Enqueue(positions[currentScreen][1]);
                return queue;
            }

            Random random = Game1.random;
            List<Point> points = positions[currentScreen];
            int next = random.Next(1, points.Count);
            int prev = next;
            queue.Enqueue(points[next]);
            // FIXME: The fly sometimes has the same point in a row. Why?
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    next = random.Next(points.Count);
                } while (next == prev);
                prev = next;
                queue.Enqueue(points[next]);
            }
            return queue;
        }
    }
}
