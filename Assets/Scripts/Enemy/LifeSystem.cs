using System;
using UnityEngine;

internal class LifeSystem : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float timeToDestroy;
    public bool IsDead => _isDead;
    private bool _isDead;
    private IEnemy _enemy;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _isDead = true;
        }
    }

    public void Config(IEnemy enemy)
    {
        _enemy = enemy;
    }

    private void FixedUpdate()
    {
        if (_isDead)
        {
            _enemy.CantBeTarget();
        }
    }
}