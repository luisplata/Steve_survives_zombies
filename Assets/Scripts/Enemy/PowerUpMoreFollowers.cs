public class PowerUpMoreFollowers : PowerUp
{
    private int _followers;
    
    public override void ApplyPowerUp(IFollower follower)
    {
        follower.AddOtherFollower(_followers);
    }

    public override void Config(float factorDeAumento)
    {
        _followers = (int) factorDeAumento;
    }
}