using UnityEngine;
using UnityEngine.SceneManagement;


namespace TheUnicuteTetris
{
    internal sealed class MainMenu : MonoBehaviour
    {
        #region Methods

        public void StartButton()
        {
            SceneManager.LoadScene(Constants.GameScene);
        }

        public void AboutButton()
        {
            SceneManager.LoadScene(Constants.AboutScene);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(Constants.MainMenuScene);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        #endregion
    }
}