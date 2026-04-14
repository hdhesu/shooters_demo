using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class KeyboardMovement : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private float gravityValue = -9.81f;
    private float jumpHeight = 1.5f;

    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private CharacterController characterController;

    [Header("Input Actions")]
    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (jumpAction.action.triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * movementSpeed) + (playerVelocity.y * Vector3.up);
        characterController.Move(finalMove * Time.deltaTime);
    }

    
}
