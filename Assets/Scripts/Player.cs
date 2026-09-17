using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// reconhece o movimeto do player horizontalmente, seja para esquerda ou direita

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);// faz o calculo da movimentação do player, multiplicando a velocidade pelo movimento horizontal e mantendo a velocidade vertical atual do player
    }
}
