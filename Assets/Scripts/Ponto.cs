using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ponto : MonoBehaviour
{
    [Header("Spawn inimigo")]
    public Transform spawnBola;

    [Header("Spawn Player")]
    public Transform spawnBolaPlayer;

    [Header("Força da bola")]
    public float forcaPlayer = 8f;

    [Header("Rebatida do oponente")]
    public float forcaHorizontalOponente = 6f;
    public float forcaVerticalOponente = 7f;
    private int pontos = 0;
    private int pontos2 = 0;
    private Rigidbody2D rb;

    public int pontos_reiniciar = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            pontos2 += 1;
            Debug.Log("Ponto! Placar: " + pontos + " | " + pontos2);
            ResetarBolainimigo();
        }

        if (collision.gameObject.CompareTag("Ground2"))
        {
            pontos += 1;
            Debug.Log("Ponto! Placar: " + pontos + " | " + pontos2);
            Reseterbolaplayer();
        }

        if (pontos >= 5)
        {
            Debug.Log("Jogador 1 venceu!");

        }
        else if (pontos2 >= 5)
        {
            Debug.Log("Jogador 2 venceu!");
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
    
    
    void ResetarBolainimigo()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = spawnBola.position;

    }
    void Reseterbolaplayer()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnBolaPlayer.position;
    }
    private void Update()
    {
        if (pontos >= pontos_reiniciar || pontos2 >= pontos_reiniciar)
        {

            Time.timeScale = 1f;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

