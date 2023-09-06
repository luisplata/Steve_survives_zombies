using UnityEngine;

public class PowerUpWeapons : PowerUp
{
    
    [SerializeField] private Gun gun;
    private Gun _instantiateGun;
    public override void ApplyPowerUp(IFollower follower)
    {
        follower.SetGunForAllFollowers(_instantiateGun);
    }

    public override void Config(float factorDeAumento)
    {
        _instantiateGun = Instantiate(gun);
        _instantiateGun.Config(factorDeAumento);
    }

    public Gun GetGun()
    {
        return _instantiateGun;
    }
}