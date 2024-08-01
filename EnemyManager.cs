using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damage = 1f;
    public float movementDistance;
    public float speed = 5f;
    private bool movingLeft = true;

    private Vector3 leftEdgePosition;
    private Vector3 rightEdgePosition;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D enemyCollider;
    private Rigidbody2D rb;
    public AudioClip deathSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        leftEdgePosition = transform.position - Vector3.right * movementDistance;
        rightEdgePosition = transform.position + Vector3.right * movementDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y < 0)
            {
                SoundManager.instance.PlaySound(deathSound);
                animator.SetTrigger("Death");
                enemyCollider.enabled = false;
                speed = 0f;
                rb.gravityScale = 0f;
            }
            else
            {
                collision.collider.GetComponent<HealthManager>().TakeDamage(damage);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y < 0)
            {
                SoundManager.instance.PlaySound(deathSound);
                animator.SetTrigger("Death");
                enemyCollider.enabled = false;
                speed = 0f;
                rb.gravityScale = 0f;
            }
            else
            {
                collision.collider.GetComponent<HealthManager>().TakeDamage(damage);
            }
        }
    }

    private void Update()
    {
        animator.SetBool("Run", speed != 0f);

        rb.velocity = new Vector2((movingLeft ? -1 : 1) * speed, rb.velocity.y);

        if (movingLeft && transform.position.x <= leftEdgePosition.x)
        {
            movingLeft = false;
            spriteRenderer.flipX = true;
        }
        else if (!movingLeft && transform.position.x >= rightEdgePosition.x)
        {
            movingLeft = true;
            spriteRenderer.flipX = false;
        }
    }
}
