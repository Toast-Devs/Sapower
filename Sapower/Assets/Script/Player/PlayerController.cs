using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variaveis publicas
    public float speed;
    public float jumpForce;
    public float shortHop;

   
    public int tempoDePulo;
    public LayerMask ground;
    private Rigidbody2D rb;
    private Collider2D coll;
    private enum State {idle, running, jumping, falling, landing, jump_air}
    private State state = State.idle;
    private Animator anim;

    private bool noChao;

    // Start is called before the first frame update
    void Start()

    {
        state = State.idle;
        noChao = false;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    
    //Animacoes
    void Animacoes(){

        
        if(rb.velocity.x>0.1 || rb.velocity.x<-0.1){
            
            anim.SetBool("Andando", true);
        }
        else{
            
            anim.SetBool("Andando", false);
        }
        
        //inicio do pulo
        if(rb.velocity.y>0.1 && noChao){

            anim.SetBool("Pulando", true);

        }
        else{
            anim.SetBool("Pulando", false);
        }

        //caindo
        if(!noChao && rb.velocity.y<-0.1){
            anim.SetBool("Pulando", false);
            anim.SetBool("Caindo", true);
        }
        else{
            anim.SetBool("Caindo", false);
        }

    }
    
    //Movimento
    void Movement(){
                TocarChao();

        //Horizontal detection
        float hDirection = Input.GetAxisRaw("Horizontal");

        //Direita
        if(hDirection>0.1){

            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);

        }
        //Direita
        else if(hDirection<-0.1){
            

            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        //Pulo
        if(Input.GetButtonDown("Jump") && noChao == true && anim.GetBool("Caindo") == false){
           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 5)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * shortHop);
        }

    }

    void TocarChao(){

        if(coll.IsTouchingLayers(ground)){
            noChao = true;
        }
        else{
            noChao = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Animacoes();
    }



}
