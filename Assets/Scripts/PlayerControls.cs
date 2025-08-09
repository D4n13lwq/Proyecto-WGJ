using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    InputSystem_Actions _inputSystem;

    public InputSystem_Actions InputSystem => _inputSystem;

    private void Awake()
    {
        _inputSystem = new();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    public Vector2 ReadInput()
    {
        return _inputSystem.Player.Move.ReadValue<Vector2>();
    }
}
