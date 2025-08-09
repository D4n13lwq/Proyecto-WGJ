using System;
using UnityEngine;

public class X : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<I_Enemy>(out I_Enemy enemy))
        {
            enemy.Lighted();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<I_Enemy>(out I_Enemy enemy))
        {
            enemy.Unlighted();
        }
    }
}
