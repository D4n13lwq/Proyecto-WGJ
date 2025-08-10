using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class B_Bear : Enemy
{
    [SerializeField] private Animator anim;

    [SerializeField] private Vector2 distance_To_Attack;
    private bool is_Attacking;
    
    public float cooldown;
    public float actual_Cooldown;
    
    private void Start()
    {
        Start_Enemy();
    }

    private void Update()
    {
        Dot_Product();

        if (actual_Cooldown > 0)
        {
            Cooldown();
        }
        else
        {
            if (Mathf.Abs(dis.x) <= distance_To_Attack.x)
            {
                Start_Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    protected override void Start_Enemy()
    {
        anim = GetComponent<Animator>();
        
        base.Start_Enemy();
    }

    internal override void Movement()
    {
        if (is_Attacking) { return; }

        base.Movement();

        anim.SetBool("Moving", rigid.linearVelocity != Vector2.zero ? true : false);
    }

    public void Start_Attack()
    {
        if (is_Attacking) { return; }
        anim.SetBool("Moving", false);
        Debug.Log("Suicidio?");
        is_Attacking = true;
        rigid.linearVelocity = Vector2.zero;
        anim.SetTrigger("Attack");
        Debug.Log("Si");
    }
    
    internal override void Attack()
    {
        Debug.Log("simon");
        base.Attack();
        is_Attacking = false;
        actual_Cooldown = cooldown;
    }
    
    private void Cooldown()
    {
        actual_Cooldown -= Time.deltaTime;
    }

    public override void Lighted()
    {
        anim.SetTrigger("Lighted");
        base.Lighted();
    }

    public override void Unlighted()
    {
        //anim.SetTrigger("Unlighted");
        base.Unlighted();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}
