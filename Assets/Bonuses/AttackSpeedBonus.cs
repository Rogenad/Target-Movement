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

        private void Awake()
        {
            BonusList.Add(this);
        }

        public override void ApplyBonus()
        {
            var currentAttackSpeedMultiplier = _attackSpeedController.GetFloat(AttackSpeedMultiplier);
            _attackSpeedController.SetFloat(AttackSpeedMultiplier, currentAttackSpeedMultiplier + 1);
        }

        public override Sprite SetBonusIcon()
        {
            return _bonusIcon;
        }
    }
}
