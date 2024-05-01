using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunner.Shared
{
    public class ApplicationManager : BaseMonoSingletonGeneric<ApplicationManager>
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
