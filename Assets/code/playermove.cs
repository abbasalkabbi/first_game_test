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
    int playerScore = 0;
    [SerializeField]
    Transform Canvas;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Collision2D collision2D;
    bool isjumping;
    public Animator animator;
    TextMeshProUGUI TexplayerHealth;
    TextMeshProUGUI TexplayerScore;
    void Start()
    {
         TexplayerHealth =Canvas.Find("TexplayerHealth").GetComponent<TextMeshProUGUI>();
        playerHealthTextUpdate();
        TexplayerScore = Canvas.Find("TexplayerScore").GetComponent<TextMeshProUGUI>();
        playerScoreTextUpdate();
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
    // Trigger event for collision with enemies
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("eagel"))
        {
            if(isjumping && rb.linearVelocityY < 0)
            {
                playerScore += 40;
                playerScoreTextUpdate();
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
                playerHealthTextUpdate();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pig"))
        {
            if (isjumping && rb.linearVelocityY < 0)
            {
                playerScore += 30;
                playerScoreTextUpdate();
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
                playerHealthTextUpdate();
            }
        }
        if (collision.gameObject.CompareTag("gem"))
        {
            playerScore += 50;
            playerScoreTextUpdate();
            Destroy(collision.gameObject);
        }
    }
    void playerHealthTextUpdate()
    {
        TexplayerHealth.text = playerHealth.ToString();
    }
    void playerScoreTextUpdate()
    {
        TexplayerScore.text ="Score : "+ playerScore.ToString();
    }
}
