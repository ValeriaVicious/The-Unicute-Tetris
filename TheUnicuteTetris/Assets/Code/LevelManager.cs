using UnityEngine;
using UnityEngine.UI;


namespace TheUnicuteTetris
{
    internal sealed class LevelManager : MonoBehaviour
    {
        #region Fields

        private static int _level;
        private static int _highscoreToTheNextLevel = 1000;
        private Text _levelText;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _levelText = GetComponent<Text>();
        }

        private void Start()
        {
            _level = 1;
        }

        private void Update()
        {
            UpdateTheLevel();
        }

        #endregion


        #region Methods

        private void UpdateTheLevel()
        {
            if(ScoreManager.Score >= _level * _highscoreToTheNextLevel)
            {
                _level += 1;
            }
            _levelText.text = _level.ToString();
        }

        #endregion
    }
}
