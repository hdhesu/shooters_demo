using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 30f;
    public Transform cam;

    float xRotation = 0f;
    Vector2 lookInput;

    [Header("Input Actions")]
    public InputActionReference mouseAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Locking cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Making cursor invisible
        Cursor.visible = false;
            
    }

    // Update is called once per frame
    void Update()
    {

        lookInput = mouseAction.action.ReadValue<Vector2>();

        // Getting mouse inputs
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Rotates body on the x axis while looking up and down
        xRotation -= mouseY;
        // Locks mouse rotation to stop at when looking directly up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Applying the rotations to the player body
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotates body on the y axis when looking side to side
        transform.Rotate(Vector3.up * mouseX);

    }

    
}
