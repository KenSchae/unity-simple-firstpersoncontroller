/******************************************************************************
 * Initial code based on Brackey's FPS video
 * https://youtu.be/_QajrabyTJc
 * 
 * Notes:
 * In the video, he attaches this script to the camera. I refactored it to put
 * it up on the main player element. That way the behaviors are all in one 
 * place and "hidden."
 * 
 * Changed the mouse sensitivity variable to use a Float Reference. This allows
 * me to put the value into a property/settings UI so the player can change the
 * value to his/her preference. Or it can be changed at design time in Unity.
 *****************************************************************************/

/******************************************************************************
 * The Mouse Look script is responsible for rotating the player object and the
 * main camera in response to the movement of the mouse.
 * 
 * Movement of the mouse on the Y axis simulates looking up and down. This will
 * rotate the camera and is clamped to a human-like range of motion.
 * 
 * Movement on the mouse on the X axis simulates turning. This will rotate the
 * player object.
 *****************************************************************************/
using Architecture.Variables;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private FloatReference mouseSensitivity;
    private float xRotation = 0f;

    [SerializeField] private Transform mainCamera;

    void Start()
    {
        // Keep the mouse cursor in the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.Value * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.Value * Time.deltaTime;

        // Simulate looking up and down by rotating the camera. Clamp the rotation 
        // to limit the range of motion.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        mainCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Simulate turning
        transform.Rotate(Vector3.up * mouseX);
    }
}
