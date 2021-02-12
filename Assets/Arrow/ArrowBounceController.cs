using UnityEngine;

namespace Arrow
{
    public class ArrowBounceController : MonoBehaviour
    {
        [SerializeField]
        private int maxBounces;
        private int _bounceCount;

        public void AddBounce()
        {
            _bounceCount++;

            if (_bounceCount == maxBounces)
            {
                Destroy(gameObject);
            }
        }

    }
}
