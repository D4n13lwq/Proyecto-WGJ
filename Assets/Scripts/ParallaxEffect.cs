using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float parallaxFactor = 0.5f;

    private Vector3 lastPlayerPosition;

    private void Start()
    {
        if (player == null)
        {
            enabled = false;
            return;
        }

        lastPlayerPosition = player.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
        lastPlayerPosition = player.position;
    }
}