using UnityEngine;

namespace Bonuses
{
    public class HealthRestoreBonus : Bonus
    {
        [SerializeField] 
        private int _amountHealthOfToRestore;
        [SerializeField] 
        private Sprite _bonusIcon;
        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("HealthRestore");
            _player.CurrentHealth += _amountHealthOfToRestore;
        }
        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return _bonusIcon;
        }
    }
}
