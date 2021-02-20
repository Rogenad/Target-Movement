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
        
        public override void ApplyBonus()
        {
            base.ApplyBonus();
            Player.MaxDamage += _amountOfDamageToAdd;
            Player.MinDamage += _amountOfDamageToAdd;
        }
        
        public override Sprite SetBonusIcon()
        {
            return _bonusIcon;
        }
    }
}
