using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int tempoParaVirar;
    public float Velocidade;
    public float quaoParaCimaOPlayerVai;


    private Rigidbody2D rb;
    public GameObject playerObject;
    public Rigidbody2D playerRB;
    public GameObject enemy;
    private Collider2D coll;


    private int contador;
    private int contadorDireita;
    private int contadorEsquerda;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        contadorDireita = 0;

        contadorEsquerda=tempoParaVirar;
    }

    // Update is called once per frame
    void Update()
    {
        
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
