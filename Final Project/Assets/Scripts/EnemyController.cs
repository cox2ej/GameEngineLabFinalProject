using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player damage here
        }
    }
}
