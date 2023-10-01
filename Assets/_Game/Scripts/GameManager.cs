using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField]
    private float _gameLength = 20f;

    public static event Action OnPlayerSurvival;

    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.LogError("Game Manager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
       IsGameOver();
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Game.Scenes.Game);
    }

    public float AskTime()
    {
        return _gameLength - Time.timeSinceLevelLoad;
    }

    private void IsGameOver()
    {
        if (AskTime() < 0)
        {
            OnPlayerSurvival?.Invoke();
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
