public interface IEnemy
{
    void CantBeTarget();
    bool CanBeTarget { get; }
    bool TakeDamage(float getDamage);
}