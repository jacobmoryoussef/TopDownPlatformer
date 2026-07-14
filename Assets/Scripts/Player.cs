using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    // 1 = right, -1 = left
    int direction = 1;
    Animator animator;
    [SerializeField] bool IsJumping;
    [SerializeField] float yJumpVelocity;
    [SerializeField] float GroundY;
    

    [Header("Adjustments")]
    [SerializeField] float PlayerSpeed;
    [SerializeField] float PlayerSize;
    [SerializeField] float JumpGravity;
    [SerializeField] float JumpPower;

    private void Start()
    {

        IsJumping = false;
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        if (direction == 1)
            transform.localScale = new Vector3(PlayerSize, PlayerSize, PlayerSize);
        else
            transform.localScale = new Vector3(-PlayerSize, PlayerSize, PlayerSize);

    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.D))
        { 
        
            transform.position = transform.position + new Vector3(PlayerSpeed, 0, 0);
            direction = 1;
        
        }
        if (Input.GetKey(KeyCode.A))
        { 
        
            transform.position = transform.position + new Vector3(-PlayerSpeed, 0, 0);
            direction = -1;
        
        }
        if (Input.GetKey(KeyCode.W))
            transform.position = transform.position + new Vector3(0, PlayerSpeed, 0);
        if (Input.GetKey(KeyCode.S))
            transform.position = transform.position + new Vector3(0, -PlayerSpeed, 0);


        if (Input.GetKeyDown(KeyCode.Space))
            if (IsJumping == false)
            {

                IsJumping = true;
                GroundY = transform.position.y;
                yJumpVelocity = JumpPower;

            }

        if (IsJumping)
        { 
        
            transform.position = transform.position + new Vector3(0, yJumpVelocity, 0);

            if (transform.position.y < GroundY)
            {

                IsJumping = false;
                transform.position = new Vector3(transform.position.x, GroundY, transform.position.z);
            
            }

            yJumpVelocity = yJumpVelocity - JumpGravity;

        }



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);

    }

}
