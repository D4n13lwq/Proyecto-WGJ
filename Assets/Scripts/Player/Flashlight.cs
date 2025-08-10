using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightObject;
    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = TryGetComponent(out playerControls) ? playerControls : gameObject.AddComponent<PlayerControls>();
    }

    private void OnEnable()
    {
        playerControls.InputSystem.Player.Attack.performed += TurnOnFlashlight;
        playerControls.InputSystem.Player.Attack.canceled += TurnOffFlashlight;
    }

    private void OnDisable()
    {
        playerControls.InputSystem.Player.Attack.performed -= TurnOnFlashlight;
        playerControls.InputSystem.Player.Attack.canceled -= TurnOffFlashlight;
        TurnOffFlashlight();
    }

    void TurnOnFlashlight(InputAction.CallbackContext context) => flashlightObject.SetActive(true);
    void TurnOffFlashlight(InputAction.CallbackContext context) => flashlightObject.SetActive(false);
    void TurnOffFlashlight() => flashlightObject.SetActive(false);
}
