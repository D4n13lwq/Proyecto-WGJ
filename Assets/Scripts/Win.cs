using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    private void OnEnable()
    {
        StartCoroutine(FinishGame());
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(4);
        winPanel.SetActive(true);
    }

}
