using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] public Transform circle_Pos;
    [SerializeField] private float circle_Radius;

    public void Do_Attack()
    {
        Debug.Log("a");
       Collider2D[] collisions = Physics2D.OverlapCircleAll(circle_Pos.position, circle_Radius);

       foreach (var coll in collisions)
       {
           if (coll.TryGetComponent<PlayerDeath>(out PlayerDeath player))
           {
               player.Death();
           }
       }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(circle_Pos.position, circle_Radius);
    }
}
