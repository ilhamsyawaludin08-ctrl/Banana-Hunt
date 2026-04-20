using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // 🔥 FIX ANIMASI
        float animSpeed = Mathf.Abs(move);

        if (animSpeed < 0.1f)
        {
            animSpeed = 0f;
        }

        anim.SetFloat("Speed", animSpeed);

        // 🔥 FLIP
        Vector3 scale = transform.localScale;

        if (move > 0)
            scale.x = -Mathf.Abs(scale.x);
        else if (move < 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Lompat (pakai grounded)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}