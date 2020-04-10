using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Publicas
    public int tempoParaVirar;
    public float Velocidade;
    public float quaoParaCimaOPlayerVai;
    public bool ComecarPelaDireita;
    public bool ComecarPelaEsquerda;

    private Rigidbody2D rb;
    public GameObject playerObject;
    public Rigidbody2D playerRB;
    public GameObject enemy;
    private Collider2D coll;


    //Variuaveis q eu talvez use
    private bool direita;
    private bool esquerda;
    private int contador;
    private int contadorDireita;
    private int contadorEsquerda;

    // Start is called before the first frame update
    void Start()
    {
        
        
        if(ComecarPelaDireita){
            direita = true;
            esquerda = false;
        }
        if(ComecarPelaEsquerda){
            direita = false;
            esquerda = true;
        }

        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        contadorDireita = 0;

        contadorEsquerda=tempoParaVirar;
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Pé"){
            print("a");
            Morrer();
        }
        if(other.tag == "Player"){
            Matar();
        }
        
    }

    void Movimento(){

        //Andar para a direita
        if(direita && contador<tempoParaVirar){
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(Velocidade, rb.velocity.y);
            contador++;
        }
        if(esquerda && contador<tempoParaVirar){
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(-Velocidade, rb.velocity.y);
            contador++;
        }
        if(contador>=tempoParaVirar){
            direita = !direita;
            esquerda = !esquerda;
            contador=0;
        }
        print(contador + "direta: " + direita + "/ esquerda: " + esquerda);
        
        

    }

    void Matar(){

        //Mudar depois para tirar vida e reiniciar a fase
        //vou colocar destroy pra concept proof
        Destroy(playerObject);

    }

    void Morrer(){

        //Mudar depois para dropar moeda ou algo assim
        //vou colocar destroy pra concept proof
        playerRB.velocity = new Vector2(playerRB.velocity.x, quaoParaCimaOPlayerVai);
        Destroy(enemy);



    }
}
