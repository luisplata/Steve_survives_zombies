using UnityEngine;
using UnityEngine.UI;

internal class GameOverImplements : GameImplements
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button restartButton;
    private bool _isRestart, _await;
    
    private void Start()
    {
        panel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        _isRestart = true;
        _await = false;
    }

    public void UiForGameOver(bool canShow)
    {
        if (canShow)
        {
            _isRestart = false;
            _await = true;
        }
        panel.SetActive(canShow);        
    }

    public bool Await => _await;
    public bool IsRestart => _isRestart;
}