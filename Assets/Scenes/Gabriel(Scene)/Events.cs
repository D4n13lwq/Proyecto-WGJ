using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] UnityEvent activateEvent;
    [SerializeField] UnityEvent desactivateEvent;
    [SerializeField] List<string> tagsAllowed;

    public CinemachineCamera vcamPlayer;
    public CinemachineCamera vcamWall;
    public float viewTime = 2f; 



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activateEvent?.Invoke();
            StartCoroutine(SwitchToSpikes());
            Debug.Log("funcionando");
        }

    }
    private System.Collections.IEnumerator SwitchToSpikes()
    {
        // Activar cámara de pared
        vcamWall.Priority = 20;
        vcamPlayer.Priority = 10;

        yield return new WaitForSeconds(viewTime);

        // Volver al jugador
        vcamPlayer.Priority = 20;
        vcamWall.Priority = 10;
    }
}
