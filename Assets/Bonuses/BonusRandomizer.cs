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
            for (var i = 0; i < 3; i++)
            {
                var randomBonus = bonuses[Random.Range(0, bonuses.Count)];
                _buttons[i].onClick.AddListener(randomBonus.BonusPayLoad);
                _buttons[i].gameObject.GetComponentInChildren<Image>().sprite = randomBonus.SetBonusIcon();
            }
        }
    }
}
