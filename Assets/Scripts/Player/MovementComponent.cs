using UnityEngine;

internal class MovementComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody body;  
    [SerializeField] private float speed;
    private IFacadeInput Input;
    private void Update()
    {
        if(Input == null) return;
        body.MovePosition(body.position + new Vector3(Input.GetDirection().x, 0, Input.GetDirection().y) * (speed * Time.deltaTime));
    }
    public void Config(IFacadeInput inputFacade)
    {
        Input = inputFacade;
    }
}