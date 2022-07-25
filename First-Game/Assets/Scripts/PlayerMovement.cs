using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float jumpSpeed = 14f;
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState 
    {
        IDLE,
        RUNNING,
        JUMPING,
        FALLING
    }
    private MovementState moveState = MovementState.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        MovementState state;

        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); 

        if(dirX > 0f)
        {
            state = MovementState.RUNNING;
            sprite.flipX = false;

        }
        else if(dirX < 0f)
        {
            state = MovementState.RUNNING;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.IDLE;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.JUMPING;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.FALLING;
        }

        anim.SetInteger("moveState", (int) state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
