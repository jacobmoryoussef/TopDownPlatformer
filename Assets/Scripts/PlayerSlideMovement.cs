using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSlideMovement : MonoBehaviour
{

    int TurnDirection;
    Rigidbody2D rb;

    [Header("Adjustments")]
    [SerializeField] float Speed;
    [SerializeField] float MaxSpeed;
    [SerializeField] float RotationSpeed;

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

    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
            if (rb.linearVelocity.magnitude < MaxSpeed)
                rb.AddForce(transform.up * Speed);

            rb.MoveRotation(rb.rotation + (RotationSpeed * TurnDirection));

    }

}
