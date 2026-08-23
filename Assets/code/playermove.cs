using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playermove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 12f;
    [SerializeField]
    int playerHealth = 3;
    [SerializeField]
    Transform Canvas;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Collision2D collision2D;
    bool isjumping;
    public Animator animator;
    TextMeshProUGUI TexplayerHealth;
    void Start()
    {
         TexplayerHealth =Canvas.Find("TexplayerHealth").GetComponent<TextMeshProUGUI>();
        TexplayerHealth.text = playerHealth.ToString();
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
            if(isjumping && rb.linearVelocityY < 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
                TexplayerHealth.text = playerHealth.ToString();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pig"))
        {
            if (isjumping && rb.linearVelocityY < 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
                TexplayerHealth.text = playerHealth.ToString();
            }
        }
    }
}
