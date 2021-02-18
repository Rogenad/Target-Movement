using UnityEngine;

namespace Bonuses
{
    public class Bonus : MonoBehaviour
    {
        protected PlayerController _player;

        public virtual void BonusPayLoad()
        {
            _player = PlayerController.Instance;
        }

        public virtual Sprite SetBonusIcon()
        {
            return null;
        }
    }
}
