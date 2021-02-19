using System.Collections.Generic;
using UnityEngine;

namespace Bonuses
{
    public class Bonus : MonoBehaviour
    {
        protected PlayerController _player;
        public static List<Bonus> BonusList { get; } = new List<Bonus>();

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
