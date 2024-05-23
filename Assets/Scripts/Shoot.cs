using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float pushForce;
    private Rigidbody2D rb;
    public float cooldown;
    private float timer;
    private float i = 1;

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
        if (Input.GetMouseButton(0) && timer > cooldown)
        {
            timer = 0;
            // Instantiate bullet
            GameObject instantiated = Instantiate(bullet, transform.position, transform.rotation);

            instantiated.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(1.0f * i / 32, 1.0f, 1.0f);
            i = (i + 1) % 32;


            // Get the mouse position in the world
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Z is irrelevant in 2D

            // Calculate direction from mouse to the object
            Vector3 direction = transform.position - mousePosition;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Apply force in the opposite direction
            rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
        }
    }
}
