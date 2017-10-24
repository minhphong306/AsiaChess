using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsiaChess {
    public static class Cons
    {
        public const int  MARGIN = 40;
        public const int CELL_SIZE = 100;
        public const int MAX_COL = 4;
        public const int MAX_ROW = 4;
        public const int SMALL_DIAMON_WIDTH = 2;
        public const int SMALL_DIAMON_HEIGH = 2;
        public const int BOARD_WIDTH = 5;
        public const int BOARD_HEIGH = 7;
        public const int CHESS_SIZE = 50;

        public static Color CHESS_COLOR = Color.Blue;
        public static Color BOSS_COLOR = Color.Red;
        public static Color EMPTY_COLOR = Color.Transparent;
        public static Color SELECTED_COLOR = Color.Purple;
        public static Color HINT_COLOR = Color.Yellow;
        public static Color HINT_EAT_COLOR = Color.Black;
        public static Color JUST_MOVE_COLOR = Color.Green;

        public const int EMPTY_VALUE = 0;
        public const int BOSS_VALUE = 2;
        public const int CHESS_VALUE = 1;
        public const int INVALID_VALUE = -1;

        public const int GM_TWO_PLAYER = 1;
        public const int GM_AI = 2;

        public const int SHOW_HINT = 1;
        public const int REMOVE_HINT = 2;

        public const int CHESS_TURN = 1;
        public const int BOSS_TURN = 2;

        public static int[,] map = {
                                      {1, 1, 1, 1, 1 },
                                      {1, 1, 0, 1, 1 },
                                      {1, 0, 0, 0, 1 },
                                      {1, 1, 0, 1, 1 },
                                      {1, 1, 0, 1, 1 },
                                      {-1, 2, 0, 2, -1 },
                                      {-1,-1, 2,-1, -1 },
                                    };

        public static int[,] map2 = {
                                      {CHESS_VALUE  , CHESS_VALUE   , CHESS_VALUE   , CHESS_VALUE   , CHESS_VALUE },
                                      {CHESS_VALUE  , CHESS_VALUE   , EMPTY_VALUE   , CHESS_VALUE   , CHESS_VALUE },
                                      {CHESS_VALUE  , EMPTY_VALUE   , EMPTY_VALUE   , EMPTY_VALUE   , CHESS_VALUE },
                                      {CHESS_VALUE  , CHESS_VALUE   , EMPTY_VALUE   , CHESS_VALUE   , CHESS_VALUE },
                                      {CHESS_VALUE  , CHESS_VALUE   , EMPTY_VALUE   , CHESS_VALUE   , CHESS_VALUE },
                                      {INVALID_VALUE, BOSS_VALUE    , EMPTY_VALUE   , BOSS_VALUE    , INVALID_VALUE },
                                      {INVALID_VALUE,INVALID_VALUE  , BOSS_VALUE    ,INVALID_VALUE  , INVALID_VALUE },
                                    };
    }
}
