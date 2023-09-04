using UnityEngine;

public class GunFactory : MonoBehaviour
{
    [SerializeField] private Gun gunPrefab;
    
    public Gun CreateGun()
    {
        return gunPrefab;
    }
}