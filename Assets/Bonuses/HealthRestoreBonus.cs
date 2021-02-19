using UnityEngine;

namespace Bonuses
{
    public class HealthRestoreBonus : Bonus
    {
        [SerializeField] 
        private int _amountHealthOfToRestore;
        [SerializeField] 
        private Sprite _bonusIcon;
        
        private void Awake()
        {
            BonusList.Add(this);
        }
        
        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("HealthRestore");
            _player.CurrentHealth += _amountHealthOfToRestore;
        }
        
        public override Sprite SetBonusIcon()
        {
            return _bonusIcon;
        }
    }
}
