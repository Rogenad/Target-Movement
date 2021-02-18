using UnityEngine;

namespace Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("shotSpeed");
        [SerializeField] 
        private Animator _attackSpeedController;
        [SerializeField] 
        private Sprite _bonusIcon;

        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("AttackSpeed");
            var currentAttackSpeedMultiplier = _attackSpeedController.GetFloat(AttackSpeedMultiplier);
            _attackSpeedController.SetFloat(AttackSpeedMultiplier, currentAttackSpeedMultiplier + 1);
        }

        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return _bonusIcon;
        }
    }
}
