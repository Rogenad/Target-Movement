using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text killedEnemiesCounter;
        private StringBuilder _killedEnemiesText = new StringBuilder("You killed 0/50 vampires");
        private int _killedEnemiesAmount;

        public static void ShowMenu(GameObject menu)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }

        public static void CloseMenu(GameObject menu)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }

        public static void ExitGame()
        {
            Application.Quit();
        }

        public void KilledEnemiesTextEdit()
        {
            _killedEnemiesText.Replace($"{_killedEnemiesAmount}", $"{_killedEnemiesAmount++}");
            killedEnemiesCounter.text = _killedEnemiesText.ToString();
        }

        public static void RestartGame()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
    }
}
