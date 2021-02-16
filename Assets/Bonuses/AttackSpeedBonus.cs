using UnityEngine;

namespace Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("shotSpeed");
        [SerializeField] private Animator attackSpeedController;
        [SerializeField] private Sprite bonusIcon;

        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("AttackSpeed");
            var currentAttackSpeedMultiplier = attackSpeedController.GetFloat(AttackSpeedMultiplier);
            attackSpeedController.SetFloat(AttackSpeedMultiplier, currentAttackSpeedMultiplier + 1);
        }

        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return bonusIcon;
        }
    }
}
