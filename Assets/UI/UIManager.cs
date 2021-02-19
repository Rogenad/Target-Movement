using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onWinConditionTrue;
        [SerializeField] 
        private Text _killedEnemiesCounter;
        [SerializeField]
        private int _killsAmountToWin;
        private StringBuilder _killedEnemiesText = new StringBuilder();
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
            _killedEnemiesAmount++;
            _killedEnemiesText.Clear();
            _killedEnemiesText.Append($"You killed {_killedEnemiesAmount}/{_killsAmountToWin} vampires");
            _killedEnemiesCounter.text = _killedEnemiesText.ToString();
            if (_killedEnemiesAmount == _killsAmountToWin)
            {
                _onWinConditionTrue.Invoke();
            }
        }

        public void RestartGame()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
    }
}
