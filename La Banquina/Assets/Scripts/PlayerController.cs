using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player references")]
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator anim;

    [Header("Movement variables")]
    private float horizontalInput;
    [SerializeField] private float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (horizontalInput == 0)
        {
            anim.SetBool("Idle", true);
        }
        else
        {
            anim.SetBool("Idle", false);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Flip();
        Vector2 movement = transform.right * horizontalInput * speed * Time.deltaTime;
        movement = rb.position + movement;
        movement.x = Mathf.Clamp(movement.x, -14f, 14f);
        rb.MovePosition(movement);
    }

    private void Flip()
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = spriteRenderer.flipX;
        }
    }
}
