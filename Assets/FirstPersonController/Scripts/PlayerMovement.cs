using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Implement movement
    public CharacterController controller;
    public float speed = 12f;

    // Implement gravity
    public float gravity = -9.81f;
    private Vector3 velocity;

    // Implement ground reset of gravity
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // Implement jumping
    public float jumpHeight = 3f;
    
    void Update()
    {
        // Check if the player is on the ground and reset gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Implement movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Implement jumping       
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Implement gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
