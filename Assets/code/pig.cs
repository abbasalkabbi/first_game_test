using UnityEngine;

public class pig : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    Rigidbody2D rb;
    SpriteRenderer sp;
    bool isRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp=GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Mathf.Abs(rb.linearVelocity.x) < 0.1f)
        {
            isRight = !isRight;
            sp.flipX = !sp.flipX;
        }
        if (isRight)
            rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        else
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocityY);
    }
}
