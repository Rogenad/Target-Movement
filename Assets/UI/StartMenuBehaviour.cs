using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject startMenu;

        public void StartGame()
        {
            SceneManager.LoadScene("Level");
            startMenu.SetActive(false);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
