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
        return _direction;
    }
}