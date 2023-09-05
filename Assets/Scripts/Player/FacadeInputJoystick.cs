using UnityEngine;

public class FacadeInputJoystick : MonoBehaviour, IFacadeInput
{
    [SerializeField] private Joystick joystick;
    public Vector2 GetDirection()
    {
        //allways up and variant in axis X
        var direction = new Vector2(0, 1);
        if (joystick.Direction.x > 0)
        {
            direction.x = 1;
        }
        else if (joystick.Direction.x < 0)
        {
            direction.x = -1;
        }
        return direction;
    }
}