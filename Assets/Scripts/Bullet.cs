using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime = 5f; // Czas ¿ycia pocisku w sekundach
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        // Zniszcz pocisk po up³ywie lifeTime sekund
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!collided)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        Collide(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collide(collision);
    }

    private void Collide(Collision2D collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        normal.z = 0f;
        transform.Translate((Vector3.Cross(normal, Vector3.forward) - normal) * Time.fixedDeltaTime, Space.World);
    }
}
