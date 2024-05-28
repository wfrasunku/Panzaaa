using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float minSpeed = 0.1f;
    public float lifeTime = 5f;
    private Rigidbody2D rb;
    private bool isStopped = false;
    private float stopTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            if (rb.velocity.magnitude < minSpeed)
            {
                isStopped = true;
                stopTimer = lifeTime;
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
