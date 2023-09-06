using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IEnemy, IPowerUp
{
    [SerializeField] private float life;
    private bool canBeTarget = true;
    public void CantBeTarget()
    {
        canBeTarget = false;
    }

    public bool CanBeTarget => canBeTarget;
    public bool TakeDamage(float getDamage)
    {
        life -= getDamage;
        if (life <= 0)
        {
            canBeTarget = false;
            StartCoroutine(DestroyCustom());
        }
        return life <= 0;
    }

    public abstract void ApplyPowerUp(IFollower follower);

    private IEnumerator DestroyCustom()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public abstract void Config(float factorDeAumento);
}