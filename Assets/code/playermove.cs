using Unity.VisualScripting;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 12f;
    [SerializeField]
    int playerHealth = 3;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Collision2D collision2D;
    bool isjumping;
    public Animator animator;
    void Start()
    {
        isjumping = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //collision2D = GetComponent<Collision2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetTrigger("ide");
            animator.ResetTrigger("run");
        }
        else if(Input.GetAxis("Horizontal") != 0 )
        {
            animator.SetTrigger("run");
            animator.ResetTrigger("ide");
            animator.ResetTrigger("jump");
            spriteRenderer.flipX = false;
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            //Debug.Log(Mathf.Abs(rb.linearVelocityY));
            animator.SetTrigger("jump");
            animator.ResetTrigger("run");
            animator.ResetTrigger("ide");
            rb.linearVelocity = new Vector2(0, jumpForce);
            isjumping = true;

        }
        if(Mathf.Abs(rb.linearVelocityY) < 0.1f && isjumping)
        {
            isjumping = false;
        }
    }
     private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.linearVelocityY);
       

    }
     void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("eagel"))
        {
            playerHealth--;
        }
    }
}
