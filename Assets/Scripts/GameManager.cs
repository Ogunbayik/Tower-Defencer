using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Button startButton;
    [SerializeField] private Button nextWaveButton;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject inGameCanvas;

    public enum GameStates
    {
        Start,
        InGame,

    }

    public GameStates currentState;
    void Start()
    {
        #region Singleton

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        #endregion
        StartButtonActivate(true);
        NextWaveButtonActivate(false);
        currentState = GameStates.Start;

        MenuCanvasActivate(true);
        InGameCanvasActivate(false);
    }

    public void StartGame()
    {
        currentState = GameStates.InGame;
        StartButtonActivate(false);
        MenuCanvasActivate(false);
        InGameCanvasActivate(true);
    }

    private void StartButtonActivate(bool isActive)
    {
        startButton.gameObject.SetActive(isActive);
    }

    public void MenuCanvasActivate(bool isActive)
    {
        menuCanvas.gameObject.SetActive(isActive);
    }

    public void InGameCanvasActivate(bool isActive)
    {
        inGameCanvas.gameObject.SetActive(isActive);
    }
    public void NextWaveButtonActivate(bool isActive)
    {
        nextWaveButton.gameObject.SetActive(isActive);
    }
}
