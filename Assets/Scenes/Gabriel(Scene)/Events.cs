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
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] JumpExecutor playerJump;
    [SerializeField] Rigidbody2D rb;

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
    private IEnumerator SwitchToSpikes()
    {
        // Activar cámara de pared
        vcamWall.Priority = 20;
        vcamPlayer.Priority = 10;
        // Amordazar al jugador
        playerMovement.enabled = false;
        playerJump.enabled = false;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(viewTime);

        // Volver al jugador
        vcamPlayer.Priority = 20;
        vcamWall.Priority = 10;

        // Soltar al jugador
        playerMovement.enabled = true;
        playerJump.enabled = true;
        gameObject.SetActive(false);
    }
}
