    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Start() variables
    public Rigidbody2D rb;
    public Animator anime;
    public Collider2D coll;
   
    //Movement Variables
    public float speed;
    public float jumpForce;
   
    //State machine 
    private enum State {idle, running, jumping, falling, landing};
    private State state = State.idle;
    
    //Touching the grounds
    [SerializeField] private LayerMask ground;


    private void Start()
    {
        
    }



    private void Update()
    {
        Movement();
        StateSwitch();
        anime.SetInteger("state", (int)state);

    }

    private void Movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");

        //Moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        //Moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        //Megaman Stop
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(0, jumpForce);
            state = State.jumping;
        }
    }

    //State Machine
    private void StateSwitch()
    {
        if (state == State.jumping)
        {
                      
            if (rb.velocity.y < 0)
            {
                state = State.falling;
            }
        }

        else  if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
                state = State.landing;
            }
        }


        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            //Moving
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    
    }

}



