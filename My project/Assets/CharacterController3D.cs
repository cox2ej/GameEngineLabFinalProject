using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    public float groundCheckDistance = 0.4f;

    public LayerMask groundMask;

    public GameObject projectilePrefab;
    public Transform firePoint; // Point from where the projectile will be fired

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab is not assigned in the Inspector.");
        }

        if (firePoint == null)
        {
            Debug.LogError("Fire Point is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        Move();
        Jump();
        GroundCheck();

        if (Input.GetButtonDown("Fire2"))
        {
            FireProjectile();
        }
    }

        private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;

        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravity * rb.mass);
        }
    }

    private void FireProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Projectile Prefab or Fire Point is missing.");
        }
    }
}
