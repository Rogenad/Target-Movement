using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 5.0f;

    private bool _isMoving;
    private Vector3 _direction;
    private Vector3 _target;

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            var ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
            {
                _target = _hit.point;
                _target.y += 0.5f;
                _direction = (_target - transform.position).normalized;
                _isMoving = true;
            }
        }
        
        if(!_isMoving) return;
        
        if (!Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity) | Vector3.Distance(transform.position,_target) < 0.1f)
        {
            transform.position = _target;
            _isMoving = false;
            return;
        }
        
        var move = _direction * (Time.deltaTime * speed);
        transform.position += move;
    }
}
