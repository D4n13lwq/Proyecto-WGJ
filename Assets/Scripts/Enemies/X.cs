using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour
{
    [SerializeField] private Vector2 detectionSize;
    [SerializeField] private Vector2 detectionOffset;
    [SerializeField] private LayerMask enemyLayer;

    private HashSet<I_Enemy> enemiesInRange = new HashSet<I_Enemy>();

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + detectionOffset.x, transform.position.y + detectionOffset.y), detectionSize, enemyLayer);
        HashSet<I_Enemy> currentEnemies = new();

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<I_Enemy>(out I_Enemy enemy))
            {
                currentEnemies.Add(enemy);
                if (!enemiesInRange.Contains(enemy))
                {
                    enemy.Lighted();
                }
            }
        }

        foreach (I_Enemy enemy in enemiesInRange)
        {
            if (!currentEnemies.Contains(enemy))
            {
                enemy.Unlighted();
            }
        }

        enemiesInRange = currentEnemies;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + detectionOffset.x, transform.position.y + detectionOffset.y), detectionSize);
    }
}