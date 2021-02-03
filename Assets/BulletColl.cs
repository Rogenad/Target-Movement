using UnityEngine;

public class BulletColl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        //if(other.gameObject.CompareTag("Enemy")) Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Navigation Static")) Destroy(gameObject);
    }
}
