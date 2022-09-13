using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private float mPlayerSpeed = 10.0f;
    private Vector3 HeadingVector;
    private float JumpVelocity = 0.0f;
    private float mGravity = 19.2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();



    }

    // Update is called once per frame
    void Update()
    {
        HeadingVector = Vector3.zero;
        

        // Jump
        if(controller.isGrounded)
        {
            JumpVelocity = -0.5f;

            if(Input.GetKey(KeyCode.Space))
            {
                JumpVelocity = mPlayerSpeed * 1.5f;
            }
        }
        else
        {
            JumpVelocity -= mGravity * Time.deltaTime;
        }
        HeadingVector.y = JumpVelocity;

        // Move Left & Right
        if (Input.GetKey(KeyCode.A) == true)
        {
            HeadingVector.x -= mPlayerSpeed;
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            HeadingVector.x += mPlayerSpeed;
        }


        // Turn Left & Right

     


        // Forward
        HeadingVector.z = mPlayerSpeed;

        controller.Move(HeadingVector * Time.deltaTime);
    }
}
