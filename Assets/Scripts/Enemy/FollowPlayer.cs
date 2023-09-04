using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _rigidbody;
    [SerializeField] private MovementComponent movementComponent;
    [SerializeField] private LifeSystem lifeSystem;
    private List<Follower> _targets = new();
    private Follower _target;
    private FacadeInputEnemy _inputCustom;

    private void Start()
    {
        _inputCustom = new FacadeInputEnemy(gameObject);
        movementComponent.Config(_inputCustom);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Follower target))
        {
            _targets.Add(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Follower target))
        {
            _targets.Remove(target);
        }
    }

    private void FixedUpdate()
    {
        if(_targets.Count == 0) return;
        //search target shortest distance
        var shortestDistance = float.MaxValue;
        Follower target = null;
        foreach (var targetComponent in _targets)
        {
            var distance = Vector3.Distance(targetComponent.transform.position, _rigidbody.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                target = targetComponent;
                _inputCustom.SetTarget(target);
            }
        }
        //Rotate to target but only Y axis
        if (target != null && !lifeSystem.IsDead)
        {
            var targetPosition = target.transform.position;
            targetPosition.y = _rigidbody.transform.position.y;
            var targetRotation = Quaternion.LookRotation(targetPosition - _rigidbody.transform.position);
            _rigidbody.transform.rotation = Quaternion.Lerp(_rigidbody.transform.rotation, targetRotation, 0.1f);
        }

        if (lifeSystem.IsDead)
        {
            _inputCustom.IsDead();
        }
    }
}