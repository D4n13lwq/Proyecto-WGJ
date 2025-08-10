using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class MoverPared : MonoBehaviour
{
    [SerializeField] Transform Objective;
    [SerializeField] float Velocity;
    [SerializeField] Vector2 playerDetectorSize;
    [SerializeField] Vector2 playerDetectorOffset;
    [SerializeField] LayerMask playerDetectorLayermask;
    [SerializeField] GameObject giantPlush;
    [SerializeField] Vector2 offsetGiantPlush;
    float startedSpeed;

    private void Start()
    {
        startedSpeed = Velocity;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Objective.position, Velocity * Time.deltaTime);
        if (PlayerDetected())
            Velocity = startedSpeed / 1.35f;
        else
            Velocity = startedSpeed;
    }

    bool PlayerDetected()
    {
        return Physics2D.OverlapBox(new Vector2(transform.position.x + playerDetectorOffset.x, transform.position.y + playerDetectorOffset.y), playerDetectorSize, 0f, playerDetectorLayermask);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Poner función para matar al niño!
            //Aun no hay fincion para matar al niño :(
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + playerDetectorOffset.x, transform.position.y + playerDetectorOffset.y), playerDetectorSize);
    }

    private void OnDisable()
    {
        giantPlush.transform.position = new Vector2(transform.position.x + playerDetectorSize.x, transform.position.y + playerDetectorSize.y);
        giantPlush.gameObject.SetActive(true);
    }
}
