using UnityEngine;
using UnityEngine.UI;


namespace TheUnicuteTetris
{
    internal sealed class ScoreManager : MonoBehaviour
    {
        #region Fields

        public static int Score;
        private Text _scoreText;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _scoreText = GetComponent<Text>();
        }

        private void Start()
        {
            Score = 0;
        }

        private void Update()
        {
            UpdateTheScoreText();
        }

        #endregion


        #region Methods

        private void UpdateTheScoreText()
        {
            _scoreText.text = string.Format($"{Score}");
        }

        #endregion
    }
}
