using UnityEngine;

public class Oponente : MonoBehaviour
{
    [Header("Referências")]
    public Transform bola;

    [Header("Movimento")]
    public float velocidade = 3f;
    public float limiteEsquerdo = 1f;
    public float limiteDireito = 8f;
    [Range(0f, 1f)]
    public float chanceDeErro = 0.25f;

    [Header("Pulo")]
    public float forcaPulo = 7f;
    public float distanciaParaPular = 2f;

    private Rigidbody2D rb;
    private bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// Pega o Rigidbody2D do oponente
    }

    void Update()
    {
        SeguirBola();// Faz o oponente seguir a bola
        TentarPular();// Faz o oponente tentar pular se a bola estiver próxima e acima dele
    }

    void SeguirBola()
    {
        float alvoX = bola.position.x;// Pega a posição X da bola

        // Impede o oponente de sair do lado dele
        alvoX = Mathf.Clamp(alvoX, limiteEsquerdo, limiteDireito);

        float direcao = alvoX - transform.position.x;// Calcula a direção para a bola

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
            );// Mantém a velocidade vertical atual do Rigidbody2D
        }
    }

    void TentarPular()
    {
        float distanciaX = Mathf.Abs(bola.position.x - transform.position.x);// Calcula a distância horizontal entre a bola e o oponente

        // Se a bola estiver perto e acima do oponente
        if (distanciaX < distanciaParaPular &&
            bola.position.y > transform.position.y &&
            isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );//    Aplica a força de pulo no Rigidbody2D

            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground2"))
        {
            isGrounded = true;
        }
    }
    void TentarPulo()
    {
        float distanciaX = Mathf.Abs(bola.position.x - transform.position.x);

        if (distanciaX < distanciaParaPular &&
            bola.position.y > transform.position.y &&
            isGrounded)
        {
            float sorte = Random.value;

            if (sorte > chanceDeErro)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    forcaPulo
                );

                isGrounded = false;
            }
        }
    }
}
