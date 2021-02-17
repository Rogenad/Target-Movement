using UnityEngine;

namespace Arrow
{
    public class ArrowBounceController : MonoBehaviour
    {
        [SerializeField] 
        private int _maxBounces;
        private int _bounceCount;

        public void AddBounce()
        {
            _bounceCount++;

            if (_bounceCount == _maxBounces)
            {
                Destroy(gameObject);
            }
        }

    }
}
