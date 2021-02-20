using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BonusBar
{
    public class BonusBarBehaviour : MonoBehaviour
    {
        [SerializeField]
        private List<Button> _buttons = new List<Button>();
        public void ShowBonusBar()
        {
            UIManager.ShowMenu(gameObject);
        }

        public void CloseBonusBar()
        {
            foreach (var button in _buttons)
            {
                button.onClick.RemoveAllListeners();
            }
            UIManager.CloseMenu(gameObject);
        }
    }
}
