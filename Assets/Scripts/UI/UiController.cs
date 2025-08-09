using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    [SerializeField] GameObject startpanel, panelGameOver, panelpause, gamepanel;
    
    private bool x;

    public void Start()
    {
        UiManager.Instance.Ev_startGame += ShowPanelGame;
        UiManager.Instance.Ev_pauseGame += ShowPanelPause;
        UiManager.Instance.Ev_continueGame += ShowPanelGame;
        UiManager.Instance.Ev_gameOver += ShowPanelGameover;

    }


    public void ShowPanelGameover()
    {
        panelGameOver.SetActive(true);
        panelpause.SetActive(false);
        startpanel.SetActive(false);
        gamepanel.SetActive(false);
    }
    public void ShowPanelPause()
    {
        panelGameOver.SetActive(false);
        panelpause.SetActive(true);
        startpanel.SetActive(false);
        gamepanel.SetActive(false);
    }
    public void ShowPanelGame()
    {
        panelGameOver.SetActive(false);
        panelpause.SetActive(false);
        startpanel.SetActive(false);
        gamepanel.SetActive(true);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public bool IsGamePanelActive()
    {
        return gamepanel.activeSelf;
    }
}
