using UnityEngine;

[CreateAssetMenu(fileName = "JumpDataSO", menuName = "Player Mechanics/New Jump Data SO")]
public class JumpDataSO : ScriptableObject
{
    [SerializeField] float _jumpForce;
    [SerializeField] int _extraJumps;
    [SerializeField] float _cancelJumpMultiplier;
    [SerializeField] float _gravityMultiplier;
    [SerializeField] float _jumpDiscounter;

    public float JumpForce { get => _jumpForce; }
    public int ExtraJumps { get => _extraJumps; }
    public float CancelJumpMultiplier { get => _cancelJumpMultiplier; }
    public float GravityMultiplier { get => _gravityMultiplier; }
    public float JumpDiscounter { get => _jumpDiscounter; }
}
