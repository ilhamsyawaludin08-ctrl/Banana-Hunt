using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.6f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    public GameObject gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ground check dulu
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            checkRadius,
            groundLayer
        );

        // Movement
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Animasi jalan / idle
        float animSpeed = Mathf.Abs(move);
        if (animSpeed < 0.1f) animSpeed = 0f;

        anim.SetFloat("Speed", animSpeed);

        // Animasi jump
        anim.SetBool("IsJumping", !isGrounded);

        // Flip karakter
        Vector3 scale = transform.localScale;

        if (move > 0)
            scale.x = -Mathf.Abs(scale.x);
        else if (move < 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;

        // Debug (boleh dihapus nanti)
        Debug.Log(isGrounded);

        if (gameOver != null)
        {
            Debug.Log("GameOver state: " + gameOver.activeSelf);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}