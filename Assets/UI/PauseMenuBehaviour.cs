using UnityEngine;

namespace UI
{
    public class PauseMenuBehaviour : MonoBehaviour
    {
        
        public void ShowPauseMenu()
        {
            UIManager.ShowMenu(gameObject);
        }
        
        public void ClosePauseMenu()
        {
            UIManager.CloseMenu(gameObject);
        }
    }
}
