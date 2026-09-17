using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashForce = 10f;

    private Rigidbody2D rb;
    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pega a direção horizontal
        direction = Input.GetAxisRaw("Horizontal");

        // Aperta Shift para dar o Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    void Dash()
    {
        // Se estiver parado, usa a direção que o Player está olhando
        if (direction == 0)
        {
            direction = transform.localScale.x > 0 ? 1 : -1;
        }

        // Aplica a força do Dash
        rb.linearVelocity = new Vector2(
            direction * dashForce,
            rb.linearVelocity.y
        );
    }
}
