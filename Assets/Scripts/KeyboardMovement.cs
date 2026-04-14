using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    float gravity = -9.81f * 2;

    private Vector2 playerMoveInput;
    private Vector3 velocity;
    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        playerMoveInput = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 direction = transform.right * playerMoveInput.x + transform.forward * playerMoveInput.y;
        characterController.Move(direction.normalized * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
