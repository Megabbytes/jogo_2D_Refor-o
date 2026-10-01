using UnityEngine;

public class Perederebote : MonoBehaviour
{
    public float forcaHorizontalParede = 7f;
    public float forcaVerticalParede = 6f;
    public float forcaHorizontalParede2 = 6f;
    public float forcaVerticalParede2 = 7f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            RebaterParede();
        }

        if (collision.gameObject.CompareTag("Parede2"))
        {
            RebaterParede2();
        }
    }
    void RebaterParede()
    {

        rb.linearVelocity = new Vector2(
            -forcaHorizontalParede,
            forcaVerticalParede + 1
        );
    }
    void RebaterParede2()
    {

        rb.linearVelocity = new Vector2(
            -forcaHorizontalParede,
            forcaVerticalParede + 1
        );
    }
}
