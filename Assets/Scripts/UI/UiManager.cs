using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public delegate void Gamemenu();
    public event Gamemenu Ev_startGame;
    public event Gamemenu Ev_pauseGame;
    public event Gamemenu Ev_gameOver;
    public event Gamemenu Ev_continueGame;

    public static UiManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Ev_startGame?.Invoke();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Ev_pauseGame.Invoke();
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    //public void RestartLevel()
    //{
    //    PlayerPrefs.SetInt("restart", 1);
    //    SceneManager.LoadScene(0);
    //}

    public void ContinueGame()
    {
        Ev_continueGame?.Invoke();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Ev_gameOver?.Invoke();
        Time.timeScale = 0;
    }
}
