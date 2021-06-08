using UnityEngine;
using UnityEngine.UI;


namespace TheUnicuteTetris
{
    internal sealed class HighscoreManager : MonoBehaviour
    {
        #region Fields

        public static int Highscore;
        private Text _scoreText;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _scoreText = GetComponent<Text>();
        }

        private void Start()
        {
            Highscore = 1000;
        }

        private void Update()
        {
            UpdateTheScoreText();
        }

        #endregion


        #region Methods

        public static void SetHighscore(int score)
        {
            if (score > Highscore)
            {
                Highscore = score;
            }
        }

        private void UpdateTheScoreText()
        {
            _scoreText.text = string.Format($"{Highscore}");
        }


        #endregion
    }
}
