using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Bonuses
{
    public class BonusRandomizer : MonoBehaviour
    {
        [SerializeField] 
        private List<Button> _buttons = new List<Button>();

        private void OnEnable()
        {
            GetRandomBonuses();
        }

        private void GetRandomBonuses()
        {
            var bonuses = Bonus.BonusList;
            foreach (var button in _buttons)
            {
                var randomBonus = bonuses[Random.Range(0, bonuses.Count)];
                button.onClick.AddListener(randomBonus.ApplyBonus);
                button.GetComponentInChildren<BonusButton>().BonusIcon = randomBonus.SetBonusIcon();
            }
        }
    }
}
