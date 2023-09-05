using UnityEngine;
using UnityEngine.UI;

internal class InGameImplements : GameImplements
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button pauseButton, gameOverButton;
    [SerializeField] private PlayerMediator playerMediator;
    private bool _isGameOver, _isPause, _isGame;
    
    private void Start()
    {
        panel.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
        gameOverButton.onClick.AddListener(GameOver);
    }

    private void PauseGame()
    {
        _isGame = false;
        _isPause = true;
        SetMovement(_isGame);
    }

    private void SetMovement(bool isGame)
    {
        playerMediator.StartMove(isGame);
    }

    public void GameOver()
    {
        _isGameOver = true;
        _isGame = false;
        SetMovement(_isGame);
    }

    public void UiForGame(bool can)
    {
        if (can)
        {
            _isGameOver = false;
            _isPause = false;
            _isGame = true;
        }
        SetMovement(_isGame);
        panel.SetActive(can);
    }

    public bool IsGame => _isGame;
    public bool IsPause => _isPause;
    public bool IsGameOver => _isGameOver;
}