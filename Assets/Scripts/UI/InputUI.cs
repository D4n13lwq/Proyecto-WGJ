using UnityEngine;

public class InputUI : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] Ui uiScript;
    [SerializeField] GameObject realPlayer;
    [SerializeField] GameObject falsePlayer;

    private void Start()
    {
        UiManager.Instance.Ev_pauseGame += PausePlayer;
        UiManager.Instance.Ev_continueGame += ResumePlayer;
        UiManager.Instance.Ev_continueGame += ChangePauseBoolToFalse;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiScript.IsGamePanelActive() && isPaused == false)
            {
                UiManager.Instance.PauseGame();
                isPaused = true;
            }
            else if (uiScript.IsPausePanelActive() && isPaused == true)
            {
                UiManager.Instance.ContinueGame();
                isPaused = false;
            }
        }

        if (Input.anyKey && uiScript.IsStartPanelActive())
            UiManager.Instance.StartGame();
    }

    void PausePlayer()
    {
        falsePlayer.transform.position = realPlayer.transform.position;
        realPlayer.SetActive(false);
        falsePlayer.SetActive(true);
    }

    void ResumePlayer()
    {
        falsePlayer.SetActive(false);
        realPlayer.SetActive(true);
    }

    void ChangePauseBoolToFalse()
    {
        isPaused = false;
    }
}
