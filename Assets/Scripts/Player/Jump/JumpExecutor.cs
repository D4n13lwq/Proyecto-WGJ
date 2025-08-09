using UnityEngine;

public class JumpExecutor : MonoBehaviour
{
    [SerializeField] GroundDetector detector;
    [SerializeField] JumpDataSO data;
    Rigidbody2D rb;
    JumpHeightController heightController;
    
    int currentExtraJumps;

    private void Awake()
    {
        rb = TryGetComponent(out rb) ? rb : gameObject.AddComponent<Rigidbody2D>();
        heightController = new(rb, data, detector);
        currentExtraJumps = data.ExtraJumps;
    }

    private void Update()
    {
        ExecuteJump();
        heightController.HandleJumpGravity();
    }

    public void ExecuteJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (detector.DetectGround())
            {
                currentExtraJumps = data.ExtraJumps;
                Jump();
            }
            else if (currentExtraJumps > 0)
            {
                currentExtraJumps--;
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.linearVelocityY = data.JumpForce;
    }
}
