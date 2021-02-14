using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject winMenu;
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject killedEnemiesCounter;

        private int _killedEnemiesCount;

        public void KilledEnemiesTextEdit()
        {
            _killedEnemiesCount++;
            var killedEnemies = new StringBuilder($"You killed {_killedEnemiesCount}/50 vampires");
            killedEnemiesCounter.GetComponentInChildren<Text>().text = killedEnemies.ToString();
            if (_killedEnemiesCount == 50)
            {
                ShowWinMenu();
            }
        }

        public void RestartGame()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            Time.timeScale = 1;
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }

        private void ShowWinMenu()
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);
        }
        
        public void ShowLoseMenu()
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
