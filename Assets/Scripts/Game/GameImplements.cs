using UnityEngine;

public abstract class GameImplements : MonoBehaviour
{
    protected ILogicInGame _logicInGame;
    public void Config(ILogicInGame logicInGame)
    {
        _logicInGame = logicInGame;
    }
}