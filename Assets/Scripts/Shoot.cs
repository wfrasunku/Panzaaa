using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float pushForce;
    private Rigidbody2D rbTank;
    public float cooldown;
    private float timer;
    private float i = 1;

    // Start is called before the first frame update
    void Start()
    {
        rbTank = GetComponent<Rigidbody2D>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnFire()
    {
        if (timer > cooldown)
        {
            timer = 0;
            GameObject instantiated = Instantiate(bullet, transform.position, transform.rotation);

            instantiated.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(1.0f * i / 32, 1.0f, 1.0f);
            i = (i + 1) % 32;

            Rigidbody2D bulletRb = instantiated.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(transform.up * pushForce, ForceMode2D.Impulse);

            rbTank.AddForce(-transform.up * pushForce, ForceMode2D.Impulse);
        }
    }
}
