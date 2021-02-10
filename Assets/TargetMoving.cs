using UnityEngine;
using UnityEngine.AI;

public class TargetMoving : MonoBehaviour
{
    public Camera mainCamera;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPosition;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targetPosition = transform.position;
    }

    private void UpdateTarget(Vector3 targetPosition)
    {
        _navMeshAgent.destination = targetPosition;
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
                _targetPosition = _hit.point;
                _navMeshAgent.velocity = new Vector3(0, 0, 0);
                UpdateTarget(_targetPosition);
            }
        }
    }
}
