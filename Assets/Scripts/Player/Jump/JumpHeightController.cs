using UnityEngine;

public class JumpHeightController
{
    readonly Rigidbody2D rb;
    readonly JumpDataSO data;
    readonly GroundDetector detector;
    readonly float originalGravity;

    public JumpHeightController(Rigidbody2D rb, JumpDataSO data, GroundDetector detector)
    {
        this.rb = rb;
        this.data = data;
        this.detector = detector;
        originalGravity = rb.gravityScale;
    }

    public void HandleJumpGravity()
    {
        if (Input.GetButtonUp("Jump") && rb.linearVelocityY > 0)
        {
            rb.AddForce(Vector2.down * rb.linearVelocityY * (1 - data.CancelJumpMultiplier), ForceMode2D.Impulse);
        }

        if (rb.linearVelocityY < 0 && !detector.DetectGround())
        {
            rb.gravityScale = originalGravity * data.GravityMultiplier;
        }
        else
        {
            rb.gravityScale = originalGravity;
        }
    }
}
