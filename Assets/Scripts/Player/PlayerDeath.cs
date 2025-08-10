using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<I_Enemy>(out I_Enemy enemy))
        {

        }
    }
}
