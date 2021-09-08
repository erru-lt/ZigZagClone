
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private MainMenuUI _mainMenuUI;


    private bool _isGamePaused;
    private bool _isGameStarted;

    public bool IsGamePaused
    {
        get
        {
            return _isGamePaused;
        }
        private set
        {

        }
    }
    public bool IsGameStarted
    {
        get
        {
            return _isGameStarted;
        }
        private set
        {

        }
    }
    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        _scoreUI.gameObject.SetActive(true);
        _mainMenuUI.gameObject.SetActive(false);

        _isGameStarted = true;
    }

    public void GameOver()
    {
        _gameOverUI.gameObject.SetActive(true);
        _scoreUI.gameObject.SetActive(false);
        _isGameStarted = false;        
    }

    public void ResetGame()
    {
        SceneManagement.LoadScene();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
