using UnityEngine;
using UnityEngine.UI;

internal class PauseInGameImplements : GameImplements
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button resumeButton;
    private bool _isPause;
    
    public bool IsPause => _isPause;
    
    private void Start()
    {
        panel.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void ResumeGame()
    {
        _isPause = false;
    }

    public void UiForPause(bool canShow)
    {
        if (canShow)
        {
            _isPause = true;
        }
        panel.SetActive(canShow);
    }
}