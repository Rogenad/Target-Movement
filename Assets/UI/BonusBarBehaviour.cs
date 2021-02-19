using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BonusBarBehaviour : MonoBehaviour
    {
        public void ShowBonusBar()
        {
            UIManager.ShowMenu(gameObject);
        }

        public void CloseBonusBar()
        {
            var buttons = gameObject.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                button.onClick.RemoveAllListeners();
            }
            UIManager.CloseMenu(gameObject);
        }
    }
}
