using UnityEngine;

namespace Bonuses
{
    public class Bonus : MonoBehaviour
    {
        protected PlayerController Player;

        public virtual void BonusPayLoad()
        {
            Player = PlayerController.Instance;
        }

        public virtual Sprite SetBonusIcon()
        {
            return null;
        }
    }
}
