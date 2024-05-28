using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float pushForce;
    private Rigidbody2D rb;
    public float cooldown;
    private float timer;
    private float i = 1;
    private Vector2 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    // Method to be called by PlayerInput component for shooting
    public void OnFire()
    {
        if (timer > cooldown)
        {
            timer = 0;
            // Instantiate bullet
            GameObject instantiated = Instantiate(bullet, transform.position, transform.rotation);

            instantiated.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(1.0f * i / 32, 1.0f, 1.0f);
            i = (i + 1) % 32;

            // Set the bullet to move in the direction the player is facing
            Rigidbody2D bulletRb = instantiated.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(transform.up * pushForce);

            // Apply force in the opposite direction to the player
            rb.AddForce(-transform.up * pushForce, ForceMode2D.Impulse);
        }
    }
}
