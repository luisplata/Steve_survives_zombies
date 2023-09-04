using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicInGame : MonoBehaviour, ILogicInGame
{
    [SerializeField] private StartGameImplements startGameImplements;
    [SerializeField] private InGameImplements inGameImplements;
    [SerializeField] private PauseInGameImplements pauseInGameImplements;
    [SerializeField] private GameOverImplements gameOverImplements;
    private TeaTime _start, _game, _pause, _end;

    private void Start()
    {
        Config();
    }

    public void Config()
    {
        startGameImplements.Config(this);
        inGameImplements.Config(this);
        pauseInGameImplements.Config(this);
        gameOverImplements.Config(this);
        
        _start = this.tt().Pause().Add(() =>
        {
            startGameImplements.UiForStartGame(true);
            Debug.Log("Start");
        }).Wait(()=>startGameImplements.IsReadyToStartGame, .1f).Add(() =>
        {
            startGameImplements.UiForStartGame(false);
            _game.Play();
        });
        _game = this.tt().Pause().Add(() =>
        {
            inGameImplements.UiForGame(true);
            Debug.Log("Game");
        }).Wait(()=>!inGameImplements.IsGame, .1f).Add(() =>
        {
            inGameImplements.UiForGame(false);
            if (inGameImplements.IsPause)
            {
                _pause.Play();
            }else if (inGameImplements.IsGameOver)
            {
                _end.Play();
            }
        });
        _pause = this.tt().Pause().Add(() =>
        {
            pauseInGameImplements.UiForPause(true);
            Debug.Log("Pause");
        }).Wait(()=>!pauseInGameImplements.IsPause, .1f).Add(() =>
        {
            pauseInGameImplements.UiForPause(false);
            _game.Play();
        });
        _end = this.tt().Pause().Add(() =>
        {
            gameOverImplements.UiForGameOver(true);
            Debug.Log("End");
        }).Wait(()=>!gameOverImplements.Await, .1f).Add(() =>
        {
            if (gameOverImplements.IsRestart)
            {
                SceneManager.LoadScene(0);
            }
        });
        
        _start.Play();
    }
}