using UnityEngine;

public class FacadeInputJoystick : MonoBehaviour, IFacadeInput
{
    [SerializeField] private Joystick joystick;
    public Vector2 GetDirection()
    {
        return joystick.Direction;
    }
}