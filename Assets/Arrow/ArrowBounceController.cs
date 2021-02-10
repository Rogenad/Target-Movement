using UnityEngine;

public class ArrowBounceController : MonoBehaviour
{
    public int maxBounces;
    private int _bounceCount;

    public void AddBounce()
    {
        _bounceCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if(_bounceCount == maxBounces)
            Destroy(gameObject);
            
    }
}
