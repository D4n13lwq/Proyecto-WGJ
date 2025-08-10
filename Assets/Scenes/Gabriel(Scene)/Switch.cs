using Unity.Cinemachine;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite switchOn;
    [SerializeField] Sprite switchOff;

    private SpriteRenderer switchRenderer;
    private void Awake()
    {
        switchRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             switchRenderer.sprite = switchOn;

            Debug.Log("prendido");
            //Aqui pueden poner la siguiente logica cuando prenda la luz.
        }
    }
}
