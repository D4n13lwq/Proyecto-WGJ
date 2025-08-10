using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite switchOn;
    [SerializeField] Sprite switchOff;
    [SerializeField] List<GameObject> objects; //Objetos que van a cambiar de apagados a prendidos o viceversa
    [SerializeField] GameObject realPlayer;
    [SerializeField] GameObject falsePlayer;

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
            falsePlayer.transform.position = realPlayer.transform.position;

            foreach (GameObject obj in objects)
            {
                obj.SetActive(!obj.activeSelf);
            }
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
