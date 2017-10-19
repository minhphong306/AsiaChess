using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsiaChess {
    public static class Cons
    {
        public static int MARGIN = 40;
        public static int CELL_SIZE = 100;
        public static int MAX_COL = 4;
        public static int MAX_ROW = 4;
        public static int SMALL_DIAMON_WIDTH = 2;
        public static int SMALL_DIAMON_HEIGH = 2;

        public static int CHESS_SIZE = 50;

        public static int EMPTY_VALUE = 0;
        public static int BOSS_VALUE = 2;
        public static int CHESS_VALUE = 1;
        public static int INVALID_VALUE = -1;

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
