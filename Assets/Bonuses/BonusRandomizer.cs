using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Bonuses
{
    public class BonusRandomizer : MonoBehaviour
    {
        [SerializeField] private List<Bonus> bonuses = new List<Bonus>();
        [SerializeField] private List<Button> buttons = new List<Button>();

        public void GetRandomBonuses()
        {
            for (var i = 0; i < 3; i++)
            {
                var randomBonus = bonuses[Random.Range(0, bonuses.Count)];
                buttons[i].onClick.AddListener(randomBonus.BonusPayLoad);
                buttons[i].gameObject.GetComponentInChildren<Image>().sprite = randomBonus.SetBonusIcon();
            }
        }
    }
}
