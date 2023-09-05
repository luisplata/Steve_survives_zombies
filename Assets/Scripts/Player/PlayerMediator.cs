using UnityEngine;

public class PlayerMediator : MonoBehaviour, IPlayerMediator
{
    [SerializeField, InterfaceType(typeof(IFacadeInput))] private Object inputFacadeKeyBoard, inputFacadeJoystick;
    [SerializeField, InterfaceType(typeof(ILogicInGame))] private Object logic;
    [SerializeField] private SpawnerOfFollowers spawnerOfFollowers;
    [SerializeField] private Gun defaultGun;
    [SerializeField] private MovementComponent movementComponent;
    private IFacadeInput _inputFacade;
    private ILogicInGame _logicInGame;

    private void Start()
    {
        _logicInGame = (ILogicInGame) logic;
        //Configure all components and set all references
        //Add a follower
        spawnerOfFollowers.Config(this);
        spawnerOfFollowers.AddFollower(defaultGun);
#if UNITY_ANDROID
        _inputFacade = (IFacadeInput) inputFacadeJoystick;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE
        _inputFacade = (IFacadeInput) inputFacadeKeyBoard;
#endif
        movementComponent.Config(_inputFacade);
        
    }

    public Quaternion GetDirectionOfInput()
    {
        var forward = new Vector3(_inputFacade.GetDirection().x, 0, _inputFacade.GetDirection().y);
        //dont rotate if input is zero
        if (forward == Vector3.zero) return transform.rotation;
        return Quaternion.LookRotation(forward);
    }

    public void StartMove(bool isGame)
    {
        movementComponent.StartMove(isGame);
    }
}