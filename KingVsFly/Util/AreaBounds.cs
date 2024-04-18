using System.Collections.Generic;

namespace KingVsFly.Util
{
    /// <summary>
    /// Represents the start and end screens of an area inside the game.
    /// </summary>
    public readonly struct AreaBounds
    {
        public readonly int start;
        public readonly int end;

        public AreaBounds(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public static IEnumerable<int> BoundsListIterator(List<AreaBounds> bounds)
        {
            foreach (AreaBounds bound in bounds)
            {
                for (int i = bound.start; i <= bound.end; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
