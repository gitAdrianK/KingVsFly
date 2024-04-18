using KingVsFly.Util;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace KingVsFly.GameInfo
{
    public static class MainBabeGameInfo
    {
        /// <summary>
        /// Contains the area bounds of an area in the main babe part of the game.
        /// </summary>
        public static readonly List<AreaBounds> areas = new List<AreaBounds>
        {
            new AreaBounds(0, 4),   // Redcrown Woods
            new AreaBounds(5, 9),   // Colossal Drain
            new AreaBounds(10, 13), // False Kings Keep
            new AreaBounds(14, 18), // Bargainburg
            new AreaBounds(19, 24), // Great Frontier
            new AreaBounds(25, 32), // Stormwall Pass 
            new AreaBounds(33, 35), // Chapel Perillous
            new AreaBounds(36, 38), // Blue Ruin
            new AreaBounds(39, 42), // The Tower
        };

        /// <summary>
        /// The final screen of the main babe.
        /// </summary>
        public static readonly int finalScreen = 42;

        /// <summary>
        /// Contains the list of points that the fly can fly to on each screen of main babe.
        /// The first point should also be the start position of the king when entering the screen for the first time.
        /// The positions are in global space and need to be converted to screen space before being rendered.
        /// </summary>
        public static readonly Dictionary<int, List<Point>> positions = new Dictionary<int, List<Point>>
        {
            { 0, new List<Point>
            {
                new Point(231, 302),
                new Point(207, 14),
            }
            },
            { 1, new List<Point>
            {
                new Point(302, -90),
                new Point(418, -186),
                new Point(305, -186),
                new Point(165, -282),
                new Point(53, -306),
            }
            },
            { 2, new List<Point>
            {
                new Point(234, -442),
                new Point(340, -442),
                new Point(430, -490),
                new Point(313, -538),
                new Point(187, -626),
                new Point(40, -650),
            }
            },
            { 3, new List<Point>
            {
                new Point(143, -786),
                new Point(37, -890),
                new Point(178, -890),
                new Point(300, -946),
                new Point(154, -1018),
                new Point(346, -1034),
                new Point(436, -978),
            }
            },
            { 4, new List<Point>
            {
                new Point(127, -1154),
                new Point(330, -1154),
                new Point(20, -1226),
                new Point(332, -1226),
                new Point(445, -1306),
                new Point(295, -1378),
                new Point(231, -1394),
                new Point(170, -1410),
                new Point(51, -1378),
            }
            },
            { 5, new List<Point>
            {
                new Point(175, -1498),
                new Point(146, -1586),
                new Point(27, -1642),
                new Point(67, -1754),
                new Point(299, -1746),
            }
            },
            { 6, new List<Point>
            {
                new Point(402, -1842),
                new Point(300, -1978),
                new Point(163, -1964),
                new Point(17, -2018),
                new Point(129, -2138),
            }
            },
            { 7, new List<Point>
            {
                new Point(53, -2202),
                new Point(203, -2306),
                new Point(439, -2322),
                new Point(160, -2402),
                new Point(13, -2482),
            }
            },
            { 8, new List<Point>
            {
                new Point(61, -2610),
                new Point(16, -2738),
                new Point(87, -2818),
                new Point(183, -2770),
                new Point(118, -2698),
                new Point(210, -2698),
                new Point(303, -2698),
                new Point(399, -2698),
                new Point(398, -2810),
                new Point(238, -2810),
            }
            },
            { 9, new List<Point>
            {

                new Point(392, -2938),
                new Point(177, -3034),
                new Point(29, -3082),
                new Point(158, -3162),
                new Point(316, -3146),
                new Point(442, -3178),
            }
            },
            { 10, new List<Point>
            {
                new Point(352, -3282),
                new Point(267, -3306),
                new Point(173, -3386),
                new Point(265, -3386),
                new Point(359, -3402),
                new Point(20, -3418),
                new Point(17, -3506),
                new Point(160, -3458),
                new Point(355, -3498),
                new Point(446, -3498),
                new Point(261, -3578),
                new Point(442, -3578),
            }
            },
            { 11, new List<Point>
            {
                new Point(363, -3642),
                new Point(267, -3674),
                new Point(430, -3754),
                new Point(180, -3802),
                new Point(9, -3770),
                new Point(302, -3858),
            }
            },
            { 12, new List<Point>
            {
                new Point(421, -4002),
                new Point(223, -4074),
                new Point(97, -4146),
                new Point(234, -4250),
                new Point(355, -4234),
                new Point(442, -4314),
            }
            },
            { 13, new List<Point>
            {
                new Point(260, -4442),
                new Point(404, -4570),
                new Point(251, -4610),
            }
            },
            { 14,  new List<Point>
            {
                new Point(136, -4738),
                new Point(346, -4842),
                new Point(445, -4898),
                new Point(211, -4986),
                new Point(38, -4986),
            }
            },
            { 15, new List<Point>
            {
                new Point(38, -5114),
                new Point(237, -5154),
                new Point(333, -5154),
                new Point(404, -5138),
                new Point(399, -5250),
                new Point(283, -5330),
                new Point(188, -5274),
                new Point(35, -5346),
            }
            },
            { 16, new List<Point>
            {
                new Point(408, -5474),
                new Point(87, -5530),
            }
            },
            { 17, new List<Point>
            {
                new Point(52, -5850),
                new Point(87, -5906),
                new Point(17, -6026),
                new Point(138, -6010),
                new Point(125, -5842),
                new Point(261, -5866),
                new Point(382, -5898),
                new Point(334, -5938),
                new Point(419, -6002),
                new Point(387, -6066),
            }
            },
            { 18, new List<Point>
            {
                new Point(395, -6194),
                new Point(288, -6282),
                new Point(451, -6338),
                new Point(77, -6346),
                new Point(68, -6250),
                new Point(148, -6450),
            }
            },
            { 19, new List<Point>
            {
                new Point(223, -6594),
                new Point(129, -6594),
                new Point(66, -6682),
                new Point(56, -6762),
                new Point(446, -6594),
                new Point(441, -6682),
                new Point(407, -6778),
            }
            },
            { 20, new List<Point>
            {
                new Point(254, -6914),
                new Point(222, -6938),
                new Point(121, -6994),
                new Point(301, -7042),
                new Point(435, -7122),
            }
            },
            { 21, new List<Point>
            {
                new Point(273, -7266),
                new Point(21, -7354),
                new Point(125, -7394),
                new Point(299, -7482),
                new Point(425, -7362),
                new Point(298, -7346),
            }
            },
            { 22,  new List<Point>
            {
                new Point(145, -7626),
                new Point(42, -7722),
                new Point(14, -7842),
                new Point(154, -7746),
                new Point(330, -7778),
                new Point(449, -7882),
            }
            },
            { 23,  new List<Point>
            {
                new Point(251, -7994),
                new Point(109, -8098),
                new Point(252, -8098),
                new Point(359, -8162),
                new Point(257, -8226),
            }
            },
            { 24,  new List<Point>
            {
                new Point(84, -8362),
                new Point(76, -8474),
                new Point(252, -8442),
                new Point(378, -8434),
                new Point(236, -8578),
                new Point(91, -8610),
            }
            },
            { 25, new List<Point>
            {
                new Point(219, -8714),
                new Point(319, -8730),
                new Point(453, -8834),
                new Point(168, -8834),
                new Point(15, -8906),
                new Point(35, -8810),
                new Point(216, -8930),
            }
            },
            { 26, new List<Point>
            {
                new Point(167, -9092),
                new Point(354, -9084),
                new Point(204, -9228),
                new Point(85, -9244),
                new Point(183, -9356),
            }
            },
            { 27, new List<Point>
            {
                new Point(279, -9476),
                new Point(454, -9444),
                new Point(342, -9570),
                new Point(226, -9586),
                new Point(128, -9636),
                new Point(81, -9668),
            }
            },
            { 28, new List<Point>
            {
                new Point(176, -9788),
                new Point(334, -9804),
                new Point(152, -9940),
                new Point(8, -9908),
                new Point(452, -10004),
            }
            },
            { 29, new List<Point>
            {
                new Point(185, -10140),
                new Point(74, -10156),
                new Point(286, -10252),
                new Point(393, -10252),
                new Point(401, -10380),
                new Point(307, -10396),
            }
            },
            { 30, new List<Point>
            {
                new Point(419, -10508),
                new Point(292, -10604),
                new Point(147, -10644),
                new Point(15, -10636),
                new Point(148, -10764),
                new Point(450, -10676),
            }
            },
            { 31, new List<Point>
            {
                new Point(316, -10874),
                new Point(169, -10946),
                new Point(10, -10858),
                new Point(274, -11002),
                new Point(172, -11090),
            }
            },
            { 32, new List<Point>
            {
                new Point(193, -11218),
                new Point(306, -11490),
            }
            },
            { 33, new List<Point>
            {
                new Point(202, -11618),
                new Point(351, -11578),
                new Point(109, -11730),
                new Point(259, -11794),
                new Point(363, -11738),
            }
            },
            { 34, new List<Point>
            {
                new Point(139, -11922),
                new Point(323, -11922),
                new Point(356, -12018),
                new Point(108, -12018),
                new Point(283, -12130),
                new Point(178, -12194),
            }
            },
            { 35, new List<Point>
            {
                new Point(297, -12282),
                new Point(447, -12378),
                new Point(449, -12474),
                new Point(264, -12514),
                new Point(267, -12410),
            }
            },
            { 36, new List<Point>
            {
                new Point(432, -12658),
                new Point(284, -12722),
                new Point(142, -12714),
                new Point(23, -12786),
                new Point(155, -12890),
                new Point(281, -12882),
            }
            },
            { 37, new List<Point>
            {
                new Point(440, -13026),
                new Point(406, -13258),
            }
            },
            { 38, new List<Point>
            {
                new Point(344, -13378),
                new Point(266, -13418),
                new Point(168, -13466),
                new Point(95, -13522),
                new Point(255, -13610),
            }
            },
            { 39, new List<Point>
            {
                new Point(449, -13722),
                new Point(313, -13794),
                new Point(180, -13818),
                new Point(122, -13770),
                new Point(134, -13970),
                new Point(318, -13922),
            }
            },
            { 40, new List<Point>
            {
                new Point(341, -14082),
                new Point(223, -14178),
                new Point(328, -14258),
                new Point(254, -14306),
                new Point(122, -14298),
            }
            },
            { 41, new List<Point>
            {
                new Point(112, -14442),
                new Point(242, -14490),
                new Point(346, -14546),
                new Point(226, -14610),
                new Point(342, -14690),
                new Point(168, -14626),
            }
            },
            { 42, new List<Point>
            {
                new Point(150, -14802),
                new Point(330, -15002),
            }
            },
        };
    }
}