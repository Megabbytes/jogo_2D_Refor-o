using UnityEngine;

public class Oponente : MonoBehaviour
{
    [Header("Referências")]
    public Transform bola;

    [Header("Movimento")]
    public float velocidade = 4f;
    public float limiteEsquerdo = 1f;
    public float limiteDireito = 8f;

    [Header("Pulo")]
    public float forcaPulo = 7f;
    public float distanciaParaPular = 2f;

    private Rigidbody2D rb;
    private bool noChao = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SeguirBola();
        TentarPular();
    }

    void SeguirBola()
    {
        float alvoX = bola.position.x;

        // Impede o oponente de sair do lado dele
        alvoX = Mathf.Clamp(alvoX, limiteEsquerdo, limiteDireito);

        float direcao = alvoX - transform.position.x;

        // Movimento horizontal
        rb.linearVelocity = new Vector2(
            Mathf.Sign(direcao) * velocidade,
            rb.linearVelocity.y
        );

        // Para quando estiver praticamente embaixo da bola
        if (Mathf.Abs(direcao) < 0.2f)
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );
        }
    }

    void TentarPular()
    {
        float distanciaX = Mathf.Abs(bola.position.x - transform.position.x);

        // Se a bola estiver perto e acima do oponente
        if (distanciaX < distanciaParaPular &&
            bola.position.y > transform.position.y &&
            noChao)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            noChao = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground2"))
        {
            noChao = true;
        }
    }
}
