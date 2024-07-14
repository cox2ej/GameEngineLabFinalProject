using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.4f;
    public float slopeForce = 5f;
    public float slopeForceRayLength = 1.5f;

    public LayerMask groundMask;

    public GameObject projectilePrefab;
    public Transform firePoint;

    private Rigidbody rb;
    private bool isGrounded;

    private StateMachine stateMachine;
    private Vector3 moveDirection;
    private Vector3 horizontalMove;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();

        // Initialize with IdleState
        stateMachine.ChangeState(new IdleState(gameObject));

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

        if (PlayerUnlocksProjectile.instance == null)
        {
            Debug.LogError("PlayerUnlocksProjectile instance is not initialized.");
        }
    }

    void Update()
    {
        HandleInput();
        GroundCheck();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire2") && PlayerUnlocksProjectile.instance.projectileAbilityUnlocked)
        {
            FireProjectile();
            stateMachine.ChangeState(new FiringState(gameObject));
        }
        else if (Input.GetButtonDown("Jump") && isGrounded)
        {
            stateMachine.ChangeState(new JumpingState(gameObject, jumpForce));
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!(stateMachine.CurrentState is MoveState))
            {
                stateMachine.ChangeState(new MoveState(gameObject, moveSpeed));
            }
        }
        else
        {
            if (!(stateMachine.CurrentState is IdleState))
            {
                stateMachine.ChangeState(new IdleState(gameObject));
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = transform.right * moveX + transform.forward * moveZ;
        horizontalMove = moveDirection * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + horizontalMove);

        if (OnSlope() && moveDirection != Vector3.zero)
        {
            rb.AddForce(Vector3.up * slopeForce);
        }
    }

    private void ApplyGravity()
    {
        if (!isGrounded)
        {
            Vector3 gravityVector = Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
            rb.AddForce(gravityVector, ForceMode.Acceleration);
        }
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

    private bool OnSlope()
    {
        if (isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeForceRayLength))
            {
                if (hit.normal != Vector3.up)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void FireProjectile()
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
