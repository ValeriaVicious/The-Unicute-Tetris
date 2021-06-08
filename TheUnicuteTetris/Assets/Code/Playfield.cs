using UnityEngine;


namespace TheUnicuteTetris
{
    internal sealed class Playfield : MonoBehaviour
    {
        #region Fields

        private static int _pointForFullRow = 10;

        public static int Width = 10;
        public static int Height = 20;

        public static Transform[,] Grid = new Transform[Width, Height];

        #endregion


        #region Methods

        public static Vector2 RoundAVector(Vector2 vector)
        {
            return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
        }

        public static bool IsInsideBorder(Vector2 position)
        {
            return (int)position.x >= 0 &&
                (int)position.x < Width &&
                (int)position.y >= 0;
        }

        public static bool IsRowFull(int y)
        {
            for (int x = 0; x < Width; ++x)
            {
                if (Grid[x, y] == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static void DeleteRow(int y)
        {
            for (int x = 0; x < Width; ++x)
            {
                Destroy(Grid[x, y].gameObject);
                Grid[x, y] = null;
            }
        }

        public static void DecreaseRow(int y)
        {
            for (int x = 0; x < Width; ++x)
            {
                if (Grid[x, y] != null)
                {
                    Grid[x, y - 1] = Grid[x, y];
                    Grid[x, y] = null;
                    Grid[x, y - 1].position += new Vector3(0.0f, -1.0f, 0.0f);
                }
            }
        }

        public static void DecreaseRowsAbove(int y)
        {
            for (int i = y; i < Height; ++i)
            {
                DecreaseRow(i);
            }
        }

        public static void DeleteFullRows()
        {
            for (int y = 0; y < Height; ++y)
            {
                if (IsRowFull(y))
                {
                    DeleteRow(y);
                    DecreaseRowsAbove(y + 1);
                    ScoreManager.Score += (Height - y) * _pointForFullRow;
                    --y;
                }
            }
        }

        #endregion
    }
}