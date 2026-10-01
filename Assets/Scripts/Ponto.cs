using UnityEngine;

public class Ponto : MonoBehaviour
{
    [Header("Spawn")]
    public Transform spawnBola;

    [Header("Força da bola")]
    public float forcaPlayer = 8f;

    [Header("Rebatida do oponente")]
    public float forcaHorizontalOponente = 6f;
    public float forcaVerticalOponente = 7f;
    private int pontos = 0;
    private int pontos2 = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            pontos2 += 1;
            Debug.Log("Ponto! Total: " + pontos);
            Debug.Log("Ponto! Placar:" + pontos + " | " + pontos2);
            ResetarBola();
        }

        if (collision.gameObject.CompareTag("Ground2"))
        {
            pontos += 1;
            Debug.Log("Ponto! Placar:" + pontos + " " + pontos2);
            ResetarBola();
        }

        if (pontos >= 5)
        {
            Debug.Log("Jogador 1 venceu!");

        }
        else if (pontos2 >= 5)
        {
            Debug.Log("Jogador 2 venceu!");
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetarBola();
        }

       
        if (collision.gameObject.CompareTag("Player"))
        {
            RebaterPlayer();
        }

        
        if (collision.gameObject.CompareTag("Oponente"))
        {
            RebaterOponente();
        }
    }

    void RebaterPlayer()
    {
        
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            forcaPlayer
        );
    }

    void RebaterOponente()
    {

        rb.linearVelocity = new Vector2(
            -forcaHorizontalOponente,
            forcaVerticalOponente
        );
    }

    void ResetarBola()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = spawnBola.position;
    }
}

