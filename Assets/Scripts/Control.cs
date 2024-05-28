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
        // Sprawdzamy, czy zderzyli�my si� z obiektem, kt�ry jest oznaczony jako przeszkoda
        if (collision.gameObject)
        {
            Die(); // Je�li tak, wywo�ujemy funkcj� Die(), kt�ra b�dzie odpowiedzialna za �mier� gracza
        }
    }

    private void Die()
    {
        // Tutaj mo�esz doda� dowoln� logik� zwi�zana z "�mierci�" gracza, np. dezaktywacj� obiektu gracza, odtworzenie animacji �mierci itp.
        Debug.Log("Gracz zgin��!");
        gameObject.SetActive(false); // Dezaktywujemy obiekt gracza
    }
}
