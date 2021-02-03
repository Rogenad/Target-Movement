using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    
    private float speed = 5.0f;

    public Vector3 cameraPosition = new Vector3(0, 0, -4);

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraPosition, Time.deltaTime * speed);
    }
}
