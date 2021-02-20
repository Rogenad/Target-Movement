using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        protected PlayerController Player;
        public static List<Bonus> BonusList { get; } = new List<Bonus>();

        public virtual void ApplyBonus()
        {
            Player = PlayerController.Instance;
        }

        public abstract Sprite SetBonusIcon();
    }
}
