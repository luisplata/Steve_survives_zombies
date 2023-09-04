using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Gun", order = 1)]
public class Gun : ScriptableObject
{
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private GameObject visualReference;
    [SerializeField] private bool isAtTwoHand;
    [SerializeField] private string soundOfShoot;
    private float _cooldown;
    public bool IsReadyForShoot(float deltaTime)
    {
        _cooldown -= deltaTime;
        if (_cooldown <= 0)
        {
            _cooldown = cooldown;
            return true;
        }
        return false;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetRadius()
    {
        return radius;
    }

    public bool IsAtTwoArms()
    {
        return isAtTwoHand;
    }

    public GameObject GetVisualWeapon()
    {
        return visualReference;
    }

    public string GetSoundOfShoot()
    {
        return soundOfShoot;
    }
}