using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _targetPos = new Vector3(16, 5.5f,0);
    private NavMeshAgent _npcAgent;

    private bool _isTarget = true;
    // Start is called before the first frame update
    private  void Start()
    {
        _npcAgent = GetComponent<NavMeshAgent>();
        _startPos = transform.position;
    }

    private void UpdateTarget()
    {
        var distance = Vector3.Distance(_npcAgent.transform.position, _targetPos);
        if (distance < 1 & !_isTarget)
        {
            _npcAgent.destination = _startPos;
            _isTarget = true;
        }

        var distanceToStart = Vector3.Distance(_npcAgent.transform.position, _startPos);
        if (distanceToStart < 1 & _isTarget)
        {
            _npcAgent.destination = _targetPos;
            _isTarget = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTarget();
    }
}
