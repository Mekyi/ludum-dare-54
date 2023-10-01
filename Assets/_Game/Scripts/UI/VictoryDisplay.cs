using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryScreen;

    private void OnEnable()
    {
        GameManager.OnPlayerSurvival += DisplayVictory;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerSurvival -= DisplayVictory;
    }

    private void DisplayVictory()
    {
        _victoryScreen.SetActive(true);
    }
}
