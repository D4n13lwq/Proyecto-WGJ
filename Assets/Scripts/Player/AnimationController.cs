using UnityEditorInternal;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GroundDetector groundDetector;
    [SerializeField] GameObject falsePlayerDeath;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out I_Enemy enemy))
        {
            falsePlayerDeath.transform.position = transform.position;
            falsePlayerDeath.transform.rotation = transform.rotation;
            falsePlayerDeath.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
