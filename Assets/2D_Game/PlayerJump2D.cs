using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump2D : MonoBehaviour
{
    public float jumpForce = 7f;          // ジャンプの強さ
    public string groundTag = "Ground";   // 地面のタグ

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // 上方向速度をリセットしてからジャンプ（連続ジャンプが安定する）
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
