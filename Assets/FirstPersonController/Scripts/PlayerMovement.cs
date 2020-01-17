/******************************************************************************
 * Initial code based on Brackey's FPS video
 * https://youtu.be/_QajrabyTJc
 * 
 * Notes:
 * Refactored public fields to [SerializeField].
 * 
 * Refactored player and environment attributes to use Float References. This 
 * will allow other objects to buff/debuff these settings. 
 *****************************************************************************/

/******************************************************************************
 * 
 *****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Architecture.Variables;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] private CharacterController controller;

    [Header("Attributes")]
    [SerializeField] private FloatReference playerWalkSpeed;
    [SerializeField] private FloatReference playerRunSpeed;
    [SerializeField] private FloatReference jumpHeight;

    [Header("Environment")]
    [SerializeField] private FloatReference gravity;
    private Vector3 velocity;

    [Header("Ground")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;

    void Update()
    {
        // Check if the player is on the ground and reset gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Implement movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            Debug.Log("Running");
            controller.Move(move * playerRunSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Walking");
            controller.Move(move * playerWalkSpeed.Value * Time.deltaTime);
        }

        // Implement jumping       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight.Value * -2f * gravity.Value);
        }

        // Implement gravity
        velocity.y += gravity.Value * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
