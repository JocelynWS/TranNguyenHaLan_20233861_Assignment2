using UnityEngine;

public class PlayerLocomotionManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Animator animator;

    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void SetInput(float horizontal, float vertical)
    {
        horizontalInput = horizontal;
        verticalInput = vertical;
    }

    public void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (animator != null)
        {
            animator.SetFloat("MoveX", horizontalInput);
            animator.SetFloat("MoveY", verticalInput);
        }
    }
}