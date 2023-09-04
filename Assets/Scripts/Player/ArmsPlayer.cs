using UnityEngine;

internal class ArmsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject pointToWapon;
    private GameObject _visualWeapon;
    public void ConfigWeapon(GameObject getVisualWeapon)
    {
        Destroy(_visualWeapon?.gameObject);
        _visualWeapon = Instantiate(getVisualWeapon, pointToWapon.transform);
    }
}