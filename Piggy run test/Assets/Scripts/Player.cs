using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformslayerMask;
    Rigidbody2D rb;
    public float speed;
    //public float jumpHeight;
    //public Transform groundCheck;
    private CapsuleCollider2D capCollider2d;
    //bool isGrounded;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capCollider2d = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 3);
            float jumpVelocity = 15f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        /*CheckGround();
        if (isGrounded)
        {
            //Flip();
            anim.SetInteger("State", 2);
        }*/

        /*if (Input.GetAxis("Horizontal") == 0 && (isGrounded))
        {
            anim.SetInteger("State", 1);
        } else
        {
            if (isGrounded)
            {
                //Flip();
                anim.SetInteger("State", 2);
            }
        }*/
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.CapsuleCast(capCollider2d.bounds.center, capCollider2d.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, platformslayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        /* if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
         {
             rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
         }*/

    }

    /*void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
        {
            anim.SetInteger("State", 3);
        }
    }*/
}