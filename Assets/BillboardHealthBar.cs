using UnityEngine;

public class BillboardHealthBar : MonoBehaviour
{
    private Transform _camera;
    
    private void Start()
    {
        _camera = Camera.main.transform;
    }
    
    private void LateUpdate()
    {
        transform.LookAt(_camera.position);
    }
}
