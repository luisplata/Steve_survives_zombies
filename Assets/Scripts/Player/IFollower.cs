public interface IFollower
{
    void SetRadius(float radius);
    void SetGunForAllFollowers(Gun instantiateGun);
    void AddOtherFollower(int followers);
}