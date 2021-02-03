using UnityEngine;

public class BulletColl : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Navigation Static") && !other.gameObject.CompareTag("Gun")) Destroy(gameObject);
    }
}
