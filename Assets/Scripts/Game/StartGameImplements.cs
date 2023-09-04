using System;
using UnityEngine;
using UnityEngine.UI;

internal class StartGameImplements : GameImplements
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button startButton;
    private bool readyToStartGame;

    private void Start()
    {
        panel.SetActive(true);
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        readyToStartGame = true;
    }

    public void UiForStartGame(bool canShow)
    {
        if (canShow)
        {
            readyToStartGame = false;
        }
        panel.SetActive(canShow);
    }

    public bool IsReadyToStartGame => readyToStartGame;
}