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
    private AudioSource _startingSound;
    private bool _isGameOver;
    private float _timeTaken;

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
        _startingSound = GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        IsGameOver();
        if (_isGameOver == false) { 
            _timeTaken = Time.timeSinceLevelLoad;
        }
    }

    private void OnEnable()
    {
        Player.OnPlayerDead += GameFailed;
    }

    private void OnDisable()
    {
        Player.OnPlayerDead -= GameFailed;
    }

    private void GameFailed()
    {
        _isGameOver = true;

    }

    public void Start()
    {
        _startingSound.PlayOneShot(_startingSound.clip);
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Game.Scenes.Game);
    }

    public float AskTime()
    {
        return _gameLength - _timeTaken;
    }

    private void IsGameOver()
    {
        if (AskTime() < 0 && _isGameOver == false)
        {
            OnPlayerSurvival?.Invoke();
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
