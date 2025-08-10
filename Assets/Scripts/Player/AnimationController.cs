using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GroundDetector groundDetector;
    [SerializeField] GameObject falsePlayerDeath;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    PlayerMovement PlayerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerMovement = GetComponent<PlayerMovement>();
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
            spriteRenderer.enabled = false;
            PlayerMovement.enabled = false;
            rb.linearVelocity = Vector3.zero;
            StartCoroutine(PIPIPI());
        }
    }

    IEnumerator PIPIPI()
    {
        yield return new WaitForSeconds(1.2f);
        UiManager.Instance.GameOver();
    }
}
