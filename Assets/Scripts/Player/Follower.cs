using System;
using System.Collections.Generic;
using UnityEngine;

internal class Follower: MonoBehaviour, IFollower
{
    public Action<Gun> OnPowerUpEventFollower;
    [SerializeField] private ShootSystem shootSystem;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private GameObject body, legs;
    [SerializeField] private GameObject vfxPrefab;
    private GameObject _pointOfFollowGo;
    private List<TargetComponent> _targets = new();
    private Gun _gun;
    private IPlayerMediator _playerMediator;

    public void Config(GameObject pointOfFollowGo, Gun gun, IPlayerMediator playerMediator)
    {
        _pointOfFollowGo = pointOfFollowGo;
        _playerMediator = playerMediator;
        shootSystem.Config(this);
        shootSystem.SetGun(gun);
        shootSystem.OnPowerUpEvent += OnPowerUpEvent;
        ShootVfx();
    }

    private void OnPowerUpEvent(Gun gun)
    {
        ShootVfx();
        _gun = gun;
        OnPowerUpEventFollower?.Invoke(gun);
    }

    private void ShootVfx()
    {
        var vfx = Instantiate(vfxPrefab, transform.position, Quaternion.identity, transform);
        Destroy(vfx, 1);
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        position = Vector3.Lerp(position, _pointOfFollowGo.transform.position, 0.5f);
        transform.position = position;
        
        Debug.DrawLine(transform.position, _pointOfFollowGo.transform.position, Color.red);
        
        //search target shortest distance
        var shortestDistance = float.MaxValue;
        TargetComponent target = null;
        foreach (var targetComponent in _targets)
        {
            if(!targetComponent.GetEnemy().CanBeTarget) continue;
            var distance = Vector3.Distance(targetComponent.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                target = targetComponent;
                shootSystem.SetTarget(target);
            }
        }
        //Rotate to target but only Y axis
        if (target != null)
        {
            var targetPosition = target.transform.position;
            targetPosition.y = transform.position.y;
            var targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, targetRotation, 0.5f);
            Debug.DrawLine(transform.position, targetPosition, Color.green);
        }
        else
        {
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, _playerMediator.GetDirectionOfInput(), 0.5f);
        }
        legs.transform.rotation = Quaternion.Lerp(legs.transform.rotation, _playerMediator.GetDirectionOfInput(), 0.5f);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TargetComponent target))
        {
            if(!target.GetEnemy().CanBeTarget) return;
            _targets.Add(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out TargetComponent target))
        {
            if(!target.GetEnemy().CanBeTarget) return;
            _targets.Remove(target);
        }
    }

    public void SetRadius(float radius)
    {
        sphereCollider.radius = radius;        
    }

    public IPlayerMediator GetPlayerMediator()
    {
        throw new NotImplementedException();
    }

    public void SetGunForAllFollowers(Gun instantiateGun)
    {
        _playerMediator.SetGunForAllFollowers(instantiateGun);
    }

    public void AddOtherFollower(int followers)
    {
        _playerMediator.AddOtherFollower(followers);
    }

    private void Reset()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }
}