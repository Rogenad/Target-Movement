using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private Text killedEnemiesCounter;

        public void ShowWinMenu()
        {
            UIManager.ShowMenu(gameObject);
        }
    }
}
