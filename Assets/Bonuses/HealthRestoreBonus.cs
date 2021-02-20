using UnityEngine;

namespace Bonuses
{
    public class HealthRestoreBonus : Bonus
    {
        [SerializeField] 
        private int _amountHealthToRestore;
        [SerializeField] 
        private Sprite _bonusIcon;
        
        private void Awake()
        {
            BonusList.Add(this);
        }
        
        public override void ApplyBonus()
        {
            Player.CurrentHealth += _amountHealthToRestore;
        }
        
        public override Sprite SetBonusIcon()
        {
            return _bonusIcon;
        }
    }
}
