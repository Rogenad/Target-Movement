using UnityEngine;
using UnityEngine.AI;

public class TargetMoving : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPosition;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void UpdateTarget(Vector3 targetPosition)
    {
        _navMeshAgent.destination = targetPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
            {
                _targetPosition = hit.point;
                UpdateTarget(_targetPosition);
            }
        }
    }
}
