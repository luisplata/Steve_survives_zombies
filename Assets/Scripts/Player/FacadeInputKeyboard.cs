using UnityEngine;
using UnityEngine.InputSystem;

public class FacadeInputKeyboard : MonoBehaviour, IFacadeInput
{
    private Vector2 _direction;
    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
    public Vector2 GetDirection()
    {
        var direction = new Vector2(0, 1);
        if (_direction.x > 0)
        {
            direction.x = 1;
        }
        else if (_direction.x < 0)
        {
            direction.x = -1;
        }
        return direction;
    }
}