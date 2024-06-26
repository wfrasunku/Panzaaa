using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    private Vector2 rotateInputValue;

    private void OnRotate(InputValue value)
    {
        rotateInputValue = value.Get<Vector2>();
    }

    private void RotateLogicMethod()
    {
        if (rotateInputValue != Vector2.zero)
        {
            float angle = Mathf.Atan2(rotateInputValue.y, rotateInputValue.x) * Mathf.Rad2Deg - 90f;
            rb2D.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        RotateLogicMethod();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        gameObject.SetActive(false);
    }
}
