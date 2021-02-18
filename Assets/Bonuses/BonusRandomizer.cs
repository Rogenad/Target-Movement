using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Bonuses
{
    public class BonusRandomizer : MonoBehaviour
    {
        [SerializeField] 
        private List<Bonus> _bonuses = new List<Bonus>();
        [SerializeField] 
        private List<Button> _buttons = new List<Button>();

        public void GetRandomBonuses()
        {
            for (var i = 0; i < 3; i++)
            {
                var randomBonus = _bonuses[Random.Range(0, _bonuses.Count)];
                _buttons[i].onClick.AddListener(randomBonus.BonusPayLoad);
                _buttons[i].gameObject.GetComponentInChildren<Image>().sprite = randomBonus.SetBonusIcon();
            }
        }
    }
}
