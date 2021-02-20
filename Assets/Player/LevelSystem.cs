using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Player
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onLevelUp;
        [SerializeField]
        private Image _experienceBar;
        [SerializeField]
        private int _experienceGainedPerUnit;
        [SerializeField]
        private int _experienceToLevelUp;
        private int _currentExperience;

        private void Awake()
        {
            UpdateExperienceBar();
        }
        
        public void AddExperience()
        {
            _currentExperience += _experienceGainedPerUnit;
            if (_currentExperience >= _experienceToLevelUp)
            {
                _currentExperience = 0;
                _experienceToLevelUp += 100;
                _onLevelUp.Invoke();
            }
            UpdateExperienceBar();
        }

        private void UpdateExperienceBar()
        {
            ProgressBar.SetProgress(out var experienceBarScale, _currentExperience, _experienceToLevelUp);
            _experienceBar.transform.localScale = experienceBarScale;
        }
    }
}

