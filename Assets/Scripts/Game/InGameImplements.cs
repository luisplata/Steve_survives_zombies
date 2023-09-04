using UnityEngine;
using UnityEngine.UI;

internal class InGameImplements : GameImplements
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button pauseButton, gameOverButton;
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
    }

    public void GameOver()
    {
        _isGameOver = true;
        _isGame = false;
    }

    public void UiForGame(bool can)
    {
        if (can)
        {
            _isGameOver = false;
            _isPause = false;
            _isGame = true;
        }
        panel.SetActive(can);
    }

    public bool IsGame => _isGame;
    public bool IsPause => _isPause;
    public bool IsGameOver => _isGameOver;
}