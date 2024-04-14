using KingVsFly.Util;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace KingVsFly.GameInfo
{
    public class GhostBabeGameInfo
    {
        /// <summary>
        /// Contains the area bounds of an area in the ghost babe part of the game.
        /// </summary>
        public static readonly List<AreaBounds> areas = new List<AreaBounds>
        {
            // new AreaBounds(157, 158),// Philosophers Forest
            new AreaBounds(102, 106),   // Bog
            new AreaBounds(109, 114),   // Moulding Manor
            new AreaBounds(116, 122),   // Bugstalk
            new AreaBounds(124, 129),   // House Of Nine Lives
            new AreaBounds(130, 138),   // Phantom Tower
            new AreaBounds(139, 146),   // Halted Ruin
            new AreaBounds(147, 153),   // Tower Of Antumbra
        };

        /// <summary>
        /// The final screen of the ghost babe.
        /// </summary>
        public static readonly int finalScreen = 153;

        /// <summary>
        /// Contains the list of points that the fly can fly to on each screen of ghost babe.
        /// The first point should also be the start position of the king when entering the screen for the first time.
        /// The positions are in global space and need to be converted to screen space before being rendered.
        /// </summary>
        public static readonly Dictionary<int, List<Point>> positions = new Dictionary<int, List<Point>>
        {
            { 102, new List<Point>
            {
                new Point(176, -36402),
                new Point(261, -36450),
                new Point(379, -36458),
                new Point(121, -36554),
                new Point(231, -36578),
                new Point(398, -36618),
                new Point(242, -36666),
                new Point(166, -36690),
            }
            },
            { 103, new List<Point>
            {
                new Point(32, -36802),
                new Point(264, -36834),
                new Point(339, -36954),
                new Point(227, -37002),
                new Point(80, -36946),
            }
            },
            { 104, new List<Point>
            {
                new Point(53, -37130),
                new Point(227, -37218),
                new Point(337, -37234),
                new Point(334, -37378),
                new Point(237, -37402),
                new Point(22, -37330),
            }
            },
            { 105, new List<Point>
            {
                new Point(362, -37514),
                new Point(349, -37610),
                new Point(239, -37602),
                new Point(240, -37690),
                new Point(86, -37618),
                new Point(86, -37754),
            }
            },
            { 106, new List<Point>
            {
                new Point(251, -37882),
                new Point(447, -37938),
                new Point(264, -38018),
                new Point(393, -38090),
            }
            },
            { 109, new List<Point>
            {
                new Point(38, -38938),
                new Point(310, -38970),
                new Point(346, -39042),
                new Point(140, -39178),
                new Point(208, -39074),
                new Point(385, -39146),
            }
            },
            { 110, new List<Point>
            {
                new Point(293, -39298),
                new Point(143, -39394),
                new Point(84, -39354),
                new Point(294, -39466),
                new Point(157, -39514),
            }
            },
            { 111, new List<Point>
            {
                new Point(298, -39658),
                new Point(356, -39634),
                new Point(91, -39682),
                new Point(179, -39690),
                new Point(317, -39810),
                new Point(222, -39898),
                new Point(378, -39898),
            }
            },
            { 112, new List<Point>
            {
                new Point(196, -40026),
                new Point(324, -40106),
                new Point(171, -40098),
                new Point(11, -40170),
                new Point(123, -40146),
                new Point(173, -40202),
                new Point(131, -40274),
                new Point(164, -40274),
                new Point(307, -40218),
                new Point(410, -40266),
            }
            },
            { 113, new List<Point>
            {
                new Point(244, -40362),
                new Point(124, -40362),
                new Point(85, -40490),
                new Point(218, -40610),
                new Point(83, -40634),
            }
            },
            { 114, new List<Point>
            {
                new Point(141, -40730),
                new Point(285, -40802),
                new Point(130, -40866),
                new Point(310, -40874),
                new Point(85, -40994),
            }
            },
            { 115, new List<Point>
            {
                new Point(319, -41082),
                new Point(285, -41218),
                new Point(180, -41258),
                new Point(146, -41186),
                new Point(45, -41306),
            }
            },
            { 116, new List<Point>
            {
                new Point(147, -41442),
                new Point(33, -41522),
                new Point(209, -41554),
                new Point(339, -41666),
                new Point(151, -41690),
                new Point(32, -41690),
            }
            },
            { 117, new List<Point>
            {
                new Point(123, -41826),
                new Point(343, -41802),
                new Point(130, -41970),
                new Point(351, -41914),
                new Point(397, -42090),
                new Point(327, -42058),
                new Point(57, -42098),
            }
            },
            { 118, new List<Point>
            {
                new Point(267, -42242),
                new Point(304, -42274),
                new Point(377, -42282),
                new Point(452, -42346),
                new Point(167, -42338),
                new Point(287, -42426),
            }
            },
            { 119, new List<Point>
            {
                new Point(182, -42522),
                new Point(376, -42562),
                new Point(194, -42626),
                new Point(355, -42666),
                new Point(169, -42690),
                new Point(237, -42754),
                new Point(78, -42786),
            }
            },
            { 120, new List<Point>
            {
                new Point(206, -42898),
                new Point(377, -42898),
                new Point(322, -42938),
                new Point(190, -43114),
                new Point(72, -43106),
                new Point(42, -43146),
            }
            },
            { 121, new List<Point>
            {
                new Point(166, -43290),
                new Point(291, -43322),
                new Point(302, -43362),
                new Point(179, -43410),
                new Point(142, -43458),
                new Point(325, -43450),
                new Point(149, -43538),
            }
            },
            { 122, new List<Point>
            {
                new Point(290, -43634),
                new Point(436, -43762),
                new Point(222, -43818),
            }
            },
            { 124, new List<Point>
            {
                new Point(361, -44330),
                new Point(209, -44330),
                new Point(154, -44402),
                new Point(410, -44402),
                new Point(219, -44466),
                new Point(157, -44538),
                new Point(364, -44514),
                new Point(406, -44538),
                new Point(281, -44602),
            }
            },
            { 125, new List<Point>
            {
                new Point(432, -44746),
                new Point(363, -44674),
                new Point(204, -44674),
                new Point(137, -44746),
                new Point(339, -44794),
                new Point(242, -44834),
                new Point(108, -44930),
                new Point(221, -44978),
                new Point(333, -44938),
            }
            },
            { 126, new List<Point>
            {
                new Point(200, -45090),
                new Point(159, -45138),
                new Point(233, -45042),
                new Point(338, -45106),
                new Point(250, -45202),
                new Point(118, -45226),
                new Point(386, -45226),
                new Point(277, -45306),
            }
            },
            { 127, new List<Point>
            {
                new Point(129, -45434),
                new Point(244, -45490),
                new Point(148, -45522),
                new Point(300, -45594),
                new Point(141, -45610),
                new Point(370, -45698),
                new Point(358, -45538),
                new Point(427, -45634),
            }
            },
            { 128, new List<Point>
            {
                new Point(188, -45810),
                new Point(325, -45874),
                new Point(185, -45930),
                new Point(305, -46010),
            }
            },
            { 129, new List<Point>
            {
                new Point(148, -46130),
                new Point(292, -46194),
                new Point(441, -46210),
                new Point(256, -46322),
                new Point(449, -46378),
            }
            },
            { 130, new List<Point>
            {
                new Point(353, -46522),
                new Point(108, -46634),
                new Point(388, -46674),
                new Point(161, -46762),
            }
            },
            { 131, new List<Point>
            {
                new Point(310, -46906),
                new Point(168, -46874),
                new Point(318, -46954),
                new Point(178, -47018),
                new Point(315, -47082),
                new Point(168, -47066),
            }
            },
            { 132, new List<Point>
            {
                new Point(170, -47226),
                new Point(276, -47274),
                new Point(144, -47298),
                new Point(295, -47338),
                new Point(360, -47338),
                new Point(170, -47410),
                new Point(286, -47450),
            }
            },
            { 133, new List<Point>
            {
                new Point(186, -47570),
                new Point(294, -47650),
                new Point(138, -47634),
                new Point(26, -47698),
                new Point(141, -47762),
                new Point(275, -47770),
                new Point(131, -47850),
            }
            },
            { 134, new List<Point>
            {
                new Point(234, -47946),
                new Point(120, -47946),
                new Point(289, -48034),
                new Point(417, -48034),
                new Point(238, -48146),
                new Point(112, -48066),
            }
            },
            { 135, new List<Point>
            {
                new Point(119, -48290),
                new Point(247, -48386),
                new Point(333, -48410),
                new Point(116, -48498),
            }
            },
            { 136, new List<Point>
            {
                new Point(268, -48642),
                new Point(366, -48706),
                new Point(435, -48770),
                new Point(270, -48770),
                new Point(144, -48834),
                new Point(325, -48890),
            }
            },
            { 137, new List<Point>
            {
                new Point(144, -49002),
                new Point(48, -49026),
                new Point(49, -49170),
                new Point(376, -49202),
            }
            },
            { 138, new List<Point>
            {
                new Point(449, -49362),
                new Point(390, -49490),
                new Point(441, -49562),
                new Point(323, -49546),
                new Point(292, -49586),
                new Point(166, -49626),
                new Point(34, -49674),
            }
            },
            { 139, new List<Point>
            {
                new Point(213, -49794),
                new Point(383, -49858),
                new Point(448, -49970),
                new Point(273, -49954),
                new Point(142, -50002),
            }
            },
            { 140, new List<Point>
            {
                new Point(29, -50130),
                new Point(197, -50210),
                new Point(313, -50298),
                new Point(454, -50378),
                new Point(364, -50178),
            }
            },
            { 141, new List<Point>
            {
                new Point(297, -50514),
                new Point(172, -50586),
                new Point(58, -50674),
                new Point(195, -50746),
            }
            },
            { 142, new List<Point>
            {
                new Point(302, -50898),
                new Point(434, -50818),
                new Point(331, -50914),
                new Point(176, -50938),
                new Point(30, -51082),
            }
            },
            { 143, new List<Point>
            {
                new Point(171, -51234),
                new Point(314, -51218),
                new Point(329, -51346),
                new Point(158, -51418),
                new Point(37, -51394),
            }
            },
            { 144, new List<Point>
            {
                new Point(28, -51562),
                new Point(200, -51658),
                new Point(324, -51626),
                new Point(449, -51714),
                new Point(181, -51810),
                new Point(261, -51818),
                new Point(325, -51786),
            }
            },
            { 145, new List<Point>
            {
                new Point(38, -51954),
                new Point(152, -52074),
                new Point(286, -52034),
                new Point(253, -52130),
                new Point(380, -52186),
            }
            },
            { 146, new List<Point>
            {
                new Point(179, -52274),
                new Point(60, -52338),
                new Point(234, -52402),
                new Point(363, -52434),
                new Point(212, -52490),
                new Point(140, -52498),
                new Point(36, -52498),
            }
            },
            { 147, new List<Point>
            {
                new Point(305, -52626),
                new Point(444, -52642),
                new Point(320, -52777),
                new Point(132, -52777),
                new Point(68, -52850),
            }
            },
            { 148, new List<Point>
            {
                new Point(216, -52968),
                new Point(385, -53010),
                new Point(249, -53105),
                new Point(386, -53138),
                new Point(235, -53233),
                new Point(136, -53234),
            }
            },
            { 149, new List<Point>
            {
                new Point(381, -53346),
                new Point(314, -53345),
                new Point(248, -53449),
                new Point(133, -53498),
                new Point(248, -53577),
                new Point(326, -53601),
                new Point(398, -53602),
            }
            },
            { 150, new List<Point>
            {
                new Point(289, -53705),
                new Point(120, -53705),
                new Point(346, -53777),
                new Point(200, -53825),
                new Point(107, -53873),
                new Point(223, -53921),
                new Point(353, -53937),
                new Point(431, -53970),
            }
            },
            { 151, new List<Point>
            {
                new Point(296, -54049),
                new Point(70, -54130),
                new Point(220, -54177),
                new Point(358, -54250),
                new Point(205, -54305),
                new Point(123, -54322),
            }
            },
            { 152, new List<Point>
            {
                new Point(261, -54449),
                new Point(159, -54522),
                new Point(308, -54617),
                new Point(163, -54642),
            }
            },
            { 153, new List<Point>
            {
                new Point(302, -35770),
                new Point(250, -54962),
            }
            },
            { 157, new List<Point>
            {
                new Point(257, -56258),
                new Point(348, -56242),
                new Point(354, -56346),
                new Point(264, -56434),
                new Point(123, -56338),
                new Point(95, -56434),
                new Point(361, -56450),
            }
            },
            { 158, new List<Point>
            {
                new Point(129, -56570),
                new Point(79, -56602),
                new Point(388, -56594),
                new Point(289, -56642),
                new Point(185, -56690),
                new Point(91, -56738),
                new Point(374, -56714),
                new Point(198, -56834),
                new Point(411, -56778),
            }
            },
        };
    }
}