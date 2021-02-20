using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {

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

        public void RestartGame()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
    }
}
