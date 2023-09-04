using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    [SerializeField, InterfaceType(typeof(IEnemy))] private Object enemy;

    public IEnemy GetEnemy()
    {
        return enemy as IEnemy;
    }
}