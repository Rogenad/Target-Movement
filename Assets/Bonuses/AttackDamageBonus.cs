using UnityEngine;

namespace Bonuses
{
    public class AttackDamageBonus : Bonus
    {
        [SerializeField] 
        private int _amountOfDamageToAdd;
        [SerializeField] 
        private Sprite _bonusIcon;
        
        private void Awake()
        {
            BonusList.Add(this);
        }
        
        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("AttackDamage"); 
            _player.MaxDamage += _amountOfDamageToAdd;
            _player.MinDamage += _amountOfDamageToAdd;
        }
        
        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return _bonusIcon;
        }
    }
}
