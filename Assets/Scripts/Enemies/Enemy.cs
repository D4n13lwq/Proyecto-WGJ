using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, I_Enemy
{
    internal Rigidbody2D rigid;
    internal Collider2D coll;

    [SerializeField] internal Attack attack;
    
    public List<GameObject> parts { get; set; } = new();
    
    [SerializeField] private bool is_Lighted;
    [SerializeField] internal GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    
    [SerializeField] private float dot_Product;
    private Vector2 dir;
    [SerializeField] internal Vector2 dis;

    [SerializeField] private Vector2 distance_To_Detect;

    protected virtual void Start_Enemy()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
        dir = transform.right;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if (go != attack.circle_Pos.gameObject) parts.Add(go);
        }
        
        Unlighted();
    }

    internal virtual void Dot_Product()
    {
        dis = player.transform.position - transform.position;
        dot_Product = Vector2.Dot(dir, dis.normalized);
        
        Flip();
    }

    internal virtual void Movement()
    {
        if (is_Lighted || MathF.Abs(dis.x) > distance_To_Detect.x) { return; }
        
        rigid.linearVelocityX = speed * MathF.Sign(dis.x);

        foreach (var part in  parts)
        {
            part.GetComponent<Rigidbody2D>().linearVelocity = rigid.linearVelocity;
        }
    }

    internal virtual void Attack()
    {
        Debug.Log("Atack_E");
        attack.Do_Attack();
    }
    
    private void Flip()
    {
        if(dot_Product >= 0) { return; }

        transform.localScale = new(transform.localScale.x * -1, transform.localScale.y);
        dir *= -1;
    }

    public virtual void Lighted()
    {
        is_Lighted = true;
        
        rigid.gravityScale = 0;
        rigid.linearVelocity = Vector2.zero;
        coll.isTrigger = true;
        
        foreach (var part in parts)
        {
            part.GetComponent<SpriteRenderer>().enabled = true;
            part.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            part.GetComponent<Collider2D>().enabled = true;
            part.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        
        this.enabled = false;
    }

    public virtual void Unlighted()
    {
        is_Lighted = false;
        
        rigid.gravityScale = 1;
        coll.isTrigger = false;
        
        foreach (var part in parts)
        {
            part.GetComponent<SpriteRenderer>().enabled = false;
            part.GetComponent<Collider2D>().enabled = false;
            part.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
