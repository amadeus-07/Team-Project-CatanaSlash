using Core;
using UniRx;
using UnityEngine;

public class TransformMovement : IMovementTo
{
    private readonly Transform _transform;
    private readonly ReactiveProperty<float> _speed;
    private readonly float _rotationSpeed;
    private readonly bool _rotateTowardsMovement;

    public TransformMovement(
        Transform transform, 
        ReactiveProperty<float> speed, 
        float rotationSpeed = 10f, 
        bool rotateTowardsMovement = true)
    {
        _transform = transform;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
        _rotateTowardsMovement = rotateTowardsMovement;
    }

    public void MoveTo(Vector3 target)
    {
        Vector3 current = _transform.position;
        Vector3 direction = target - current;

        if (direction.magnitude < 0.01f)
            return;

        // Movement
        Vector3 newPos = current + direction.normalized * _speed.Value * Time.deltaTime;
        _transform.position = newPos;

        // Rotation
        if (_rotateTowardsMovement && direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Slerp(
                _transform.rotation, 
                targetRotation, 
                _rotationSpeed * Time.deltaTime
            );
        }
    }

    public void Stop()
    {
    }
}