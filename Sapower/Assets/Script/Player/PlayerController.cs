using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variaveis publicas
    public float speed;
    public float jumpForce;
    public float tempoDePulo;

    public LayerMask ground;
    

    private Rigidbody2D rb;
    private Collider2D coll;
    private enum State {idle, running, jumping, falling, landing, jump_air}
    private State state = State.idle;
    private Animator anim;



    private int contador; 
    private bool noChao;

    // Start is called before the first frame update
    void Start()

    {
        state = State.idle;
        noChao = false;
        contador=0;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    
    //Animacoes
    void Animacoes(){

        anim.SetInteger("state", (int)state);
        
        if(rb.velocity.x==0){
            
            anim.SetBool("running", false);
        }
        else{
            
            anim.SetBool("running", true);
        }
        
        //inicio do pulo
        if(rb.velocity.y>0.1){

            if(state==State.jumping){
                anim.SetBool("Pulando", true);
            }
            else{
                anim.SetBool("Pulando", false);
                anim.SetBool("Pulo-noar", true);
                
            }


        }

        //caindo
        if(!noChao && rb.velocity.y<-0.1){
            anim.SetBool("Pulo-noar", false);
                
            state = State.falling;
        }
        else{
            state = State.idle;
        }

    }
    
    //Movimento
    void Movement(){

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
        if(Input.GetButton("Jump") && contador<tempoDePulo){
            contador++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        TocarChao();

        if(noChao == true){
            contador=0;
        }

        print("contador: "+contador);

    }

    /*
    transforma no Chao em true ao tocar no layerground 
    (se ele estiver na parede ele escala, me liga no discord para resolvermos)
    */
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
        Animacoes
();
    }
}
