using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public Transform cameraTransform;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Get input from user
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get camera forward and right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalize the forward and right vectors
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the desired movement direction
        Vector3 desiredMoveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        // Apply movement to the character
        Vector3 movement = desiredMoveDirection * speed;

        Vector3 newVelocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        rb.velocity = newVelocity;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
