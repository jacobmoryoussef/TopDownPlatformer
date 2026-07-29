using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // 1 = right, -1 = left
    public   int direction = 1;
    Animator animator;
    public bool IsJumping;
    float yJumpVelocity;
    public float GroundY;
    BoxCollider2D BoxCollider;
    [SerializeField] public bool OnPlatform;
    [SerializeField] public bool InRiver;

    [Header("Adjustments")]
    [SerializeField] float PlayerSpeed;
    [SerializeField] float PlayerSize;
    [SerializeField] float JumpGravity;
    [SerializeField] float JumpPower;
    [SerializeField] float SprintSpeed;

    private void Start()
    {

        BoxCollider = GetComponent<BoxCollider2D>();
        IsJumping = false;
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        if (direction == 1)
            transform.localScale = new Vector3(PlayerSize, PlayerSize, PlayerSize);
        else
            transform.localScale = new Vector3(-PlayerSize, PlayerSize, PlayerSize);

        if (Input.GetKeyDown(KeyCode.Space))
            if (IsJumping == false)
            {

                IsJumping = true;
                GroundY = transform.position.y;
                yJumpVelocity = JumpPower;

            }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (animator.GetBool("IsSitting"))
                animator.SetBool("IsSitting", false);
            else
                animator.SetBool("IsSitting", true);

        }

        if (InRiver && !OnPlatform && !IsJumping)
                Debug.Log("Player Dead");

        if (InRiver && !OnPlatform && !IsJumping)
        {

            SceneManager.LoadScene("Game");
        
        }

    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.D))
        { 
        
            transform.position = transform.position + new Vector3(PlayerSpeed, 0, 0);
            direction = 1;
            
            if (Input.GetKey(KeyCode.LeftShift))
                transform.position = transform.position + new Vector3(SprintSpeed, 0, 0);

        }

        if (Input.GetKey(KeyCode.A))
        { 
        
            transform.position = transform.position + new Vector3(-PlayerSpeed, 0, 0);
            direction = -1;

            if (Input.GetKey(KeyCode.LeftShift))
                transform.position = transform.position + new Vector3(-SprintSpeed, 0, 0);

        }

        if (Input.GetKey(KeyCode.W))
        { 
        
            transform.position = transform.position + new Vector3(0, PlayerSpeed, 0);

            if (IsJumping)
                GroundY = GroundY + PlayerSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
                transform.position = transform.position + new Vector3(0, SprintSpeed, 0);

        }

        if (Input.GetKey(KeyCode.S))
        { 
        
            transform.position = transform.position + new Vector3(0, -PlayerSpeed, 0);

            if (IsJumping)
                GroundY = GroundY - PlayerSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
                transform.position = transform.position + new Vector3(0, -SprintSpeed, 0);

        }

        if (IsJumping)
        {

            animator.SetBool("IsTouchingGround", false);
            transform.position = transform.position + new Vector3(0, yJumpVelocity, 0);

            if (yJumpVelocity > 0)
            {

                animator.SetBool("IsRising", true);
                animator.SetBool("IsFalling", false);

            }
            else
            {

                animator.SetBool("IsRising", false);
                animator.SetBool("IsFalling", true);

            }

            if (transform.position.y < GroundY)
            {

                IsJumping = false;
                transform.position = new Vector3(transform.position.x, GroundY, transform.position.z);

            }

            BoxCollider.isTrigger = true;
            yJumpVelocity = yJumpVelocity - JumpGravity;

        }
        else
        {

            animator.SetBool("IsTouchingGround", true);
            BoxCollider.isTrigger = false;
        
        }



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Platform"))
            OnPlatform = true;
        if (collision.gameObject.CompareTag("River"))
            InRiver = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
            OnPlatform = false;
        if (collision.gameObject.CompareTag("River"))
            InRiver = false;

    }

}
