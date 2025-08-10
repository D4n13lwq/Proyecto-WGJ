using Unity.VisualScripting;
using UnityEngine;

public class MoverPared : MonoBehaviour
{
    [SerializeField] Transform Objective;
    [SerializeField] float Velocity = 5f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Objective.position, Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Poner función para matar al niño!
        }
    }
}
