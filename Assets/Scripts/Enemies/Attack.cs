using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform circle_Pos;
    [SerializeField] private float circle_Radius;

    public void Do_Attack()
    {
       Collider2D[] collisions = Physics2D.OverlapCircleAll(circle_Pos.position, circle_Radius);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(circle_Pos.position, circle_Radius);
    }
}
