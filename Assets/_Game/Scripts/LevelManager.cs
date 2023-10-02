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
        // LevelManager is not destroyed on scene change so we want to make sure there's always only one level manager in the scene
        if (FindObjectsOfType<LevelManager>().Length > 1)
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
        Time.timeScale = 1f; // sets time to move

        // Since references to camerar is lost when scene changes, we need to get again
        _mainMenuVirtualCamera = GameObject.FindGameObjectWithTag(Game.Tags.MainMenuCamera)?.GetComponent<CinemachineVirtualCamera>();
        _gameVirtualCamera = GameObject.FindGameObjectWithTag(Game.Tags.GameCamera)?.GetComponent<CinemachineVirtualCamera>();

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
