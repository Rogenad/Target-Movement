using UnityEngine;

namespace Bonuses
{
    public class AttackDamageBonus : Bonus
    {
        [SerializeField] private int amountOfDamageToAdd;
        [SerializeField] private Sprite bonusIcon;
        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("AttackDamage");
            Player.MaxDamage += amountOfDamageToAdd;
            Player.MinDamage += amountOfDamageToAdd;
        }
        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return bonusIcon;
        }
    }
}
