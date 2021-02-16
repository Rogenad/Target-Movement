using UnityEngine;

namespace UI
{
    public class LoseMenuBehaviour : MonoBehaviour
    {
        
        public void ShowLoseMenu()
        {
            UIManager.ShowMenu(gameObject);
        }
    }
}
