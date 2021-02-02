using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 2.5f;

    private Vector3 _target = new Vector3(0.6f,6,-0.67f);

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
            }
        }

        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * speed);
    }
}
