using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    private Vector2 rotateInputValue;

    private void OnRotate(InputValue value)
    {
        rotateInputValue = value.Get<Vector2>();
        Debug.Log(rotateInputValue);
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
        // Sprawdzamy, czy zderzyliœmy siê z obiektem, który jest oznaczony jako przeszkoda
        if (collision.gameObject)
        {
            Die(); // Jeœli tak, wywo³ujemy funkcjê Die(), która bêdzie odpowiedzialna za œmieræ gracza
        }
    }

    private void Die()
    {
        // Tutaj mo¿esz dodaæ dowoln¹ logikê zwi¹zana z "œmierci¹" gracza, np. dezaktywacjê obiektu gracza, odtworzenie animacji œmierci itp.
        Debug.Log("Gracz zgin¹³!");
        gameObject.SetActive(false); // Dezaktywujemy obiekt gracza
    }
}
