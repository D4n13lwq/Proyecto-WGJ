using UnityEngine;

public class InputPause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] Ui uiScript; 

    void Update()
    {
       
        if (uiScript != null && uiScript.IsGamePanelActive())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    UiManager.Instance.ContinueGame();
                    isPaused = false;
                }
                else
                {
                    UiManager.Instance.PauseGame();
                    isPaused = true;
                }
            }
        }
    }
}
