using UnityEngine;

public interface IPlayerMediator
{
    Quaternion GetDirectionOfInput();
    void AddOtherFollower(int countOfFollowers);
    void SetGunForAllFollowers(Gun instantiateGun);
}