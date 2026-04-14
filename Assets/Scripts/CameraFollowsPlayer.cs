using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class CameraFollowsPlayer : MonoBehaviour
{

    public float sensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    public InputActionReference mouseAction;
    Vector2 lookInput;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        lookInput = mouseAction.action.ReadValue<Vector2>();

        float mouseX = lookInput.x * sensitivity * Time.deltaTime;
        float mouseY = lookInput.y * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }


}
