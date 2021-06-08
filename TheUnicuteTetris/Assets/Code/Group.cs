using UnityEngine;
using UnityEngine.SceneManagement;


namespace TheUnicuteTetris
{
    internal sealed class Group : MonoBehaviour
    {
        #region Fields

        private float _angleRotation = 90.0f;
        private float _timeOfLastFallTetramino = 0.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            if (!IsValidGridPosition())
            {
                Destroy(gameObject);
                SceneManager.LoadScene(Constants.GameScene);
            }
        }

        private void Update()
        {
            InputManager();
        }

        #endregion


        #region Methods

        public bool IsValidGridPosition()
        {
            foreach (Transform subBlock in transform)
            {
                Vector2 vector = Playfield.RoundAVector(subBlock.position);
                if (!Playfield.IsInsideBorder(vector))
                {
                    return false;
                }
                if (Playfield.Grid[(int)vector.x, (int)vector.y] != null &&
                    Playfield.Grid[(int)vector.x, (int)vector.y].parent != transform)
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateGrid()
        {
            for (int y = 0; y < Playfield.Height; ++y)
            {
                for (int x = 0; x < Playfield.Width; ++x)
                {
                    if (Playfield.Grid[x, y] != null)
                    {
                        if (Playfield.Grid[x, y].parent == transform)
                        {
                            Playfield.Grid[x, y] = null;
                        }
                    }
                }
            }
            foreach (Transform item in transform)
            {
                Vector2 vector = Playfield.RoundAVector(item.position);
                Playfield.Grid[(int)vector.x, (int)vector.y] = item;
            }
        }

        private void InputManager()
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1.0f, 0.0f, 0.0f);

                if (IsValidGridPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(1.0f, 0.0f, 0.0f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1.0f, 0.0f, 0.0f);
                if (IsValidGridPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                transform.Rotate(0.0f, 0.0f, -_angleRotation);
                if (IsValidGridPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.Rotate(0.0f, 0.0f, _angleRotation);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                if (IsValidGridPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(0.0f, 1.0f, 0.0f);
                    Playfield.DeleteFullRows();
                    FindObjectOfType<SpawnerTetramino>().SpawnNextGroup();
                    enabled = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                Time.time - _timeOfLastFallTetramino >= 1)
            {
                transform.position += new Vector3(0.0f, -1.0f, 0.0f);

                if (IsValidGridPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(0.0f, 1.0f, 0.0f);
                    Playfield.DeleteFullRows();
                    FindObjectOfType<SpawnerTetramino>().SpawnNextGroup();
                    enabled = false;
                }
                _timeOfLastFallTetramino = Time.time;
            }

        }
    }

    #endregion
}

