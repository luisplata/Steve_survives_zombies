using System;
using Services;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public Action<string> OnShootEvent;
    public Action<Gun> OnPowerUpEvent;
    [SerializeField] private ArmsPlayer armAtOneHand, armAtTwoHand;
    [SerializeField] private Gun gun;
    private TargetComponent _target;
    private IFollower _follower;

    public void SetTarget(TargetComponent target)
    {
        _target = target;
    }

    private void Update()
    {
        if(ServiceLocator.Instance.GetService<ILogicInGame>().IsPause()) return;
        if(gun == null || _target == null) return;
        if (gun.IsReadyForShoot(Time.deltaTime))
        {
            OnShootEvent?.Invoke(gun.GetSoundOfShoot());
            if (_target.GetEnemy().TakeDamage(gun.GetDamage()))
            {
                //see if enemy have a interface 'IPowerUp'
                if(_target.GetEnemy() is IPowerUp)
                {
                    var powerUp = _target.GetEnemy() as IPowerUp;
                    var gun = powerUp.GetGun();
                    SetGun(gun);
                    OnPowerUpEvent?.Invoke(gun);
                }
            }
        }

        if (!_target.GetEnemy().CanBeTarget)
        {
            _target = null;
        }
    }

    public void SetGun(Gun gunInComming)
    {
        gun = gunInComming;
        armAtTwoHand.gameObject.SetActive(gun.IsAtTwoArms());
        armAtOneHand.gameObject.SetActive(!gun.IsAtTwoArms());
        if (gun.IsAtTwoArms())
        {
            armAtTwoHand.ConfigWeapon(gun.GetVisualWeapon());
        }
        else
        {
            armAtOneHand.ConfigWeapon(gun.GetVisualWeapon());
        }
        _follower.SetRadius(gun.GetRadius());
    }

    public void Config(IFollower follower)
    {
        _follower = follower;
    }
}