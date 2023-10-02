using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Main menu")]
    [SerializeField]
    private CinemachineVirtualCamera _mainMenuVirtualCamera;

    [SerializeField] 
    private CinemachineVirtualCamera _gameVirtualCamera;

    [SerializeField]
    private float _mainMenuToGameDelay = 2f;

    private void Awake()
    {
        if (GameObject.FindObjectsOfType<LevelManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameFromMainMenu()
    {
        if (SceneManager.GetActiveScene().name != Game.Scenes.MainMenu)
        {
            return;
        }

        _mainMenuVirtualCamera.Priority = 0;
        _gameVirtualCamera.Priority = 1;

        StartCoroutine(LoadGameOnDelay());
    }

    private IEnumerator LoadGameOnDelay()
    {
        yield return new WaitForSeconds(_mainMenuToGameDelay);

        SceneManager.LoadScene(Game.Scenes.Game);
    }
}
