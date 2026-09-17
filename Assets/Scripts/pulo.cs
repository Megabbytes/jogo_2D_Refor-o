using UnityEngine;

public class pulo : MonoBehaviour
{
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }  
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
