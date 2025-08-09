using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] Vector2 size;
    [SerializeField] LayerMask jumpMask;

    public bool DetectGround()
    {
        return Physics2D.OverlapBox(transform.position, size, 0f, jumpMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, size);
    }
}