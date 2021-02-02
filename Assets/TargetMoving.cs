using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 1.0f;
    
    private Vector3 _start = new Vector3(0, 6, 0);
    private Vector3 _target = new Vector3(10, 6, 0);
    private float _distance;
    private float _startTime;

    private void Start()
    {
        _distance = Vector3.Distance(_start, _target);
        _startTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            var ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
            {
                _start = transform.position;
                _target = _hit.point;
                _distance = Vector3.Distance(_start, _target);
                _startTime = Time.time;
            }
        }
        
        var distPast = (Time.time - _startTime) * speed;
        var fractionOfDistance = distPast / _distance;
        
        transform.position = Vector3.Lerp(_start, _target, fractionOfDistance);
    }
}
