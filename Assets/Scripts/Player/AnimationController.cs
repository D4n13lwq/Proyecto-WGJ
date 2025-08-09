using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GroundDetector groundDetector;
    Animator animator;
    Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetBool("OnGround", groundDetector.DetectGround());
        animator.SetFloat("RbYVelocity", rb.linearVelocityY);
        animator.SetBool("OnMovement", rb.linearVelocityX != 0);
    }
}
