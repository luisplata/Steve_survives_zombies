using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public Action OnTakeDamageEvent, OnDeadEvent;
    [SerializeField] private LifeSystem life;
    [SerializeField] private bool canBeTarget = true;
    [SerializeField] private GameObject fatherOfModel3D;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private Rigidbody[] rigidbodies;
    private GameObject model3D;
    public bool CanBeTarget => canBeTarget;
    private void Start()
    {
        life.Config(this);
    }

    public bool TakeDamage(float damage)
    {
        life.TakeDamage(damage);
        OnTakeDamageEvent?.Invoke();
        if (life.IsDead)
        {
            OnDeadEvent?.Invoke();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.useGravity = false;
                rigidbody.velocity = Vector3.zero;
                rigidbody.isKinematic = true;
            }
        }
        return life.IsDead;
    }

    public void CantBeTarget()
    {
        canBeTarget = false;
    }
    
    public void InstantiateModel3D(GameObject model3D)
    {
        model3D = Instantiate(model3D, fatherOfModel3D.transform);
    }
}