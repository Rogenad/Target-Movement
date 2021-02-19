using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private Vector3 _cameraPosition = new Vector3(0, 0, -10);

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _cameraPosition, Time.deltaTime * _speed);
    }
}
