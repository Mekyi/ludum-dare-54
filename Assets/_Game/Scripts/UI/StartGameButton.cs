using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiToHideWhenButtonPressed;

    public void StartGame()
    {
        if (_uiToHideWhenButtonPressed != null)
        {
            _uiToHideWhenButtonPressed.SetActive(false);
        }
        
        FindObjectOfType<LevelManager>().StartGameFromMainMenu();
    }
}
