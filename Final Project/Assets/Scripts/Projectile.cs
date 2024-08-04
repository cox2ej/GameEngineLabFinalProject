using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 2.0f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with enemy or other objects
        Destroy(gameObject);
    }
}
