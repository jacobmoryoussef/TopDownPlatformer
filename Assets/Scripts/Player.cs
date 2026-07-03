using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    int TurnDirection;
    Rigidbody2D rb;
    [SerializeField] float zVelocity;

    [Header("Adjustments")]
    [SerializeField] float Speed;
    [SerializeField] float MaxSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] float JumpHeight;
    [SerializeField] float zGravity;
    [SerializeField] float PlayerSize;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        TurnDirection = 0;
        if (Input.GetKey(KeyCode.D))
            TurnDirection = -1;
        if (Input.GetKey(KeyCode.A))
            TurnDirection = 1;

        transform.position = new Vector3(transform.position.x, transform.position.y, zVelocity);

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, PlayerSize * zVelocity);

    }

    private void FixedUpdate()
    {

        //Vector3 CurrentVelocity = rb.linearVelocity;

        //if (CurrentVelocity.magnitude > MaxSpeed)
        //CurrentVelocity = CurrentVelocity.normalized * MaxSpeed;

        if (Input.GetKey(KeyCode.W))
            if (rb.linearVelocity.magnitude < MaxSpeed)
                rb.AddForce(transform.up * Speed);

            rb.MoveRotation(rb.rotation + (RotationSpeed * TurnDirection));

        if (Input.GetKeyDown(KeyCode.Space))
        {

            zVelocity = zVelocity + JumpHeight;
        
        }

        zVelocity = zVelocity * zGravity;

    }

}
