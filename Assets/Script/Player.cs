using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7;
    Animator animator;
    UIcontroler UIcontroler;
    Rigidbody2D rgb;
    bool isGround;
    public float jumpforce = 7;
    float countJump = 0;
    public Transform GroundCheck;
    public float GroundCheckDistance = 0.5f;
    public LayerMask Ground;
    SpriteRenderer spriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {   
        UIcontroler = FindObjectOfType<UIcontroler>();
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (UIcontroler.GameIsOver)
        {
            return;
        }
        GroundChecker();
        float xDirection = Input.GetAxis("Horizontal");
        float movePlayer = speed* xDirection* Time.deltaTime;
        if (xDirection != 0)
            animator.SetBool("IsRunning", true);
        else
            animator.SetBool("IsRunning", false);
        if ((transform.position.x <= -8.17f && xDirection < 0) || (transform.position.x >= 8.17f && xDirection > 0))
            return;
        transform.position = new Vector2(transform.position.x + movePlayer,transform.position.y);
        if (countJump < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            rgb.velocity = new Vector2(rgb.velocity.x, jumpforce);
            animator.SetBool("isJump", true);
            countJump++;
        }
    }
    void GroundChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, Ground);
        if (hit.collider != null)
        {
            animator.SetBool("isJump", false);
            countJump = 0;
        }
    }
    IEnumerator BuffSpeed()
    {
        spriteRenderer.color = Color.green;
        speed += 2;
        yield return new WaitForSeconds(5);
        spriteRenderer.color = Color.white;
        speed -= 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            StartCoroutine(BuffSpeed());
        }
    }
}
