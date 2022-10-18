using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float checkRadius;
    public float jumpForce;
    public float speed;
    private bool facingRight = true;
    private bool isGrounded;
    private float moveInput;

    public LayerMask whatIsGround;
    public Transform feetPos;
    private Animator animator;
    private Inventory inventory;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(moveInput * speed, rBody.velocity.y);

        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);

            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rBody.velocity = Vector2.up * jumpForce;
                animator.SetTrigger("takeOf");
            }
        }
        else {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.Bag();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
