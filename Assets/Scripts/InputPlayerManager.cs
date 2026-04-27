using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    private InputSystem_Actions inputSystem;
    private Vector2 moveInput;

    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        BindInput();
    }

    private void BindInput()
    {
        inputSystem.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputSystem.Player.Move.canceled += _ => moveInput = Vector2.zero;
    }

    private void OnEnable() => inputSystem.Enable();
    private void OnDisable() => inputSystem.Disable();

    private void Update()
    {
        HandleMove();
    }

private void HandleMove()
{
    Debug.Log($"moveInput: {moveInput}"); // kiểm tra có nhận input không

    if (playerManager == null)
    {
        Debug.LogError("playerManager is NULL!");
        return;
    }

    Vector2 clamped = new Vector2(
        moveInput.x != 0 ? Mathf.Sign(moveInput.x) : 0,  // fix Sign(0)
        moveInput.y != 0 ? Mathf.Sign(moveInput.y) : 0
    );

    playerManager.HandleMoveInput((int)clamped.x, (int)clamped.y);
}
}