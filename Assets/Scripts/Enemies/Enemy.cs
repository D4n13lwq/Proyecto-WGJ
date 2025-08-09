using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, I_Enemy
{
    private Rigidbody2D rigid;
    private Collider2D coll;
    
    public List<GameObject> parts { get; set; } = new();
    
    [SerializeField] private bool is_Lighted;
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            parts.Add(go);
        }
        
        Unlighted();
    }

    private void FixedUpdate()
    {
        if (!is_Lighted)
        {
            distance = transform.position.x - player.transform.position.x;
            rigid.linearVelocityX = speed * -MathF.Sign(distance);

            foreach (var part in  parts)
            {
                part.GetComponent<Rigidbody2D>().linearVelocity = rigid.linearVelocity;
            }
        }
    }

    public void Lighted()
    {
        is_Lighted = true;
        
        rigid.gravityScale = 0;
        rigid.linearVelocity = Vector2.zero;
        coll.isTrigger = true;
        
        foreach (var part in parts)
        {
            part.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            part.GetComponent<Collider2D>().enabled = true;
            part.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    public void Unlighted()
    {
        is_Lighted = false;
        
        rigid.gravityScale = 1;
        coll.isTrigger = false;
        
        foreach (var part in parts)
        {
            part.GetComponent<Collider2D>().enabled = false;
            part.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
