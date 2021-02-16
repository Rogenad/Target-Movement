using UnityEngine;

namespace Bonuses
{
    public class HealthRestoreBonus : Bonus
    {
        [SerializeField] private int amountHealthOfToRestore;
        [SerializeField] private Sprite bonusIcon;
        public override void BonusPayLoad()
        {
            base.BonusPayLoad();
            Debug.Log("HealthRestore");
            Player.CurrentHealth += amountHealthOfToRestore;
        }
        public override Sprite SetBonusIcon()
        {
            base.SetBonusIcon();
            return bonusIcon;
        }
    }
}
