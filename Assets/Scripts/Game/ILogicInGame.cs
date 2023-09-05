using System;

public interface ILogicInGame
{
    event Action OnGame;
    event Action OnPause;
    event Action OnGameOver;
    bool IsPause();
}