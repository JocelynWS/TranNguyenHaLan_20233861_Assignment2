using UnityEngine;

public class PlayerManager : CharacterManager
{
    [Header("Player")]
    [SerializeField] private PlayerLocomotionManager locomotion;

    protected override void Awake()
    {
        base.Awake();

        if (locomotion == null)
        {
            locomotion = GetComponent<PlayerLocomotionManager>();
        }

        if (locomotion == null)
        {
            Debug.LogError("Missing PlayerLocomotionManager!");
        }
    }

    private void Update()
    {
        locomotion.HandleMovement();
    }

    public void HandleMoveInput(int x, int y)
    {
        locomotion.SetInput(x, y);
    }
}