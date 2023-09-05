using Services;
using UnityEngine;

internal class MovementComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody body;  
    [SerializeField] private float speed;
    private IFacadeInput Input;
    private bool canMove;
    private void Update()
    {
        if(!canMove) return;
        if(Input == null) return;
        body.MovePosition(body.position + new Vector3(Input.GetDirection().x, 0, Input.GetDirection().y) * (speed * Time.deltaTime));
    }
    public void Config(IFacadeInput inputFacade)
    {
        Input = inputFacade;
        ServiceLocator.Instance.GetService<ILogicInGame>().OnGame += OnOnGame;
        ServiceLocator.Instance.GetService<ILogicInGame>().OnPause += OnOnPause;
        ServiceLocator.Instance.GetService<ILogicInGame>().OnGameOver += OnOnGameOver;
        canMove = ServiceLocator.Instance.GetService<ILogicInGame>().IsPause();
    }

    private void OnOnGameOver()
    {
        canMove = false;
    }

    private void OnOnPause()
    {
        canMove = false;
    }

    private void OnOnGame()
    {
        canMove = true;
    }

    public void StartMove(bool isGame)
    {
        canMove = isGame;
    }
}