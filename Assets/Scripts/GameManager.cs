using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;

    //public GameState State;

    //public static event Action<GameState> OnGameStateChanged;
    //private void Awake()
    //{
    //    Instance = this;
    //}

    //private void Start()
    //{
    //    UpdateGameState(GameState.GamePlay);
    //}

    //public void UpdateGameState(GameState newState)
    //{
    //    State = newState;

    //    switch (newState)
    //    {
    //        case GameState.GamePlay:
    //            HandleGamePlay();
    //            break;
    //        case GameState.GameOver:
    //            HandleGameOver();
    //            break;
    //        case GameState.Victory:
    //            HandleVictory();
    //            break;
    //    }

    //    OnGameStateChanged?.Invoke(newState);
    //}

    //private void HandleGamePlay()
    //{

    //}

    //private void HandleGameOver()
    //{
    //    if (!GetComponent<NewPlayerController>().isAlive)
    //    {

    //    }
    //}

    //private void HandleVictory()
    //{

    //}

    public void ReturnButton()
    {
        int sceneID = 0;
        SceneManager.LoadScene(sceneID);
    }
}
//public enum GameState
//{
//    GamePlay,
//    GameOver,
//    Victory
//}
