using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;

    [Header("Dash")]
    public float dashForce = 20f;
    public float dashDuration = 0.2f;

    private Rigidbody2D rb;

    private float moveHorizontal;

    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Reconhece o movimento horizontal
        moveHorizontal = Input.GetAxis("Horizontal");

        // Aperta Shift para usar o Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    void FixedUpdate()
    {
        // Enquanto estiver no Dash,
        // o movimento normal não interfere
        if (isDashing)
        {
            return;
        }

        // Movimento normal
        rb.linearVelocity = new Vector2(
            moveHorizontal * speed,
            rb.linearVelocity.y
        );
    }

    void Dash()
    {
        // Descobre a direção do Dash
        float direction;

        if (moveHorizontal != 0)
        {
            direction = moveHorizontal;
        }
        else
        {
            // Se estiver parado, usa o lado que o Player está olhando
            direction = transform.localScale.x > 0 ? 1f : -1f;
        }

        // Ativa o Dash
        isDashing = true;

        // Aplica a velocidade do Dash
        rb.linearVelocity = new Vector2(
            direction * dashForce,
            0f
        );

        // Depois da duração, volta ao movimento normal
        Invoke(nameof(PararDash), dashDuration);
    }

    void PararDash()
    {
        isDashing = false;

        rb.linearVelocity = new Vector2(
            0f,
            rb.linearVelocity.y
        );
    }
}
