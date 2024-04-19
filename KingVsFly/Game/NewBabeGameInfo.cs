using KingVsFly.Util;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace KingVsFly.GameInfo
{
    public class NewBabeGameInfo
    {
        /// <summary>
        /// Contains the area bounds of an area in the new babe part of the game.
        /// </summary>
        public static readonly List<AreaBounds> areas = new List<AreaBounds>
        {
            new AreaBounds(46, 51), // Brightcrown Woods
            new AreaBounds(52, 58), // Colossal Dungeon
            new AreaBounds(59, 62), // False Kings Castle
            new AreaBounds(63, 66), // Underburg p1
            new AreaBounds(65, 69), // Underburg p2
            new AreaBounds(70, 76), // Lost Frontier
            new AreaBounds(77, 82), // Hidden Kingdom
            new AreaBounds(83, 88), // Black Sanctum
            new AreaBounds(89, 93), // Deep Ruin
            new AreaBounds(94, 99), // The Dark Tower
        };

        /// <summary>
        /// The final screen of the new babe.
        /// </summary>
        public static readonly int finalScreen = 99;

        /// <summary>
        /// Contains the list of points that the fly can fly to on each screen of new babe.
        /// The first point should also be the start position of the king when entering the screen for the first time.
        /// The positions are in global space and need to be converted to screen space before being rendered.
        /// </summary>
        public static readonly Dictionary<int, List<Point>> positions = new Dictionary<int, List<Point>>
        {
            { 46, new List<Point>
            {
                new Point(231, -16258),
                new Point(206, -16556),
            }
            },
            { 47, new List<Point>
            {
                new Point(153, -16660),
                new Point(46, -16748),
                new Point(159, -16748),
                new Point(319, -16852),
                new Point(441, -16876),
                new Point(231, -16764),
            }
            },
            { 48, new List<Point>
            {
                new Point(303, -17012),
                new Point(120, -17012),
                new Point(42, -17060),
                new Point(256, -17106),
                new Point(292, -17196),
                new Point(434, -17220),
            }
            },
            { 49, new List<Point>
            {
                new Point(327, -17348),
                new Point(442, -17460),
                new Point(286, -17460),
                new Point(163, -17516),
                new Point(29, -17548),
                new Point(132, -17548),
                new Point(305, -17588),
            }
            },
            { 50, new List<Point>
            {
                new Point(131, -17724),
                new Point(317, -17764),
                new Point(26, -17724),
                new Point(127, -17836),
                new Point(333, -17884),
                new Point(446, -17844),
                new Point(193, -17940),
                new Point(39, -17908),
            }
            },
            { 51, new List<Point>
            {
                new Point(35, -18084),
                new Point(200, -18108),
                new Point(24, -18236),
                new Point(169, -18244),
                new Point(291, -18276),
                new Point(424, -18306),
            }
            },
            { 52, new List<Point>
            {
                new Point(295, -18426),
                new Point(434, -18490),
                new Point(236, -18530),
                new Point(383, -18514),
                new Point(110, -18602),
                new Point(20, -18690),
            }
            },
            { 53, new List<Point>
            {
                new Point(76, -18754),
                new Point(20, -18882),
                new Point(169, -18874),
                new Point(303, -18794),
                new Point(295, -18914),
                new Point(403, -18914),
                new Point(392, -19010),
            }
            },
            { 54, new List<Point>
            {
                new Point(427, -19146),
                new Point(327, -19234),
                new Point(272, -19210),
                new Point(75, -19282),
                new Point(242, -19322),
                new Point(425, -19410),
            }
            },
            { 55, new List<Point>
            {
                new Point(327, -19482),
                new Point(435, -19482),
                new Point(250, -19578),
                new Point(441, -19602),
                new Point(289, -19698),
                new Point(424, -19762),
            }
            },
            { 56, new List<Point>
            {
                new Point(398, -19882),
                new Point(371, -19970),
                new Point(447, -20010),
                new Point(264, -19970),
                new Point(160, -19954),
                new Point(71, -19970),
                new Point(70, -20082),
                new Point(221, -20082),
            }
            },
            { 57, new List<Point>
            {
                new Point(70, -20218),
                new Point(264, -20314),
                new Point(428, -20362),
                new Point(300, -20442),
            }
            },
            { 58, new List<Point>
            {
                new Point(219, -20562),
                new Point(136, -20586),
                new Point(320, -20586),
                new Point(122, -20666),
                new Point(230, -20682),
                new Point(316, -20698),
                new Point(139, -20810),
                new Point(243, -20778),
                new Point(314, -20778),
            }
            },
            { 59, new List<Point>
            {
                new Point(105, -20932),
                new Point(313, -20932),
                new Point(334, -20994),
                new Point(83, -21066),
                new Point(13, -21098),
                new Point(16, -21202),
                new Point(96, -21226),
                new Point(273, -21210),
            }
            },
            { 60, new List<Point>
            {
                new Point(240, -21370),
                new Point(322, -21370),
                new Point(171, -21466),
                new Point(332, -21466),
                new Point(214, -21562),
                new Point(70, -21562),
                new Point(24, -21466),
                new Point(29, -21370),
            }
            },
            { 61, new List<Point>
            {
                new Point(239, -21690),
                new Point(29, -21674),
                new Point(352, -21770),
                new Point(229, -21842),
                new Point(352, -21914),
                new Point(8, -21866),
            }
            },
            { 62, new List<Point>
            {
                new Point(183, -22042),
                new Point(349, -22162),
                new Point(416, -22178),
                new Point(230, -22250),
            }
            },
            { 63, new List<Point>
            {
                new Point(421, -22362),
                new Point(340, -22514),
                new Point(414, -22570),
                new Point(298, -22514),
                new Point(174, -22602),
                new Point(103, -22602),
            }
            },
            { 64, new List<Point>
            {
                new Point(401, -22746),
                new Point(435, -22794),
                new Point(251, -22890),
                new Point(265, -23010),
                new Point(411, -22930),
            }
            },
            { 65, new List<Point>
            {
                new Point(109, -23082),
                new Point(166, -23378),
                new Point(238, -23322),
                new Point(390, -23314),
            }
            },
            { 66, new List<Point>
            {
                new Point(48, -23474),
                new Point(22, -23578),
                new Point(247, -23210),
                new Point(358, -23210),
            }
            },
            { 67, new List<Point>
            {
                new Point(390, -23810),
                new Point(56, -23834),
                new Point(55, -23962),
                new Point(61, -24050),
                new Point(415, -23906),
                new Point(395, -24018),
                new Point(392, -24106),
            }
            },
            { 68, new List<Point>
            {
                new Point(87, -24194),
                new Point(378, -24266),
                new Point(15, -24354),
                new Point(430, -24434),
            }
            },
            { 69, new List<Point>
            {
                new Point(34, -24522),
                new Point(8, -24586),
                new Point(18, -24770),
                new Point(76, -24770),
                new Point(227, -24770),
                new Point(381, -24770),
                new Point(416, -24642),
                new Point(235, -24642),
            }
            },
            { 70, new List<Point>
            {
                new Point(235, -24898),
                new Point(107, -24938),
                new Point(440, -24970),
                new Point(404, -25082),
                new Point(306, -25146),
            }
            },
            { 71, new List<Point>
            {
                new Point(418, -25274),
                new Point(30, -25458),
            }
            },
            { 72, new List<Point>
            {
                new Point(98, -25602),
                new Point(298, -25626),
                new Point(442, -25626),
                new Point(335, -25714),
                new Point(452, -25754),
                new Point(308, -25834),
                new Point(292, -25778),
                new Point(130, -25738),
                new Point(122, -25866),
            }
            },
            { 73, new List<Point>
            {
                new Point(296, -26002),
                new Point(146, -26098),
                new Point(24, -26058),
                new Point(313, -26082),
                new Point(426, -26154),
                new Point(314, -26202),
                new Point(171, -26242),
                new Point(51, -26194),
            }
            },
            { 74, new List<Point>
            {
                new Point(22, -26354),
                new Point(184, -26410),
                new Point(59, -26506),
                new Point(195, -26578),
                new Point(345, -26482),
            }
            },
            { 75, new List<Point>
            {
                new Point(363, -26714),
                new Point(164, -26730),
                new Point(11, -26818),
                new Point(192, -26874),
                new Point(316, -26946),
            }
            },
            { 76, new List<Point>
            {
                new Point(277, -27106),
                new Point(319, -27282),
            }
            },
            { 77, new List<Point>
            {
                new Point(326, -27402),
                new Point(368, -27666),
            }
            },
            { 78, new List<Point>
            {
                new Point(253, -27778),
                new Point(140, -27858),
                new Point(265, -27906),
                new Point(375, -27930),
                new Point(261, -28042),
            }
            },
            { 79, new List<Point>
            {
                new Point(186, -28122),
                new Point(342, -28138),
                new Point(360, -28218),
                new Point(241, -28330),
                new Point(361, -28402),
            }
            },
            { 80, new List<Point>
            {
                new Point(247, -28506),
                new Point(118, -28538),
                new Point(219, -28594),
                new Point(350, -28578),
                new Point(354, -28674),
                new Point(405, -28690),
                new Point(215, -28762),
                new Point(126, -28754),
            }
            },
            { 81, new List<Point>
            {
                new Point(247, -28842),
                new Point(168, -28930),
                new Point(355, -28930),
                new Point(437, -28994),
                new Point(356, -29034),
                new Point(170, -29082),
                new Point(97, -29130),
            }
            },
            { 82, new List<Point>
            {
                new Point(259, -29266),
                new Point(224, -29482),
            }
            },
            { 83, new List<Point>
            {
                new Point(222, -29578),
                new Point(123, -29578),
                new Point(281, -29674),
                new Point(376, -29730),
                new Point(180, -29818),
                new Point(86, -29834),
            }
            },
            { 84, new List<Point>
            {
                new Point(279, -29922),
                new Point(187, -29922),
                new Point(379, -29978),
                new Point(278, -30058),
                new Point(181, -30154),
                new Point(85, -30090),
                new Point(377, -30194),
            }
            },
            { 85, new List<Point>
            {
                new Point(187, -30298),
                new Point(90, -30346),
                new Point(185, -30450),
                new Point(275, -30434),
                new Point(374, -30538),
                new Point(86, -30538),
            }
            },
            { 86, new List<Point>
            {
                new Point(295, -30642),
                new Point(191, -30642),
                new Point(156, -30754),
                new Point(299, -30818),
                new Point(160, -30906),
                new Point(333, -30906),
            }
            },
            { 87, new List<Point>
            {
                new Point(27, -31034),
                new Point(220, -31090),
                new Point(435, -31034),
                new Point(416, -31178),
                new Point(442, -31234),
                new Point(47, -31178),
                new Point(23, -31234),
            }
            },
            { 88, new List<Point>
            {
                new Point(439, -31362),
                new Point(445, -31466),
                new Point(435, -31642),
                new Point(215, -31514),
                new Point(41, -31642),
                new Point(16, -31466),
                new Point(18, -31362),
            }
            },
            { 89, new List<Point>
            {
                new Point(157, -31786),
                new Point(288, -31922),
                new Point(408, -31922),
                new Point(74, -31962),
                new Point(218, -31978),
            }
            },
            { 90, new List<Point>
            {
                new Point(329, -32090),
                new Point(70, -32114),
                new Point(156, -32186),
                new Point(387, -32298),
                new Point(274, -32314),
                new Point(163, -32338),
                new Point(116, -32386),
            }
            },
            { 91, new List<Point>
            {
                new Point(340, -32450),
                new Point(419, -32602),
                new Point(437, -32658),
                new Point(271, -32634),
                new Point(175, -32666),
                new Point(76, -32698),
            }
            },
            { 92, new List<Point>
            {
                new Point(141, -32858),
                new Point(27, -32802),
                new Point(317, -32906),
                new Point(119, -32978),
                new Point(313, -33026),
                new Point(79, -33074),
            }
            },
            { 93, new List<Point>
            {
                new Point(109, -33210),
                new Point(244, -33274),
                new Point(336, -33322),
                new Point(394, -33354),
                new Point(148, -33426),
            }
            },
            { 94, new List<Point>
            {
                new Point(276, -33554),
                new Point(82, -33642),
                new Point(373, -33642),
                new Point(145, -33754),
                new Point(327, -33762),
            }
            },
            { 95, new List<Point>
            {
                new Point(322, -33882),
                new Point(181, -33962),
                new Point(319, -34018),
                new Point(396, -34050),
                new Point(246, -34122),
                new Point(105, -34122),
            }
            },
            { 96, new List<Point>
            {
                new Point(185, -34242),
                new Point(85, -34506),
                new Point(169, -34410),
                new Point(315, -34458),
                new Point(304, -34322),
                new Point(401, -34258),
                new Point(407, -34418),
                new Point(408, -34522),
            }
            },
            { 97, new List<Point>
            {
                new Point(219, -34626),
                new Point(338, -34714),
                new Point(389, -34754),
                new Point(406, -34882),
                new Point(159, -34794),
            }
            },
            { 98, new List<Point>
            {
                new Point(209, -34962),
                new Point(96, -35018),
                new Point(210, -35066),
                new Point(304, -35106),
                new Point(148, -35154),
                new Point(321, -35202),
            }
            },
            { 99, new List<Point>
            {
                new Point(131, -35314),
                new Point(150, -35522),
            }
            },
        };
    }
}
