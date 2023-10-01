using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverScreen;


    private void OnEnable()
    {
        Player.OnPlayerDead += DisplayGameOver;
    }

    private void OnDisable()
    {
        Player.OnPlayerDead -= DisplayGameOver;
    }

    private void DisplayGameOver()
    {
        _gameOverScreen.SetActive(true);
    }

    
}
