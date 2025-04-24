using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class controlerPlayer : MonoBehaviour
{
    public FixedJoystick joystick; 
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
      
    }



    void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("walk", true);   
            Vector3 velocity = moveDirection * moveSpeed;
            rb.velocity = velocity;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("walk", false);
            rb.velocity = Vector3.zero;
        }



       
    }
}