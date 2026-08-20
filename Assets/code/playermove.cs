using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float speed = 5f;
    float jumpForce = 5f;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
          spriteRenderer = GetComponent<SpriteRenderer>();
          animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = false;
            animator.SetTrigger("run");
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = true;
            animator.SetTrigger("run");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, jumpForce * Time.deltaTime, 0));
            animator.SetTrigger("jump");

        }
        animator.SetTrigger("ide");
    }
}
