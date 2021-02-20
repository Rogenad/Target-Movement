using UnityEngine;
using UnityEngine.UI;

namespace Bonuses
{
    public class BonusButton : MonoBehaviour
    {
        [SerializeField]
        private Image _bonusIcon;
        
        public Sprite BonusIcon { 
            set => _bonusIcon.sprite = value;
        }
    }
}
