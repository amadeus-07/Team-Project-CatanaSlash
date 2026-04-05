using Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshMovement : IMovementTo, IMovement
{
    private readonly NavMeshAgent _agent;
    private readonly bool _isControlled;

    public NavMeshMovement(NavMeshAgent agent, bool isControlled = false)
    {
        _agent = agent;
        _isControlled = isControlled;
    }

    public void Move(Vector3 input)
    {
        if (!_agent.isActiveAndEnabled) return;
        if (!_agent.isOnNavMesh) return;
        if (input.sqrMagnitude < 0.0001f) return;

        Rotate(input);

        if (_isControlled)
            _agent.Move(input);
        else
            _agent.destination = _agent.transform.position + input;

        _agent.isStopped = false;
    }

    private void Rotate(Vector3 direction)
    {
        direction.y = 0f;
        var targetRot = Quaternion.LookRotation(direction);
        _agent.transform.rotation = Quaternion.Slerp(
            _agent.transform.rotation,
            targetRot,
            Time.deltaTime * 10f
        );
    }

    public void MoveTo(Vector3 target)
    {
        if (!_agent.isActiveAndEnabled) return;
        if (!_agent.isOnNavMesh) return;
        _agent.destination = target;
        _agent.isStopped = false;
    }

    public void Stop()
    {
        if (!_agent.isActiveAndEnabled) return;
        if (!_agent.isOnNavMesh) return;
        _agent.isStopped = true;
    }
}
