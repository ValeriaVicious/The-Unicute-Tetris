using UnityEngine;
using UnityEngine.SceneManagement;


namespace TheUnicuteTetris
{
    internal sealed class PausePanel : MonoBehaviour
    {
        #region Fields

        public static bool IsPausedGame = false;
        [SerializeField] private GameObject _pauseMenuUI;

        #endregion


        #region UnityMethods

        private void Update()
        {
            CheckThePause();
        }

        #endregion


        #region Methods

        private void CheckThePause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPausedGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            IsPausedGame = true;
        }

        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            IsPausedGame = false;
        }

        public void RestartTheGame()
        {
            SceneManager.LoadScene(Constants.GameScene);
            Time.timeScale = 1.0f;
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(Constants.MainMenuScene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}
