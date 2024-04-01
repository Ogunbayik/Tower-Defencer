using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Button startButton;

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
        currentState = GameStates.Start;
    }

    public void StartGame()
    {
        currentState = GameStates.InGame;
        StartButtonActivate(false);
    }

    private void StartButtonActivate(bool isActive)
    {
        startButton.gameObject.SetActive(isActive);
    }

}
