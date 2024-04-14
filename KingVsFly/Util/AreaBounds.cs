using System.Collections.Generic;
using System.Linq;

namespace KingVsFly.Util
{
    /// <summary>
    /// Represents the start and end screens of an area inside the game.
    /// </summary>
    public readonly struct AreaBounds
    {
        public readonly int start;
        public readonly int end;
        public readonly int[] exclude;

        public AreaBounds(int start, int end, params int[] exclude)
        {
            this.start = start;
            this.end = end;
            this.exclude = exclude;
        }

        public AreaBounds(int start, int end)
        {
            this.start = start;
            this.end = end;
            exclude = new int[0];
        }

        public static IEnumerable<int> BoundsListIterator(List<AreaBounds> bounds)
        {
            foreach (AreaBounds bound in bounds)
            {
                for (int i = bound.start; i <= bound.end; i++)
                {
                    if (bound.exclude.Contains(i))
                    {
                        continue;
                    }
                    yield return i;
                }
            }
        }
    }
}
