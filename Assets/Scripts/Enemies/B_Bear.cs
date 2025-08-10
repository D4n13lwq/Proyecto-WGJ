using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class B_Bear : Enemy
{
    [SerializeField] private Animator anim;
    
    private void Start()
    {
        Start_Enemy();
    }

    private void Update()
    {
        Dot_Product();
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
        base.Movement();

        anim.SetBool("Moving", rigid.linearVelocity != Vector2.zero ? true : false);
    }
    
    private void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public override void Lighted()
    {
        anim.SetTrigger("Lighted");
        base.Lighted();
    }

    public override void Unlighted()
    {
        anim.SetTrigger("Unlighted");
        base.Unlighted();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}
