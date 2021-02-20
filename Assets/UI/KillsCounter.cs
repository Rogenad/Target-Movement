using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class KillsCounter : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onWinConditionTrue;
        [SerializeField] 
        private Text _killsCounterLabel;
        [SerializeField]
        private int _killsAmountToWin;
        private StringBuilder _killedEnemiesText = new StringBuilder();
        private int _killedEnemiesAmount;

        private void Awake()
        {
            SetText();
        }

        public void UpdateKillsCounter()
        {
            _killedEnemiesAmount++;
            if (_killedEnemiesAmount == _killsAmountToWin)
            {
                _onWinConditionTrue.Invoke();
            }
            SetText();
        }

        private void SetText()
        {
            _killedEnemiesText.Clear();
            _killedEnemiesText.Append($"You killed {_killedEnemiesAmount}/{_killsAmountToWin} vampires");
            _killsCounterLabel.text = _killedEnemiesText.ToString();
        }
    }
}
