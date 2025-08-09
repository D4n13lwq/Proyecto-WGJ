using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    PlayerControls playerControls;
    Rigidbody2D rb;
    DirectionController directionController;

    private void Awake()
    {
        playerControls = TryGetComponent(out playerControls) ? playerControls : gameObject.AddComponent<PlayerControls>();
        rb = TryGetComponent(out rb) ? rb : gameObject.AddComponent<Rigidbody2D>();
        directionController = new();
    }

    private void Update()
    {
        directionController.HandleOrientation(playerControls.ReadInput().x, transform);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocityX = playerControls.ReadInput().x * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
